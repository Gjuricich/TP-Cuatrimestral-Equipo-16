using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabDominio;
using CabBusiness;

namespace CabWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void liveAlertBtn_Click(object sender, EventArgs e)
        {

            string email = txtMail.Text;
            string password = txtPassword.Text;
            ClientBusiness cManager = new ClientBusiness();


            if (cManager.VerificarCredenciales(email, password))
            {
                Client client = cManager.GetUserByEmail(email);
                Session.Add("UserLogged", client);
                //var masterPage = this.Master;
                //var lblHeader = masterPage.FindControl("Label2") as Label;
                //lblHeader.Text = client.Name+" "+client.LastName;
                Response.Redirect("ClientView.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnRedirect_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");
        }
      

    }
}