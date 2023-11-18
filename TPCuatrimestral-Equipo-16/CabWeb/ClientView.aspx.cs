using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using CabBusiness;
using CabDominio;

namespace CabWeb
{
    public partial class ClientView : System.Web.UI.Page
    {
        public Client CurrentClient;
        public List<Booking> ActiveBookingsOfClient;
        public int CurrentContent = 0;
        public BookingBusiness bkBusiness;
        public string ProfilePhoto;
        protected void Page_Load(object sender, EventArgs e)
        {
                      
            bkBusiness = new BookingBusiness();
            CurrentClient = (Client)Session["ClientLogged"];
            addBookingClientSession(CurrentClient.IdClient);
       

            //Carga de la página

            loadCities();
            loadProfilePhoto();
            loadBookings();
            loadBookingsStatus();
            loadProfile(CurrentClient);

      


        }

        private void loadProfile(Client CurrentClient)
        {
            txtName.Text = CurrentClient.Name;
            txtLastName.Text = CurrentClient.Surname;
            txtEmail.Text = CurrentClient.credentials.Email;
            txtCel.Text = CurrentClient.Cellphone.ToString();
            txtAdress.Text = CurrentClient.Address;
            txtGender.Text = CurrentClient.Gender.ToString();

        }

        private void loadBookings()
        {
            //Carga de rpt reservas en progreso(se pueden cancelar)
            rptActiveBokings.DataSource = (List<Booking>)Session["ClientBookingsInProgress"];
            rptActiveBokings.DataBind();
            //Carga de rpt reservas ya aprobadas o canceladas          
            rptBokings.DataSource = (List<Booking>)Session["ClientBookings"];
            rptBokings.DataBind();
        }

        private void loadBookingsStatus()
        {
            //lblAntiguedad.Text = "Antiguedad de la cuenta : " + AntiguedadDeLaCuenta(); 
            List<Booking> aux = (List<Booking>)Session["ClientBookingsInProgress"];
            List<Booking> aux1 = (List<Booking>)Session["ClientBookings"];          
            lblVuelos.Text = "Cantidad de vuelos : " + CurrentClient.FlightHistory.Count().ToString();
            llblAceptadas.Text = "Reservas Aceptadas : " + aux1.Count(booking => booking.StateBooking == "Aceptada").ToString();
            lblEnProceso.Text = "Reservas En Proceso : " + aux.Count().ToString();

        }

