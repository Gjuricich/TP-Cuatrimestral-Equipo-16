using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CabDominio;

namespace CabWeb
{
    public partial class SignUpEmployee : System.Web.UI.Page
    {
        public Employee CurrentEmployee;
        public int CurrentContent = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentEmployee = (Employee)Session["EmployeeLogged"];
        }


        protected void btnSignUpEmployee_Click(object sender, EventArgs e)
        {
   
        }

    }
}