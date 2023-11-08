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
            Client newClient = new Client();
            ClientBusiness cBusiness = new ClientBusiness();

            try
            {
                newClient.Name = txtName.Text;
                newClient.Surname = txtLastName.Text;
                newClient.Dni = txtDni.Text;
                newClient.credentials.Email = txtEmail.Text;
                newClient.Gender = Convert.ToChar(txtGender.Text);
                newClient.Cellphone = txtCel.Text;
                newClient.DateOfRegister = DateTime.Now;
                newClient.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                string password = txtPassword.Text;
                cBusiness.AddNewUserDB(newClient, password);

                
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                //aca tenemos que manejar la excepcion e  informar al usuario que 
                // el mail o el celular o el dni ya se encuentran asignados a un usuario
                // borrar esos campos y darle posibilidad de volver a registrarse
                throw ex;
            }
        
            
        
           
        


            /*
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
            */
        }

    }
}