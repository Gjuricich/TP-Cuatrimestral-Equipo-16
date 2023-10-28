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

                Client client = (Client)Session["UserLogged"];
                Label2.Text = client.Name + " " + client.LastName;
  
            }
        }
      
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserLogged");
            Label2.Text = "";

        }
    }
}