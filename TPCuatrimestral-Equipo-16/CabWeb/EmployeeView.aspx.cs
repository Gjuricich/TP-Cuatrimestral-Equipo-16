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
        public BookingBusiness bkBusiness = new BookingBusiness();
        public int CurrentContent = 0;
        public List<Booking> RecivedReservations;
        public string ProfilePhoto;
        protected void Page_Load(object sender, EventArgs e)
        {
            CredentialBusiness crBusiness = new CredentialBusiness();
            bkBusiness = new BookingBusiness();
            RecivedReservations = new List<Booking>();
            CurrentEmployee = (Employee)Session["EmployeeLogged"];
            RecivedReservations = bkBusiness.List();
            rptActiveBokings.DataSource = RecivedReservations;
            rptActiveBokings.DataBind();
          if (crBusiness.getPhoto(CurrentEmployee.credentials.IdCredential)!=null)
            {
                ProfilePhoto = crBusiness.getPhoto(CurrentEmployee.credentials.IdCredential);
            }

            else
            {
                ProfilePhoto = "/pp.jpg";

            }

            txtName.Text = CurrentEmployee.Name;
            txtLastName.Text = CurrentEmployee.Surname;
            txtEmail.Text = CurrentEmployee.credentials.Email;
            txtCel.Text = CurrentEmployee.Cellphone.ToString();
            txtAdress.Text = CurrentEmployee.Address;
           txtGender.Text = CurrentEmployee.Gender.ToString();




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

        protected void ChangeStatebooking_Click(object sender, EventArgs e)
        {
            bkBusiness = new BookingBusiness();
            Button btn = (Button)sender;
            string idbok = btn.CommandArgument;
            int IdBooking = int.Parse(idbok);
            bkBusiness.ChangeStateBooking(IdBooking);

        }
        protected void ChangeStatebooking2_Click(object sender, EventArgs e)
        {
            bkBusiness = new BookingBusiness();
            LinkButton btn = (LinkButton)sender;
            string idbok = btn.CommandArgument;
            int IdBooking = int.Parse(idbok);
            bkBusiness.ChangeStateBooking(IdBooking);

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
    }
}