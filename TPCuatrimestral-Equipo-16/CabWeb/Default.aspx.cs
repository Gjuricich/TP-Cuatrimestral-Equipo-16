using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabDominio;
using CabBusiness;
using System.IO;

namespace CabWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Aircraft> aircrafts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AircraftBusiness AcBusiness = new AircraftBusiness();
                aircrafts = new List<Aircraft>();
                aircrafts = AcBusiness.List();
                Session["Aircrafts"] = AcBusiness;

            }


        }
        public string PhotoByModel( string textoABuscar)
        {

           
            string ruta = "/images/Aviones/"+ textoABuscar+".jpeg";

            return ruta;
            
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