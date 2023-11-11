using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CabDominio;

namespace CabWeb
{
    public partial class UserProfile : System.Web.UI.Page
    {
        public Client CurrentClient;
        public int CurrentContent = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentClient = (Client)Session["ClientLogged"];
        }
    }
}