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
            loadBookings();
            loadFlights();
            if (!IsPostBack)
            {                      
                panelHome.CssClass = "";
                panelDashboard.CssClass = "hidden";
                panelFlight.CssClass = "hidden";

            }

        }

       

        private void loadProfile(Employee CurrentEmployee)
        {
            loadProfilePhoto();
            txtName.Text = CurrentEmployee.Name;
            txtLastName.Text = CurrentEmployee.Surname;
            txtEmail.Text = CurrentEmployee.credentials.Email;
            txtCel.Text = CurrentEmployee.Cellphone.ToString();
            txtAdress.Text = CurrentEmployee.Address;
            txtGender.Text = CurrentEmployee.Gender.ToString();

        }
        private void loadFlights()
        {
            repeaterFlight.DataSource = (List<Flight>)Session["Flights"];
            repeaterFlight.DataBind();
        }

        private void loadBookings()
        {
            
            List<Booking> allBookings = (List<Booking>)Session["Bookings"];
            List<Booking> bookingsInProgress = allBookings.Where(booking => booking.StateBooking == "En proceso").ToList();
            rptActiveBokings.DataSource = bookingsInProgress;
            rptActiveBokings.DataBind();
        }

        private void loadProfilePhoto()
        {
            //falta validación si no encuentra la foto de perfil dentro de la carpeta
            if (CurrentEmployee.credentials.Photo != null)
            {
                ProfilePhoto = CurrentEmployee.credentials.Photo;
            }

            else
            {
                ProfilePhoto = "/pp.jpg";

            }
         
        }



        //----------------------------------         Eventos        --------------------------------------------------

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            panelHome.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            updatePanelGeneral.Update();

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            panelDashboard.CssClass = "";
            panelHome.CssClass = "hidden";
            panelFlight.CssClass = "hidden";
            updatePanelGeneral.Update();
        
        }

        protected void btnFlight_Click(object sender, EventArgs e)
        {
            panelFlight.CssClass = "";
            panelDashboard.CssClass = "hidden";
            panelHome.CssClass = "hidden";
            updatePanelGeneral.Update();

        }


        protected void Cancel_Click(object sender, EventArgs e)
        {
            BookingBusiness bBusiness = new BookingBusiness();
            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Cancelada");
                ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);
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
            FlightBusiness fBusiness = new FlightBusiness();
            List<Booking> listBooking;
            Booking aux;


            try
            {
                string IdBooking = ((LinkButton)sender).CommandArgument;
                bBusiness.editStatusRequestBooking(int.Parse(IdBooking), "Aprobada");
                //Cuando se aprueba la reserva ya se genera el vuelo
                listBooking = (List<Booking>)Session["Bookings"];
                aux = listBooking.Find(x => x.IdBooking.Equals(int.Parse(IdBooking)));
                fBusiness.addFlight(aux);
                //////////////////////////////////////////////////////
                ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx");
                throw ex;
            }

        }

        
        protected void ChangePhoto2_Click(object sender, EventArgs e)
        {

            if (fileUpload1.HasFile)
            {
                CredentialBusiness crBusiness = new CredentialBusiness();
                string extension = ObtenerExtension(fileUpload1);
                string fileName = Guid.NewGuid().ToString() + CurrentEmployee.Dni + "." + extension;
                string rutaCarpetaRaiz = Server.MapPath("~");
                string Folder = "/images/ProfileImagesEmployees/";
                string uploadFolder = rutaCarpetaRaiz + Folder;
                string filePath = Path.Combine(uploadFolder, fileName);

                try
                {
                    fileUpload1.SaveAs(filePath);
                    crBusiness.ChangePhoto(Folder + fileName, CurrentEmployee.credentials.IdCredential);
                    CurrentEmployee.credentials.Photo = Folder + fileName;
                    Session.Add("EmployeeLogged", CurrentEmployee);
                    ProfilePhoto = Folder + fileName;                   
                    //ScriptManager.RegisterStartupScript(updatePanelGeneral, updatePanelGeneral.GetType(), "UpdatePanelUpdate", "__doPostBack('" + updatePanelGeneral.ClientID + "', '');", true);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }       

        }

        /*
         * 
         * 
          <div class="table-responsive">
    <table class="table cart-items" style="text-align: center; vertical-align: middle; width:70% ; margin-left: 15%; margin-right:15%;">
        <thead>
            <tr>
                <th scope="col" style="color: dimgrey; width: 50%;">Product</th>
                <th scope="col" style="width: 50%;"></th>
                <th scope="col" style="color: dimgrey; width: 50%; font:100;">Price</th>
                <th scope="col" style="color: dimgrey; width: 40%;">Amount</th>
                <th scope="col" style="color: dimgrey; width: 50%;">Subtotal</th>
                <th scope="col" style="color: dimgrey; width: 30%;"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repeaterFlight" runat="server">
                <ItemTemplate>
                    <tr>
                        <td> 
                            <asp:Image ID="imgItem" runat="server" ImageUrl='<%# (Eval("item.Images[0].Url").ToString() == "FailedLoad") ? "descarga.png" : (Eval("item.Images[0].Url").ToString() == "EmptyImage") ? "emptyImage.jpg" : Eval("item.Images[0].Url") %>' CssClass="card-img-top" style="object-fit: scale-down; height: 25vh; width: 50%" alt="Image" />  
                         </td>
                        <td>
                            <%# Eval("item.Name") %><br />
                           <p style="color:dimgray; font-size:small;"> <%# Eval("item.Brand.Descripcion") %></p>
                            
                        </td>

                        <td style="font-weight: bold;">$<%# Eval("item.Price") %></td>
                        <td><div style="margin-top:6%; font-size: 20px;  margin-left:7%;">
                             <div class="btn-group">
                                <asp:Button ID="btnDash" runat="server" Text="-" OnClick="btnDash_Click" CommandArgument='<%# Eval("item.ItemCode") %>'
                                    UseSubmitBehavior="false"
                                    class="btn btn-outline-secondary" style="font-weight: bold; border-color: white;  font-size: 25px; " />
                                <span style="font-size: 25px; vertical-align:middle;  "><%#Eval("Amount")%></span>
                                 <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click" CommandArgument='<%# Eval("item.ItemCode") %>'
                                    UseSubmitBehavior="false"
                                    class="btn btn-outline-secondary" style="font-weight: bold; border-color: white; font-size: 25px; " />
                                
                            </div>
                            </div>
                        </td>
                        <td style="font-weight: bold;">$<%# Eval("SubTotal")  %> </td>
                        <td>
                            <asp:LinkButton ID="btnDeleteFromCart" runat="server" OnClick="btnDeleteFromCart_Click" CommandArgument='<%# Eval("item.ItemCode") %>' UseSubmitBehavior="false" OnClientClick="return confirm('Are you sure you want to delete this Item?');">
                            <i class="bi bi-trash-fill text-danger"></i>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
        </div>
          
        -----------------------------------------------------
          <div class="mx-auto d-flex">
            <form class="d-flex" role="search">
           
          <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style ="visibility:hidden;"/>
          <asp:TextBox runat="server" ID="tbFilter" class="form-control me-2" placeholder="Search by name, brand and category..." aria-label="search" style="width: 700px;"
               onkeydown="if (event.keyCode == 13) document.getElementById('<%= btnBuscar.ClientID %>').click();"></asp:TextBox>
          <asp:Button runat="server" Text="Search" ID="Button1"   OnClick="btnBuscar_Click"  class="btn btn-outline-light" UseSubmitBehavior="false"></asp:Button>
  
      </form>
         </div>   


        ----------------------------------------------------------------------------------
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbFilter.Text != "")
            {
                search(tbFilter.Text);
            }
        }

        protected void search(string text)
        {
            List<Item> aux = (List<Item>)Session["ItemList"];
            filterList = aux.FindAll(x => x.Name.ToUpper().Contains(text.ToUpper()) ||
            x.Brand.Descripcion.ToUpper().Contains(text.ToUpper()) ||
            x.Category.Descripcion.ToUpper().Contains(text.ToUpper()));
            Session.Add("filteredItems", filterList);
            if (!string.Equals(Request.Url.AbsolutePath, "/Default.aspx", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect($"Default.aspx");
            }


        }
        */




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
            FlightBusiness fBusiness = new FlightBusiness();
            List<Booking> Bookings;
            List<Flight> flight;


            try
            {
                Bookings = bkBusiness.List();
                flight = fBusiness.List();                
                Session["Bookings"] = Bookings;
                Session["Flights"] = flight;

               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}