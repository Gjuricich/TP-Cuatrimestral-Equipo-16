using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CabWeb
{
    public partial class Cab : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["UserName"] != null)
            {
                if ((string)Session["UserName"] == "Maxi" && (string)Session["Password"] == "Programa")
                {
                    Label2.Text = "Maxi Programa";
                }
            }
        }
    }
}