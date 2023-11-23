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
                if (txtName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your name.');", true);
                    return;
                }
                newClient.Surname = txtLastName.Text;
                if (txtLastName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your surname.');", true);
                    return;
                }
                newClient.Dni = txtDni.Text;
                if (string.IsNullOrWhiteSpace(newClient.Dni))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your DNI.');", true);
                    return;
                }
                newClient.credentials.Email = txtEmail.Text;
                if (txtEmail.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your email adress. Example: example@gmail.com');", true);
                    return;
                }
                newClient.Cellphone = txtCel.Text;
                if (string.IsNullOrWhiteSpace(txtCel.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your cellphone');", true);
                    return;
                }
                string password = txtPassword.Text;
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your password');", true);
                    return;
                }
                newClient.Address = txtAddress.Text;
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Please enter your adress');", true);
                    return;
                }

                newClient.Gender = Convert.ToChar(txtGender.Text);
                newClient.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                newClient.DateOfRegister = DateTime.Now;

                if (fileUploadProfilePicture.HasFile)
                {
                    string extension = Path.GetExtension(fileUploadProfilePicture.FileName);
                    string fileName = Guid.NewGuid().ToString() + newClient.Dni + extension;
                    string rutaCarpetaRaiz = Server.MapPath("~");
                    string Folder = "/images/ProfileImagesClients/";
                    string uploadFolder = rutaCarpetaRaiz + Folder;
                    string filePath = Path.Combine(uploadFolder, fileName);
                    fileUploadProfilePicture.SaveAs(filePath);
                    newClient.credentials.Photo = Folder + fileName;
                    cBusiness.AddNewUserDB(newClient, password,newClient.credentials.Photo);
                }
                else
                {
                    newClient.credentials.Photo = "/pp.jpg";
                    cBusiness.AddNewUserDB(newClient, password, newClient.credentials.Photo);
                }
              
                Session.Add("ClientLogged", newClient);

                Response.Redirect("ClientView.aspx");
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