        private void loadProfilePhoto()
        {

            if (CurrentClient.credentials.Photo != null)
            {
                ProfilePhoto = CurrentClient.credentials.Photo;
            }

            else
            {
                ProfilePhoto = "/pp.jpg";

            }
        }
        private void loadCities()
        {
            CityBusiness ctBusiness = new CityBusiness();
            List<string> cities = new List<string>();
            for (int x = 0; x < ctBusiness.List().Count(); x++)
            {
                cities.Add(ctBusiness.List()[x].NameCity);
            }
            if (!IsPostBack)
            {
                ddlcityOrigin.DataSource = cities;
                ddlcityOrigin.DataBind();
                ddlcityDestiny.DataSource = cities;
                ddlcityDestiny.DataBind();
            }
        }
        protected void ddlcityOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlcityOrigin.SelectedValue;
            ddlcityOrigin.SelectedValue = selectedValue;
        }
        protected void ddlcityDestiny_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlcityDestiny.SelectedValue;
            ddlcityDestiny.SelectedValue = selectedValue;
        }

        //----------------------------------         Eventos        --------------------------------------------------

        protected void Cancel_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();
      

            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Cancelada");
                


            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }



        }
        protected void linkButtonUser_Click(object sender, EventArgs e)
        {
            CurrentContent = 0;
        }
        protected void linkButton1_Click(object sender, EventArgs e)
        {
            CurrentContent = 1;
        }
        protected void linkButton2_Click(object sender, EventArgs e)
        {
            CurrentContent = 2;
        }
        protected void linkButton3_Click(object sender, EventArgs e)
        {
            CurrentContent = 3;
        }
        protected void linkButton4_Click(object sender, EventArgs e)
        {
            CurrentContent = 4;
        }
        protected void Bookings_Click(object sender, EventArgs e)
        {
            CurrentContent = 5;
        }

        protected void Bookflight_Click(object sender, EventArgs e)
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            CityBusiness ctBusiness = new CityBusiness();
            Booking booking = new Booking();
            string fechaSeleccionadaText = TxbDatePicked.Text;
            fechaSeleccionadaText.Replace('-', '/');
            string horaSeleccionadaText = TxbTimePicked.Text;
            string fechayhora = fechaSeleccionadaText + " " + horaSeleccionadaText;
            DateTime fechaSeleccionada = DateTime.ParseExact(fechayhora, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            booking.DateBooking = fechaSeleccionada;
            booking.Destination = ctBusiness.GetCityByName(ddlcityDestiny.SelectedValue);
            booking.Origin = ctBusiness.GetCityByName(ddlcityOrigin.SelectedValue);
            short Pasajeros;
            short.TryParse(passengerInput.Value,out Pasajeros);
            booking.Passengers= Pasajeros;
            booking.IdClient = CurrentClient.IdClient;
            booking.StateBooking = "En proceso";
            booking.State = true;
            bkBusiness.addBooking(booking);
            Response.Redirect("~/ClientView.aspx");
        }
       
        protected void ChangePhoto2_Click(object sender, EventArgs e)
        {
            if (fileUpload1.HasFile)
            {
                CredentialBusiness crBusiness = new CredentialBusiness();
                string extension = ObtenerExtension(fileUpload1);
                string fileName = Guid.NewGuid().ToString() + CurrentClient.Dni + "." + extension;
                string rutaCarpetaRaiz = Server.MapPath("~");
                string Folder = "/images/ProfileImagesClients/";
                string uploadFolder = rutaCarpetaRaiz + Folder;
                string filePath = Path.Combine(uploadFolder, fileName);
                fileUpload1.SaveAs(filePath);
                crBusiness.ChangePhoto(Folder + fileName, CurrentClient.credentials.IdCredential);
                ProfilePhoto= Folder + fileName;
            }

        }


        //----------------------------------         Funciones        --------------------------------------------------


        private void addBookingClientSession(int IdClient)
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            List<Booking> ClientBookingsInProgress;
            List<Booking> ClientBookings;

            try
            {

                ClientBookingsInProgress = bkBusiness.BookingInProgressClient(IdClient);
                ClientBookings = bkBusiness.BookingClient(IdClient);
                Session["ClientBookingsInProgress"] = ClientBookingsInProgress;
                Session["ClientBookings"] = ClientBookings;


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }





        public string ObtenerExtension(FileUpload fileUploadControl)
        {
            if (fileUploadControl.HasFile)
            {
                string fileName = fileUploadControl.FileName;
                string extension = Path.GetExtension(fileName);
                return extension.TrimStart('.').ToLower(); 
            }
            else
            {
                return string.Empty; 
            }
        }
        public int  CantidadDeReservasEnProceso()
        {

            int countEnProceso = ActiveBookingsOfClient.Count(booking => booking.StateBooking == "En proceso");
            return countEnProceso;
        }
        public int CantidadDeReservasAceptadas()
        {
            int Aceptadas = ActiveBookingsOfClient.Count(booking => booking.StateBooking == "Aceptada");
            return Aceptadas;
        }

        public string AntiguedadDeLaCuenta()
        {
            DateTime fechaInicial = CurrentClient.DateOfRegister;
            DateTime fechaFinal = DateTime.Now;

            TimeSpan diferencia = fechaFinal - fechaInicial;

            int diferenciaEnAnios = (int)(diferencia.TotalDays / 365.25);
            int diferenciaEnMeses = (int)(diferencia.TotalDays / 30.44); // Aproximadamente 30.44 días por mes
            int diferenciaEnDias = (int)diferencia.TotalDays;

            if (diferenciaEnAnios > 0)
            {
                return diferenciaEnAnios + "años";
            }
            else if (diferenciaEnMeses > 0 && diferenciaEnAnios == 0)
            {
                return diferenciaEnMeses + "Meses";
            }
            else if (diferenciaEnDias > 0 && diferenciaEnMeses == 0 && diferenciaEnAnios == 0)
            {
                return diferenciaEnDias + "Dias";
            }
            else
            {
                return " 1 Dia";
            }
        }

    }
}