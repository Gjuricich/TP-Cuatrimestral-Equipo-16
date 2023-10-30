using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CabDominio;
using CabBusiness;

namespace CabWeb
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastname = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            DateTime dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            DateTime dateOfRegister = DateTime.Now;
            string g = txtGender.Text;
            char gender = g[0];
            Client newClient = new Client(name, lastname, email, dateOfRegister, dateOfBirth, gender);
            ClientBusiness clientManager = new ClientBusiness();
            clientManager.AddNewUser(newClient, password);
            string extension = Path.GetExtension(fileUploadProfilePicture.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;
            string rutaCarpetaRaiz = Server.MapPath("~");
            string uploadFolder = rutaCarpetaRaiz;
            string filePath = Path.Combine(uploadFolder, fileName);
            fileUploadProfilePicture.SaveAs(filePath);
            Response.Redirect("Login.aspx");
        }

    }
}