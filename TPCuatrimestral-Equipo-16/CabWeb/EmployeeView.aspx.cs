using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CabBusiness;
using CabDominio;

namespace CabWeb
{
    public partial class EmployeeView : System.Web.UI.Page
    {
        public Employee CurrentEmployee;
        public int CurrentContent = 0;
        public string ProfilePhoto;
        protected void Page_Load(object sender, EventArgs e)
        {

            CurrentEmployee = (Employee)Session["EmployeeLogged"];

            updateBookingEmployeeSession();
            updateFlightEmployeeSession();
            loadProfile(CurrentEmployee);
            loadBookings();
            loadFlights();
            if (!IsPostBack)
            {
               
                panelHome.CssClass = "";
                panelDashboard.CssClass = "hidden";
                panelFlight.CssClass = "hidden";


            }

        }



        private void loadProfile(Employee CurrentEmployee)
        {
            loadProfilePhoto();
            txtName.Text = CurrentEmployee.Name;
            txtLastName.Text = CurrentEmployee.Surname;
            txtEmail.Text = CurrentEmployee.credentials.Email;
            txtCel.Text = CurrentEmployee.Cellphone.ToString();
            txtAdress.Text = CurrentEmployee.Address;
            txtGender.Text = CurrentEmployee.Gender.ToString();

        }
        private void loadFlights()
        {
            repeaterFlight.DataSource = (List<Flight>)Session["Flights"];
            repeaterFlight.DataBind();
        }

        private void loadBookings()
        {

            List<Booking> allBookings = (List<Booking>)Session["Bookings"];
            List<Booking> bookingsInProgress = allBookings.Where(booking => booking.StateBooking == "En proceso").ToList();
            rptActiveBokings.DataSource = bookingsInProgress;
            rptActiveBokings.DataBind();
        }

        private void loadProfilePhoto()
        {
            //falta validación si no encuentra la foto de perfil dentro de la carpeta
            if (CurrentEmployee.credentials.Photo != null)
            {
                ProfilePhoto = CurrentEmployee.credentials.Photo;
            }

            else
            {
                ProfilePhoto = "/pp.jpg";

            }

        }



        //----------------------------------         Eventos        --------------------------------------------------

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            panelHome.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            updatePanelGeneral.Update();

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            panelDashboard.CssClass = "";
            panelHome.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            updatePanelGeneral.Update();

        }

        protected void btnFlight_Click(object sender, EventArgs e)
        {
            panelFlight.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelHome.CssClass = "hidden";

            //updatePanelGeneral.Update();
            //ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

        }


        protected void Cancel_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();
            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Cancelada");
                ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }



        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();
            FlightBusiness fBusiness = new FlightBusiness();
            List<Booking> listBooking;
            Booking aux;


            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Aprobada");
                //Cuando se aprueba la reserva ya se genera el vuelo
                listBooking = (List<Booking>)Session["Bookings"];
                aux = listBooking.Find(x => x.IdBooking.Equals(int.Parse(IdBooking)));
                fBusiness.addFlight(aux);
                //////////////////////////////////////////////////////
                ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }

        }


        protected void ChangePhoto2_Click(object sender, EventArgs e)
        {

            if (fileUpload1.HasFile)
            {
                CredentialBusiness crBusiness = new CredentialBusiness();
                string extension = ObtenerExtension(fileUpload1);
                string fileName = Guid.NewGuid().ToString() + CurrentEmployee.Dni + "." + extension;
                string rutaCarpetaRaiz = Server.MapPath("~");
                string Folder = "/images/ProfileImagesEmployees/";
                string uploadFolder = rutaCarpetaRaiz + Folder;
                string filePath = Path.Combine(uploadFolder, fileName);

                try
                {
                    fileUpload1.SaveAs(filePath);
                    crBusiness.ChangePhoto(Folder + fileName, CurrentEmployee.credentials.IdCredential);
                    CurrentEmployee.credentials.Photo = Folder + fileName;
                    Session.Add("EmployeeLogged", CurrentEmployee);
                    ProfilePhoto = Folder + fileName;
                    //ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        }



        //----------------------------------         FUNCIONES       --------------------------------------------------
        public string ObtenerExtension(FileUpload fileUploadControl)
        {
            if (fileUploadControl.HasFile)
            {
                string fileName = fileUploadControl.FileName;
                string extension = Path.GetExtension(fileName);
                return extension.TrimStart('.').ToLower();  // Devuelve la extensión sin el punto y en minúsculas
            }
            else
            {
                return string.Empty;  // No hay archivo cargado
            }
        }

        private void updateBookingEmployeeSession()
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            List<Booking> Bookings;
           
            try
            {
                Bookings = bkBusiness.List();
                Session["Bookings"] = Bookings;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void updateFlightEmployeeSession()
        {
            FlightBusiness fBusiness = new FlightBusiness();
            List<Flight> flight;
            try
            {
                flight = fBusiness.List();
                Session["Flights"] = flight;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}