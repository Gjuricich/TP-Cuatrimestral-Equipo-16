using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabDominio;

namespace CabWeb
{
    public partial class Cab : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Client)Session["ClientLogged"] != null)
            {
                Client client= (Client)Session["ClientLogged"];
                Label2.Text = client.Name + " " + client.Surname;
            }
            else if ((Employee)Session["EmployeeLogged"] != null)
            {
                Employee employee = (Employee)Session["EmployeeLogged"];
                Label2.Text = employee.Name + " " + employee.Surname;
            }
        }
      
        protected void Logout_Click(object sender, EventArgs e)
        {
            if ((Client)Session["ClientLogged"] != null)
            {
                Session.Remove("ClientLogged");
                Session.Remove("Bookings");


            }
            else if ((Employee)Session["EmployeeLogged"] != null)
            {
                Session.Remove("EmployeeLogged");
                Session.Remove("Bookings");
                Session.Remove("Flights");
            }
            Label2.Text = "";
            Response.Redirect("~/Default.aspx");
        }
    }
}