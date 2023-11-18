<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="CabWeb.EmployeeView"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <%if (Session["EmployeeLogged"] == null)
        {
            Response.Redirect("Default.aspx");
        }%>

    
    <style>
        body {
            background: url('images/JeteditEmployee.jpg') no-repeat center center fixed;
            background-size: cover;
        }

        .ClientBox {
            background-color: rgba(169, 169, 169, 0.7);
            width: 85%;
            height: 800px;
            overflow: auto;
        }

          .BookingBox {
            background-color: rgba(169, 169, 169, 0.2);
            padding:1%;
         
        }

        
    </style>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional"  ChildrenAsTriggers="true">
 
        <ContentTemplate>
    
            <div class="row">
              <div class="ol-sm-auto bg-light " style="width: 9rem">
                    <div class="d-flex flex-sm-column flex-row flex-nowrap bg-light align-items-center " style="width: 8.2rem;">
                        <ul class="nav nav-pills nav-flush flex-column mb-auto text-center justify-content-center ">
                            <li>
                                <br />
                                <asp:LinkButton ID="linkButtonUser" runat="server" OnClick="linkButtonUser_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (5).svg"" alt="Descripción de la imagen"style="margin-top:250%; height:40px;width:40px;"/>
                                </asp:LinkButton>

                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButton1_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (1).svg"g" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>
                            </li>

                               <li class="nav-item">
                                <asp:LinkButton ID="Bookings" runat="server" OnClick="Bookings_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/Travels.svg" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>
                            </li>
                            <li>
                           
                                <a href="#historical">
                                     <img src="/IconSidebar/svg1 (2).svg"" alt="Descripción de la imagen"style="height:40px;width:40px; margin-top:15%;" />
                                    <hr />
                                </a>
                            </li>
                            <li>
                                <asp:LinkButton ID="linkButton3" runat="server" OnClick="linkButton3_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (3).svg"" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="linkButton4" runat="server" OnClick="linkButton4_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (4).svg"" alt="Descripción de la imagen"style="height:40px;width:40px;"/>
                                </asp:LinkButton>

                            </li>
                        </ul>


                    </div>

                </div>

                <div class="col-11 ClientBox" id="menuContent" runat="server" style="width:90%;">
       

                    <%if (CurrentContent == 0)
                        {%>
                    <center>
                  
                        <h1  style="margin-top:2%;">Profile</h1>
                        <h2 style="margin-bottom:2%;"><%:CurrentEmployee.Name + " " + CurrentEmployee.Surname%></h2>
           
                         
                             <img src='<%:ProfilePhoto%>' alt="Foto" style="width: 200px; height: 200px; border-radius: 50%; margin-bottom:2%;" />
                      
                        <br />
                            <asp:Label ID="lblDateOfBirth" runat="server" style="color: black;" Text="Date of Birth:"><%:CurrentEmployee.DateOfBirth%></asp:Label>
                        <br />
                            <asp:Label ID="Label4" runat="server" style="color: black;" Text="Add profile picture"></asp:Label><br />

                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" style="margin-top:2%; margin-bottom:2%;">
                              <i class="bi bi-pencil-fill"></i>
                            </button>
                   
                            
                             <asp:Label class="text-secondary" ID="lblName" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  ID="txtName" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblLastName" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtLastName" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtEmail" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblPassword" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="New Password" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblRepetPassword" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Repeat Password" ID="RepetPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblCel" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;" ID="txtCel" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblAdress" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;"  ID="txtAdress" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />
                          

                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:2%; margin-bottom:2%;">
                                Edit
                            </button>

                            
                          
                            <a href="Default.aspx" class="btn btn-secondary" style="margin-top:2%; margin-bottom:2%;">Back</a>

                     </center>

                    <%} %>
                    <%if (CurrentContent == 1)
                        {%>
                    <center>
                        <h1>Home</h1>
                    </center>

 

                    <%} %>
                    <%else if (CurrentContent == 2)
                        {%>
                    <center>
                       
                    <%} %>
                 
                    <%else if (CurrentContent == 4)
                        {%>
                    <center>
                        <h1>Flyes</h1>
                    </center>
                    <%} %>

                          <%else if (CurrentContent == 5)
                        {%>
                        <center>
                            <h1> Solicitudes </h1>

<%--                            <div class="row" style="margin-top: 50px; margin-left: 25px; margin-right: 25px; margin-bottom: 50px; overflow: auto">
                                <asp:Repeater ID="rptActiveBokings" runat="server">
                                    <ItemTemplate>
                                        <div class="col-12 col-md-6 col-lg-4 mb-2" style="background-color: rgba(0, 0, 0, 0.5);">
                                            <center>
                                                <div style="max-width: 18rem;">
                                                    <center>
                                                        <img src="https://th.bing.com/th/id/R.5980a84df020a575b1e6b9e4d24c265e?rik=phr7zp%2fsNPdVWA&pid=ImgRaw&r=0" alt="Foto" style="width: 100px; height: 100px; border-radius: 50%;" />
                                                    </center>
                                                    <p>ID booking: <%# Eval("IdBooking") %></p>
                                                    <p>ID Client: <%# Eval("IdClient") %></p>
                                                    <p>Origin: <%# Eval("Origin.NameCity") %></p>
                                                    <p>Destiny: <%# Eval("Destination.NameCity") %></p>
                                                    <p>Date of booking: <%# Eval("DateBooking") %></p>
                                                    <p>Date of petition: <%# Eval("SolicitudDate") %></p>
                                                    <p>Passengers: <%# Eval("Passengers") %></p>
                                                    <p>State of reservation:<span style='<%# Eval("StateBooking").ToString() == "En proceso" ? "color: yellow;": Eval("StateBooking").ToString() == "Aprobada" ? "color: green;" : "" %>'><%# Eval("StateBooking") %></span>
                                                    </p>
                                                  
                                                    <asp:LinkButton ID="ChangeStatebooking3" runat="server" OnClick="ChangeStatebooking2_Click" CommandArgument='<%# Eval("IdBooking") %>' UseSubmitBehavior="false" OnClientClick="return confirm('Are you sure you want to Aprove this Reservation?');">
            <i class="bi bi-check-circle-fill text-success"></i>
                                                    </asp:LinkButton>
                                                 
                                                </div>
                                            </center>
                                        </div>

                                    </ItemTemplate>
                        </asp:Repeater>
                    </div>
        <asp:Button ID="ChangeStatebooking2" runat="server" CommandArgument='<%# Eval("IdBooking") %>' class="btn btn-outline-primary" OnClick="ChangeStatebooking_Click" Text="Change State booking" Style="font-weight: bold; border-color: dimgrey; margin-top: 4%;margin-bottom: 4%;" AutoPostBack="true" />
                          --%>  
                            

                                    <div class="row" style="display: flex; flex-direction: column; margin-top: 70px; margin-left: 25%; margin-right: 25%; margin-bottom: 70px; overflow: auto; align-items: center;">
                                    <asp:Repeater ID="rptActiveBokings" runat="server">
                                        <ItemTemplate>
                                            <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(0, 0, 0, 0.5); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                                                <div style="display: flex; justify-content: center; align-items: center; padding: 20px;">
                                                    <div style="margin-right: 20%;">
                                                        <center>
                                                            <img src="https://th.bing.com/th/id/R.5980a84df020a575b1e6b9e4d24c265e?rik=phr7zp%2fsNPdVWA&pid=ImgRaw&r=0" alt="Foto" style="width: 210px; height: 210px; border-radius: 50%;" />
                                                        </center>
                                                        <p>ID booking: <%# Eval("IdBooking") %></p>
                                                        <p>ID Client: <%# Eval("IdClient") %></p>
                                                    </div>
                                                    <div>
                                                        <p style="font-weight: bold; font-size: 1.2em;">Origin: <%# Eval("Origin.NameCity") %></p>
                                                        <p style="font-weight: bold; font-size: 1.2em;">Destiny: <%# Eval("Destination.NameCity") %></p>
                                                        <p>Date of booking: <%# Eval("DateBooking") %></p>
                                                        <p>Date of petition: <%# Eval("SolicitudDate") %></p>
                                                        <p>Passengers: <%# Eval("Passengers") %></p>
                                                        <p>State of reservation:
                                                            <span style='<%# Eval("StateBooking").ToString() == "En proceso" ? "color: yellow;" : Eval("StateBooking").ToString() == "Aprobada" ? "color: green;" : "" %>'>
                                                                <%# Eval("StateBooking") %>
                                                            </span>
                                                        </p>
                                                        <asp:LinkButton ID="ChangeStatebooking3" runat="server" OnClick="ChangeStatebooking2_Click" CommandArgument='<%# Eval("IdBooking") %>' UseSubmitBehavior="false" OnClientClick="return confirm('Are you sure you want to Approve this Reservation?');">
                                                            <i class="bi bi-check-circle-fill text-success"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <asp:Button ID="ChangeStatebooking2" runat="server" CommandArgument='<%# Eval("IdBooking") %>' class="btn btn-outline-primary" OnClick="ChangeStatebooking_Click" Text="Change State booking" Style="font-weight: bold; border-color: dimgrey; margin-top: 4%; margin-bottom: 4%;" AutoPostBack="true" />
  





                    </center>
                    <%} %>
              
            </div>
              
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

   
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                <%--     <h1 class="modal-title fs-5" id="staticBackdropLabel">Modal title</h1>--%>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                    You want to modify the fields?
                                    </div>
                                    <div class="modal-footer">
                                    <button type="button" class="btn btn-primary">Ok</button>
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    </div>
                                </div>
                                </div>
                            </div>



    <div class="modal fade" id="staticBackdrop2" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                <%--     <h1 class="modal-title fs-5" id="staticBackdropLabel">Modal title</h1>--%>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">

                                        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" enctype="multipart/form-data"/>

                                    </div>
                                    <div class="modal-footer">
                                    <asp:Button ID = "ChangePhoto2" class="btn btn-primary" runat="server" Text="Change photo" Onclick="ChangePhoto2_Click" />
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    </div>
                                </div>
                                </div>
                            </div>


    

    
</asp:Content>


