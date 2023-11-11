using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabBusiness;
using CabDominio;

namespace CabWeb
{
    public partial class EmployeeView : System.Web.UI.Page
    {
        public Employee CurrentEmployee;
        public BookingBusiness bkBusiness = new BookingBusiness();
        public int CurrentContent = 0;
        List<Booking> RecivedReservations;
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdatePanel1.ChildrenAsTriggers = true;
            bkBusiness = new BookingBusiness();
            RecivedReservations = new List<Booking>();
            CurrentEmployee = (Employee)Session["EmployeeLogged"];
            RecivedReservations = bkBusiness.List();
            rptActiveBokings.DataSource = RecivedReservations;
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

        protected void ChangeStatebooking_Click(object sender, EventArgs e)
        {
            bkBusiness = new BookingBusiness();
            Button btn = (Button)sender;
            string idbok = btn.CommandArgument;
            int IdBooking = int.Parse(idbok);
            bkBusiness.ChangeStateBooking(IdBooking);

        }
        protected void ChangeStatebooking2_Click(object sender, EventArgs e)
        {
            bkBusiness = new BookingBusiness();
            LinkButton btn = (LinkButton)sender;
            string idbok = btn.CommandArgument;
            int IdBooking = int.Parse(idbok);
            bkBusiness.ChangeStateBooking(IdBooking);

        }


    }
}