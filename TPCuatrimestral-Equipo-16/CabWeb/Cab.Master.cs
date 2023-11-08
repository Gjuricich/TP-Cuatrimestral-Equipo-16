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
            if ((Client)Session["UserLogged"] != null)
            {

                //Credential credential = (Credential)Session["UserLogged"];
                //Label2.Text = credential.Rol;
                Client client= (Client)Session["UserLogged"];
                Label2.Text = client.Name + " " + client.Surname;

            }
            else if ((Employee)Session["UserLogged"] != null)
            {
                Employee employee = (Employee)Session["UserLogged"];
                Label2.Text = employee.Name + " " + employee.Surname;
            }
        }
      
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserLogged");
            Label2.Text = "";
            Response.Redirect("~/Default.aspx");

        }
    }
}