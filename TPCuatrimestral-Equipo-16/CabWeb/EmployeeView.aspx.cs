using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using CabBusiness;
using CabDominio;

namespace CabWeb
{
    public partial class EmployeeView : System.Web.UI.Page
    {
        public Employee CurrentEmployee;
        public int CurrentContent = 0;  
        public string ProfilePhoto;
        protected void Page_Load(object sender, EventArgs e)
        {
                                       
            CurrentEmployee = (Employee)Session["EmployeeLogged"];
            updateBookingEmployeeSession();
            loadProfile(CurrentEmployee);
            loadProfilePhoto();
            loadBookings();
    
        }

       

        private void loadProfile(Employee CurrentEmployee)
        {
            txtName.Text = CurrentEmployee.Name;
            txtLastName.Text = CurrentEmployee.Surname;
            txtEmail.Text = CurrentEmployee.credentials.Email;
            txtCel.Text = CurrentEmployee.Cellphone.ToString();
            txtAdress.Text = CurrentEmployee.Address;
            txtGender.Text = CurrentEmployee.Gender.ToString();

        }

        private void loadBookings()
        {
            rptActiveBokings.DataSource = (List<Booking>)Session["BookingsInProgress"];
            rptActiveBokings.DataBind();
        }

        private void loadProfilePhoto()
        {
            CredentialBusiness crBusiness = new CredentialBusiness();
            if (crBusiness.getPhoto(CurrentEmployee.credentials.IdCredential) != null)
            {
                ProfilePhoto = crBusiness.getPhoto(CurrentEmployee.credentials.IdCredential);
            }

            else
            {
                ProfilePhoto = "/pp.jpg";

            }
        }
   


        //----------------------------------         Eventos        --------------------------------------------------

        protected void Cancel_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();


            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Cancelada");



            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }



        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();


            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Aprobada");



            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }



        }
        protected void linkButtonUser_Click(object sender, EventArgs e)
        {
            CurrentContent = 0;
        }
        protected void linkButton1_Click(object sender, EventArgs e)
        {
            CurrentContent = 1;
        }
        protected void linkButton2_Click(object sender, EventArgs e)
        {
            CurrentContent = 2;
        }
        protected void linkButton3_Click(object sender, EventArgs e)
        {
            CurrentContent = 3;
        }
        protected void linkButton4_Click(object sender, EventArgs e)
        {
            CurrentContent = 4;
        }
        protected void Bookings_Click(object sender, EventArgs e)
        {
            CurrentContent = 5;
        }

        
        protected void ChangePhoto2_Click(object sender, EventArgs e)
        {
            if (fileUploadProfilePicture.HasFile)
            {
                CredentialBusiness crBusiness = new CredentialBusiness();
                string extension = ObtenerExtension(fileUploadProfilePicture);
                string fileName = Guid.NewGuid().ToString() + CurrentEmployee.Dni + "." + extension;
                string rutaCarpetaRaiz = Server.MapPath("~");
                string Folder = "/images/ProfileImagesEmployees/";
                string uploadFolder = rutaCarpetaRaiz + Folder;
                string filePath = Path.Combine(uploadFolder, fileName);
                fileUploadProfilePicture.SaveAs(filePath);
                crBusiness.ChangePhoto(Folder + fileName, CurrentEmployee.credentials.IdCredential);
                ProfilePhoto = Folder + fileName;
            }

        }


        //----------------------------------         FUNCIONES       --------------------------------------------------
        public string ObtenerExtension(FileUpload fileUploadControl)
        {
            if (fileUploadControl.HasFile)
            {
                string fileName = fileUploadControl.FileName;
                string extension = Path.GetExtension(fileName);
                return extension.TrimStart('.').ToLower();  // Devuelve la extensión sin el punto y en minúsculas
            }
            else
            {
                return string.Empty;  // No hay archivo cargado
            }
        }

        private void updateBookingEmployeeSession()
        {
            BookingBusiness bkBusiness = new BookingBusiness();
            List<Booking> BookingsInProgress;


            try
            {
                BookingsInProgress = bkBusiness.ListInProgress();
                Session["BookingsInProgress"] = BookingsInProgress;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}