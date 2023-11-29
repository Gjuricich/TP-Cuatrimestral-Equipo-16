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

        protected void Page_Load(object sender, EventArgs e)
        {

            CurrentEmployee = (Employee)Session["EmployeeLogged"];

            updateBookingEmployeeSession();
            updateFlightEmployeeSession();
            loadBookings();
            loadFlights();
            if (!IsPostBack)
            {
                loadProfile(CurrentEmployee);
                panelHome.CssClass = "";             
                panelDashboard.CssClass = "hidden";
                panelFlight.CssClass = "hidden";
                panelDetail.CssClass = "hidden";
                panelEditCrew.CssClass = "hidden";
                panelEditItinerary.CssClass = "hidden";
                panelEditPassengers.CssClass = "hidden";
           

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
            List<Flight> allFlights = (List<Flight>)Session["Flights"];
            List<Flight> FlightsInProgress = allFlights.Where(Flights => Flights.Status == true).ToList();
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
            if (CurrentEmployee.credentials.Photo == null)
            {
               CurrentEmployee.credentials.Photo= "/pp.jpg";
            }

        }



   //-------------------------------------------         Eventos             -------------------------------------------------------------------


        //----------------------------------       Botones navegación lateral       --------------------------------------------------
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            panelHome.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "hidden";
         
            updatePanelGeneral.Update();

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            panelDashboard.CssClass = "";
            panelHome.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "hidden";
           
            ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

        }

        protected void btnFlight_Click(object sender, EventArgs e)
        {
            panelFlight.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "hidden";




            //updatePanelGeneral.Update();
            //ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
           
            Employee aux = (Employee)Session["EmployeeLogged"];
            PersonBusiness pBusiness = new PersonBusiness();
            aux.Name = txtName.Text;
            aux.Surname = txtLastName.Text;
            aux.Address = txtAdress.Text;
            aux.Cellphone = txtCel.Text;
            aux.Gender = Convert.ToChar(txtGender.Text);
            Session["EmployeeLogged"] = aux;
            pBusiness.editPerson(aux);

            ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

        }

        //----------------------------------       Botones flight  Detail + edits + delete     --------------------------------------------------

        protected void btnEditItinerary_Click(object sender, EventArgs e)
        {
            panelHome.CssClass =  "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass =  "hidden";
            panelEditItinerary.CssClass = "";
            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
  
        }

        protected void btnEditPassengers_Click(object sender, EventArgs e)
        {
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "";
            panelDetail.CssClass = "hidden";
  

        }

        protected void btnEditCrew_Click(object sender, EventArgs e)
        {
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass = "";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";


        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            FlightPassengerBusiness fpBusiness = new FlightPassengerBusiness();
            FlightCrewBusiness  fcBusiness = new FlightCrewBusiness();

            try
            {
                string IdFlight = ((LinkButton)sender).CommandArgument;
                Session["IdFlight"] = int.Parse(IdFlight); //recordar modificAR ADD PASAJERO PARA TOMAR EL ID DEL OBJETO
                

                //Load pasajeros
                List<Flight> allFlights = (List<Flight>)Session["Flights"];
                Flight CurrentFlight = allFlights.Find(Flights => Flights.ID_Flight == int.Parse(IdFlight));
                CurrentFlight.Passengers = fpBusiness.List(CurrentFlight.ID_Flight);
                CurrentFlight.crew = fcBusiness.List(CurrentFlight.ID_Flight);
                Session["CurrentFlight"] = CurrentFlight;

                //cargamos los pasajeros en detail
                rptCurrentFlightPassengers.DataSource = CurrentFlight.Passengers;
                rptCurrentFlightPassengers.DataBind();

                //cargamos los empleados
                rptFlightEmployee.DataSource = CurrentFlight.crew;
                rptFlightEmployee.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            panelDetail.CssClass = "";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            panelEditPassengers.CssClass = "hidden";
   



        }

        protected void btnEditPassenger_Click(object sender, EventArgs e)
        {
            string IdPerson = ((LinkButton)sender).CommandArgument;
            Session["IdPerson"] = int.Parse(IdPerson);
            Flight aux = (Flight)Session["CurrentFlight"];
            FlightPassenger passenger  = aux.Passengers.Find(passengers=> passengers.IdPerson == int.Parse(IdPerson));

            txtNameP.Text = passenger.Name;
            txtLastNameP.Text = passenger.Surname;
            txtDNIP.Text = passenger.Dni;
            txtGenderP.Text = passenger.Gender.ToString();

   

            panelEditPassengers.CssClass = "";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
         

        }

        protected void BtnUpdatePassenger_Click(object sender, EventArgs e)
        {
            PersonBusiness pBusiness = new PersonBusiness();
            int IdPerson = (int)Session["IdPerson"];
            Flight aux = (Flight)Session["CurrentFlight"];
            FlightPassenger passenger = aux.Passengers.Find(passengers => passengers.IdPerson == IdPerson);

            passenger.Name = txtNameP.Text;
            passenger.Surname = txtLastNameP.Text;
            passenger.Dni = txtDNIP.Text;
            passenger.Gender = txtGender.Text[0]; 

            pBusiness.UpdatePassengerToPerson(passenger);

            Session.Remove("CurrentFlight");


            //volvemos a flight porque aun no pude resolver el post back
            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
        


        }

        protected void btnDeletePassenger_Click(object sender, EventArgs e)
        {
            string IdPerson = ((LinkButton)sender).CommandArgument;
            Flight aux = (Flight)Session["CurrentFlight"];
            FlightPassenger passenger = aux.Passengers.Find(Flights => Flights.IdPerson == int.Parse(IdPerson));
            FlightPassengerBusiness fpBusiness = new FlightPassengerBusiness();
            fpBusiness.deletePassenger(passenger);

            updateFlightEmployeeSession();

            Session.Remove("CurrentFlight");

            //volvemos a flight porque aun no pude resolver el post back
            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
           



        }

        protected void btnDeleteEmployeeFlight_Click(object sender, EventArgs e)
        {

            FlightCrewBusiness fcBusiness = new FlightCrewBusiness();
            string IdEmployee = ((LinkButton)sender).CommandArgument;
            fcBusiness.deleteCrewMember(int.Parse(IdEmployee));
            Session.Remove("CurrentFlight");


            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";
            
        }

        protected void btnAddcreW_Click(object sender, EventArgs e)
        {

            FlightCrewBusiness fcBusiness = new FlightCrewBusiness();
            string IdEmployee = ((LinkButton)sender).CommandArgument;
            fcBusiness.addCrewMember(int.Parse(IdEmployee),(int)Session["IdFlight"]);

            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "";
            panelEditCrew.CssClass = "hidden";
            panelEditItinerary.CssClass = "hidden";



        }





        protected void btnAvaibleCrew_Click(object sender, EventArgs e)
        {


            FlightCrewBusiness fcBusiness = new FlightCrewBusiness();

            //cargo tripulacion al vuelo
            rptEditEmployees.DataSource = fcBusiness.List();
            rptEditEmployees.DataBind();

            
            panelEditPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelEditCrew.CssClass = "";
            panelEditItinerary.CssClass = "hidden";
        
            

        }



        //----------------------------------       Botones CANCELAR - APROBAR  RESERVA      --------------------------------------------------

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

        //----------------------------------       cCAMBIAR FOTO      --------------------------------------------------
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