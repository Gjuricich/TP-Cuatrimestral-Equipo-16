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
            CredentialBusiness credBusiness = new CredentialBusiness();
            ClientBusiness cManager = new ClientBusiness();
            PersonBusiness pBusiness = new PersonBusiness();
            EmployeeBusiness eBusiness = new EmployeeBusiness();
            Person person;


            if (credBusiness.VerificarCredenciales(email, password))
            {
                Credential credential = credBusiness.GetUserByEmail(email);

                if (credential.Rol == "Client")
                {
                    person = pBusiness.GetPersonById(credential.IdCredential);
                    Client aux = cManager.GetClientById(credential.IdCredential);
                    Client client = new Client
                    {
                        Name = person.Name,
                        Surname = person.Surname,
                        Gender = person.Gender,
                        Dni = person.Dni,
                        Address = person.Address,
                        Cellphone = person.Cellphone,
                        DateOfBirth = person.DateOfBirth,
                        IdClient = aux.IdClient,
                        DateOfRegister = aux.DateOfRegister,
                        State = aux.State,
                        credentials = credential,
                    };

                 
                    Session.Add("ClientLogged", client);
                    Response.Redirect("ClientView.aspx");
                }
                else if (credential.Rol == "Employee")
                {
                    person = pBusiness.GetPersonById(credential.IdCredential);
                    Employee aux = eBusiness.GetEmployeeById(credential.IdCredential);
                    Employee employee = new Employee
                    {
                        Name = person.Name,
                        Surname = person.Surname,
                        Gender = person.Gender,
                        Dni = person.Dni,
                        Address = person.Address,
                        Cellphone = person.Cellphone,
                        DateOfBirth = person.DateOfBirth,
                        IdEmployee = aux.IdEmployee,
                        JoinDate = aux.JoinDate,
                        State = aux.State,
                        credentials = credential,
                    };
                    Session.Add("EmployeeLogged", employee);
                    Response.Redirect("EmployeeView.aspx");
                }
                //var masterPage = this.Master;
                //var lblHeader = masterPage.FindControl("Label2") as Label;
                //lblHeader.Text = client.Name+" "+client.LastName;

            }
            else
            {
                string script = @"
                    <script type='text/javascript'>
                        document.addEventListener('DOMContentLoaded', function () {
                            var myModal = new bootstrap.Modal(document.getElementById('errorMessage'));
                            myModal.show();
                        
                            setTimeout(function () {
                                            myModal.hide();
                                        }, 2000);

                        });
                    </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "showModal", script, false);

                //Response.Redirect("Login.aspx");
            }
        }
        protected void btnRedirect_Click(object sender, EventArgs e)
        {

            Response.Redirect("Default.aspx");
        }

 
        /*
        public Client loadCliente(Credential credential)
        {


        }

        */
    }
}