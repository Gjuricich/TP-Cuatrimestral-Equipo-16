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

        protected void Page_Load(object sender, EventArgs e)
        {
                      
            bkBusiness = new BookingBusiness();
            CurrentClient = (Client)Session["ClientLogged"];            
            
            updateBookingEmployeeSession(CurrentClient.IdClient);
            updateFlightClientSession();
            loadProfile(CurrentClient);
            loadBookings();
            loadBookingsStatus();


            if (!IsPostBack)
            {
                
                loadCities();
                panelprofile.CssClass = "";
                panelBookings.CssClass = "hidden";
                panelRequestBooking.CssClass = "hidden";
                panelReservations.CssClass = "hidden";
                panelFlight.CssClass = "hidden";
                panelAddPassengers.CssClass = "hidden";
                panelDetail.CssClass = "hidden";
         
            }
            

        }

        private void loadProfile(Client CurrentClient)
        {
            loadProfilePhoto();
            txtName.Text = CurrentClient.Name;
            txtLastName.Text = CurrentClient.Surname;
            txtEmail.Text = CurrentClient.credentials.Email;
            txtCel.Text = CurrentClient.Cellphone.ToString();
            txtAdress.Text = CurrentClient.Address;
            txtGender.Text = CurrentClient.Gender.ToString();

        }

        private void loadBookings()
        {
            List<Booking> allBookings = (List<Booking>)Session["Bookings"];       
            List<Booking> bookings = allBookings.Where(booking => booking.StateBooking != "En proceso").ToList();
            List<Booking> bookingsInProgress = allBookings.Where(booking => booking.StateBooking == "En proceso").ToList();
            // Carga de rpt reservas en progreso(se pueden cancelar)
            rptActiveBokings.DataSource = bookingsInProgress;
            rptActiveBokings.DataBind();
            //Carga de rpt reservas ya aprobadas o canceladas          
            rptBokings.DataSource = bookings;
            rptBokings.DataBind();
        }


        private void loadBookingsStatus()
        {
            //lblAntiguedad.Text = "Antiguedad de la cuenta : " + AntiguedadDeLaCuenta(); 
            List<Booking> aux = (List<Booking>)Session["Bookings"];
            // lblVuelos.Text = "Cantidad de vuelos : " + CurrentClient.FlightHistory.Count().ToString();
            int aceptadas;
            aceptadas= aux.Count(booking => booking.StateBooking == "Aprobada");
            int Enproceso = aux.Count(booking => booking.StateBooking == "En proceso");
            llblAceptadas.Text = "Reservas Aceptadas : " + aceptadas.ToString();
            lblEnProceso.Text = "Reservas En Proceso : " + Enproceso.ToString();

        }
     

        private void loadProfilePhoto()
        {

            if (CurrentClient.credentials.Photo == null)
            {
                CurrentClient.credentials.Photo = "/pp.jpg";
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
                ddlcityOrigin.DataSource = cities;
                ddlcityOrigin.DataBind();
                ddlcityDestiny.DataSource = cities;
                ddlcityDestiny.DataBind();
            
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

        //----------------------------------         EVENTOS PANELES NAVEGACIÓN LATERAL       --------------------------------------------------


        protected void btnProfile_Click(object sender, EventArgs e)
        {
      
            panelprofile.CssClass = "";
            panelBookings.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelReservations.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelAddPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            UpdatePanelGeneral.Update();
        }

        protected void btnBookingInProgress_Click(object sender, EventArgs e)
        {
       
            panelBookings.CssClass = "";
            panelprofile.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelReservations.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelAddPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            ScriptManager.RegisterStartupScript(UpdatePanelGeneral, UpdatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + UpdatePanelGeneral.ClientID + "', '');", true);

        }

        protected void btnBooking_Click(object sender, EventArgs e)
        {

            panelReservations.CssClass = "";
            panelprofile.CssClass = "hidden";
            panelBookings.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelAddPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            ScriptManager.RegisterStartupScript(UpdatePanelGeneral, UpdatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + UpdatePanelGeneral.ClientID + "', '');", true);
        }

        protected void btnAddBooking_Click(object sender, EventArgs e)
        {
            panelRequestBooking.CssClass = "";
            panelprofile.CssClass = "hidden";
            panelBookings.CssClass = "hidden";          
            panelReservations.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelAddPassengers.CssClass = "hidden";
            panelDetail.CssClass = "hidden";

        }

        protected void btnFlight_Click(object sender, EventArgs e)
        {

             //List<Flight> ClientFlights = (List<Flight>)Session["FlightsClient"];
            repeaterFlight.DataSource = (List<Flight>)Session["FlightsClient"];
            repeaterFlight.DataBind();



            panelAddPassengers.CssClass = "hidden";
            panelprofile.CssClass = "hidden";
            panelBookings.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelReservations.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
            panelFlight.CssClass = "";



            //updatePanelGeneral.Update();
            //ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

        }

        // --------------------------------------------------------- EVENTO PANEL AGREGAR  PASAJERO -----------------------------------------------------------


        protected void btnAddPassenger_Click(object sender, EventArgs e)
        {
            FlightPassenger flightPassenger = new FlightPassenger();
            FlightPassengerBusiness fpBusiness = new FlightPassengerBusiness();
            string IdFlight = (string)Session["IdFlightAddP"];
            flightPassenger.Name = txtNameP.Text;
            flightPassenger.Surname = txtLastNameP.Text;
            flightPassenger.Dni = txtDNIP.Text;
            flightPassenger.Gender = Convert.ToChar(txtGenderP.Text);
            flightPassenger.IdFlight = int.Parse(IdFlight);
            flightPassenger.Cellphone = txtcellphone.Text;

            try
            {
                fpBusiness.addPassenger(flightPassenger);
                
                panelDetail.CssClass = "";
                panelAddPassengers.CssClass = "hidden";

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void btnaddPassengerPanel_Click(object sender, EventArgs e)
        {
            string IdFlight = ((LinkButton)sender).CommandArgument;
            Session["IdFlightAddP"] = IdFlight;
            panelAddPassengers.CssClass = "";
            panelprofile.CssClass = "hidden";
            panelBookings.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelReservations.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            panelDetail.CssClass = "hidden";
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {


            string IdFlight = ((LinkButton)sender).CommandArgument;
            FlightPassengerBusiness fpBusiness = new FlightPassengerBusiness();     
            List<Flight> allFlights = (List<Flight>)Session["FlightsClient"];
            Flight CurrentFlight = allFlights.Find(Flights => Flights.ID_Flight == int.Parse(IdFlight));
            CurrentFlight.Passengers = fpBusiness.List(CurrentFlight.ID_Flight);
            Session["CurrentFlight"] = CurrentFlight;
            rptCurrentFlightPassengers.DataSource = CurrentFlight.Passengers;
            rptCurrentFlightPassengers.DataBind();


            panelDetail.CssClass = "";
            panelAddPassengers.CssClass = "hidden";
            panelprofile.CssClass = "hidden";
            panelBookings.CssClass = "hidden";
            panelRequestBooking.CssClass = "hidden";
            panelReservations.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
        }

        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {

            ClientBusiness cBusiness = new ClientBusiness();
            cBusiness.deleteClientOfBooking(CurrentClient.IdClient);
            cBusiness.deleteClient(CurrentClient.IdClient, CurrentClient.IdPerson, CurrentClient.Dni);
            var master = this.Master as Cab;
            if (master != null)
            {
                master.Logout_Click(sender, e);
            }

            //Response.Redirect("Default.aspx");

        }





        // --------------------------------------------------------- PANEL MOSTRAR DATOS DE VUELO -----------------------------------------------------------

        protected void Cancel_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();     
            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Cancelada");
                ScriptManager.RegisterStartupScript(UpdatePanelGeneral, UpdatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + UpdatePanelGeneral.ClientID + "', '');", true);


                // Session["Bookings"] = Bookings;
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }



        }
        
        protected void Bookflight_Click(object sender, EventArgs e)
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            CityBusiness ctBusiness = new CityBusiness();
            Booking booking = new Booking();
            string fechaSeleccionadaText = TxbDatePicked.Text;
             if (TxbDatePicked.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Por favor, seleccione una fecha.');", true);
                return;
            }
            fechaSeleccionadaText.Replace('-', '/');
            string horaSeleccionadaText = TxbTimePicked.Text;
            if (TxbTimePicked.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Por favor, seleccione una hora.');", true);
                return;
            }
            string fechayhora = fechaSeleccionadaText + " " + horaSeleccionadaText;
            DateTime fechaSeleccionada = DateTime.ParseExact(fechayhora, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            TimeSpan anticipacion = fechaSeleccionada - DateTime.Now;
            if (anticipacion.TotalDays < 5)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('La reserva debe realizarse con al menos 5 días de anticipación.');", true);
                return; 
            }
            int capacidadMaxima = 12;
            short pasajeros;
            if (!short.TryParse(passengerInput.Value, out pasajeros) || pasajeros < 1 || pasajeros > capacidadMaxima)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('La cantidad de pasajeros debe ser un número entre 1 y " + capacidadMaxima + ".');", true);
                return;
            }
            booking.DateBooking = fechaSeleccionada;
            if (ctBusiness.GetCityByName(ddlcityDestiny.SelectedValue).IdCity == ctBusiness.GetCityByName(ddlcityOrigin.SelectedValue).IdCity)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('El destino no puede ser el mismo que el origen.');", true);
                return;
            }
            booking.Destination = ctBusiness.GetCityByName(ddlcityDestiny.SelectedValue);
            booking.Origin = ctBusiness.GetCityByName(ddlcityOrigin.SelectedValue);
            booking.Passengers= pasajeros;
            booking.IdClient = CurrentClient.IdClient;
            booking.StateBooking = "En proceso";
            booking.State = true;
            bkBusiness.addBooking(booking);
            Response.Redirect("~/ClientView.aspx");
        }

        protected void ChangePhotoClient_Click(object sender, EventArgs e)
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

                try
                {

                    fileUpload1.SaveAs(filePath);
                    crBusiness.ChangePhoto(Folder + fileName, CurrentClient.credentials.IdCredential);
                    CurrentClient.credentials.Photo = Folder + fileName;
                    Session.Add("ClientLogged", CurrentClient);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
        

        //----------------------------------         Funciones        --------------------------------------------------

        private void updateBookingEmployeeSession(int IdClient)
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            List<Booking> Bookings;

            try
            {
                Bookings = bkBusiness.ListByClient(IdClient);
                Session["Bookings"] = Bookings;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void updateFlightClientSession()
        {
            FlightBusiness fBusiness = new FlightBusiness();
            List<Flight> flight;
            try
            {
                flight = fBusiness.ListByClient(CurrentClient.IdClient);
                Session["FlightsClient"] = flight;

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

        protected void btnEditClientProfile_Click(object sender, EventArgs e)
        {

        }
    }
}