using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CabWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void liveAlertBtn_Click(object sender, EventArgs e)
        {
            string userName = Username.Text;
            string password = Password.Text;
            Session["UserName"] = userName;
            Session["Password"] = password;
            Response.Redirect("Login.aspx");

        }
        protected void btnRedirect_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");
        }
        protected void retryLogtBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Session.Remove("Password");
            var masterPage = this.Master;
            var lblHeader = masterPage.FindControl("Label2") as Label;
            lblHeader.Text = "";

        }

    }
}