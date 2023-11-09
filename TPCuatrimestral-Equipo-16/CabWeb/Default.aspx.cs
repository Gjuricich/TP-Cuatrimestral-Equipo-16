using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabDominio;

namespace CabWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //if ((Client)Session["ClientLogged"] != null)
            //{
            //    Response.Redirect("~/ClientView.aspx");
            //}
            //else if ((Employee)Session["EmployeeLogged"] != null)
            //{
            //    Session.Remove("EmployeeLogged");
            //}
         
            if((Client)Session["ClientLogged"] == null && (Employee)Session["EmployeeLogged"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
              
                    
                   
          
        }
    
    }
}