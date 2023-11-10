using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public int CurrentContent = 0;
        public List<Booking> ActiveBookingsOfClient;
        public BookingBusiness bkBusiness = new BookingBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            bkBusiness = new BookingBusiness();
            CurrentClient = (Client)Session["ClientLogged"];
            ActiveBookingsOfClient = new List<Booking>();
            CityBusiness ctBusiness = new CityBusiness();
            List<string> cities = new List<string>();
            for (int x = 0; x < ctBusiness.List().Count();x++)
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
            ActiveBookingsOfClient = bkBusiness.ListByClient(CurrentClient);
            rptActiveBokings.DataSource = ActiveBookingsOfClient;
            rptActiveBokings.DataBind();
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
        }

       
    }
}