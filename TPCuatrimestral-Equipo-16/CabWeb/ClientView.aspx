﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="CabWeb.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        body {
            background: url('montain.jpg') no-repeat center center fixed;
            background-size: cover;
        }

         .ProfileBox {
            background-color: rgba(169, 169, 169, 0.7);
            padding: 20px;
            border-radius: 5px;
            max-width: 100%;
            margin-top : 5px;       
        }

          .BookingBox {
            background-color: rgba(169, 169, 169, 0.2);
            padding:1%;
         
        }
           .hidden 
        {
            display: none;
        }

        
    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["ClientLogged"] == null)
      {
            Response.Redirect("Default.aspx");
      }%>

    


      <div class="container-fluid">
        <div class="row">

                  <%-----------------------------------------------------     Barra lateral         ----------------------------------------------%>
            <div class="col-md-auto bg-light" style="padding: 0; min-width: 8rem;">
                <div class="d-flex flex-column justify-content-center align-items-center" style="height: 100vh;">
                    <ul class="nav flex-column">
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnProfile" runat="server" OnClick="btnProfile_Click" class="nav-link p-0">
                                <img src="/IconSidebar/svg1 (5).svg" alt="Profile" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnBookingInProgress" runat="server" Onclick="btnBookingInProgress_Click" class="nav-link p-0">
                                <img src="/IconSidebar/svg1 (2).svg" alt="Bookings" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnBooking" runat="server" OnClick="btnBooking_Click" class="nav-link p-0">
                                <img src="/IconSidebar/svg1 (4).svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                         <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnAddBooking" runat="server" OnClick="btnAddBooking_Click" class="nav-link p-0">
                                <img src="/IconSidebar/svg1 (3).svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
      
       

     <%-----------------------------------------------------    Contenido íconos        ----------------------------------------------%>
            
           <div class="col">
           <asp:UpdatePanel ID="UpdatePanelGeneral" runat="server" UpdateMode="Conditional">
           <ContentTemplate>


     <%------------------   PROFILE    ---------------%> 
               <asp:Panel ID="panelprofile" runat="server" CssClass="hidden">
           
               <div class="col-4" style="margin-top: 10px; margin-bottom: 10px; margin-left: auto; margin-right: auto;">
                    <div  class="ProfileBox">
                        
                           <center>
                               <img src='<%:CurrentClient.credentials.Photo%>' alt="Foto" style="width: 200px; height: 200px; border-radius: 50%; margin-bottom:2%;" />
                                <br/>
                                  <h1><%:CurrentClient.Name + " " + CurrentClient.Surname%></h1>
                                <br/>
                           </center>


                           <center>  
                            <%---------------------------------         Cambiar foto de perfil        ----------------------------------%>
                          
                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" style="margin-top:2%; margin-bottom:2%;">
                              <i class="bi bi-pencil-fill"></i>
                            </button>
                            <asp:Label ID="lblAddPhoto" runat="server" style="color: black;" Text="Add profile picture"></asp:Label>

                             <%---------------------------------          Formulario          -------------------------------------------%>
                                              
                            <div>   
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
                                Save changes
                            </button>           
                            </div>
                            </center>
                     </div>
                  </div>                  
              </asp:Panel>

                   <%------------------   Reservas en proceso    ---------------%>

        <asp:Panel ID="panelBookings" runat="server" CssClass="hidden">
            <center>
                            <h1> Solicitudes de Reserva </h1>                            
                                    <div class="row" style="display: flex; flex-direction: column; margin-top: 70px; margin-left: 25%; margin-right: 25%; margin-bottom: 70px; overflow: auto; align-items: center;">
                                     <asp:Repeater ID="rptActiveBokings" runat="server">
                                        <ItemTemplate>
                                            <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(0, 0, 0, 0.5); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                                                <div style="display: flex; justify-content: center; align-items: center; padding: 20px;">
                                                    <div style=" margin-right: 20%;">
                                                        <img src="https://th.bing.com/th/id/R.5980a84df020a575b1e6b9e4d24c265e?rik=phr7zp%2fsNPdVWA&pid=ImgRaw&r=0" alt="Foto" style="width: 210px; height: 210px; border-radius: 50%;" />
                                                    </div>
                                                    <div>
                                                        <p style="font-weight: bold; font-size: 1.2em;">Origin: <%# Eval("Origin.NameCity") %></p>
                                                        <p style="font-weight: bold; font-size: 1.2em;">Destiny: <%# Eval("Destination.NameCity") %></p>
                                                        <p>Date of booking: <%# Eval("DateBooking") %></p>
                                                        <p>Date of petition: <%# Eval("SolicitudDate") %></p>
                                                        <p>State of reservation: <strong><%# Eval("StateBooking") %></strong></p>
                                                         <asp:LinkButton ID="Cancelcontrol" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="Cancel_Click" OnClientClick="return confirm('¿Are you sure that do you want cancel ticket ?')" CommandArgument='<%# Eval("IdBooking") %>' />
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>                           
                    </center>
             </asp:Panel>

                <%------------------  Solicitud de reserva    ---------------%>

                <asp:Panel ID="panelRequestBooking" runat="server" CssClass="hidden">
               
                     <center>
               
                           <div class="centered-inputs DefaultBox" style="position: absolute; top: 45%; left: 50%; transform: translate(-50%, -50%);">
                            <div class="container text-center" style="display: flex; justify-content: center; align-items: center;">
                                <div class="row " display="flex" >
                                <div class="col"  >
                                    <h4><strong>FROM</strong></h4>
                                    <asp:DropDownList ID="ddlcityOrigin" runat="server" AutoPostBack="false" style="background-color: transparent;  max-width: 600%;">
                                        </asp:DropDownList>
                                 
                                </div>
                                <div class="col"   >
                                    <h4><strong>TO</strong></h4>
                                    <asp:DropDownList  ID="ddlcityDestiny" runat="server" AutoPostBack="false" style="background-color: transparent;  max-width: 600%;">
                                       </asp:DropDownList>
                                   
                                </div>
                                <div class="col" >
                                    <h4><strong>DATE</strong></h4>
                                    <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="TxbDatePicked" type="date" data-date-format="dd/MM/yyyy" runat="server"></asp:TextBox>
                                </div>
                                    <div class="col">
                                        <h4><strong>TIME</strong></h4>
                                        <asp:TextBox ID="TxbTimePicked" class="form-control form-control-sm rounded" style="max-width: 500px;" type="time" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <h4><strong>PASSENGER</strong></h4>
                                        <input type="number" id="passengerInput" runat="server" min="1" max="10" style="background-color: transparent; max-width: 600%;" required>
                                      </div>
                                                               
                                    <asp:Button ID="Bookflight" runat="server" class="btn btn-outline-secondary" OnClick="Bookflight_Click" Text="Book flight" Style="font-weight: bold; border-color: dimgrey; margin-top: 4%;" />

                                     
                                </div>
                            </div>
                           </div>
               
                    </center>              
                </asp:Panel>

                <%------------------  Historial de reservaciones    ---------------%>

                <asp:Panel ID="panelReservations" runat="server" CssClass="hidden">
                    <center>
                            <h1>Reservations</h1>  
                                              
                    
                           <%--  <img src="/IconSidebar/antg.svg" alt="Antigüedad" style="width: 25px; height: 25px;" />
                            <asp:Label ID="lblAntiguedad" runat="server"  />
                             <br /> 
                            <img src="/IconSidebar/famount.svg" alt="cant" style="width: 25px; height: 25px;"  />
                            <asp:Label ID="lblVuelos" runat="server" />
                             <br />--%> 
                            <img src="/IconSidebar/ok.svg" alt="ok" style="width: 25px; height: 25px;"  />
                            <asp:Label ID="llblAceptadas" runat="server" />
                             <br />
                            <img src="/IconSidebar/pross.svg" alt="pross" style="width: 25px; height: 25px;"  />
                            <asp:Label ID="lblEnProceso" runat="server"/>
                             <br />
                               
                      
                                        
                                    <div class="row" style="display: flex; flex-direction: column; margin-top: 50px; margin-left: 25%; margin-right: 25%; margin-bottom: 50px; overflow: auto; align-items: center;">
                                        <asp:Repeater ID="rptBokings" runat="server">
                                            <ItemTemplate>
                                                <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(0, 0, 0, 0.5); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                                                    <div style="display: flex; justify-content: center; align-items: center; padding: 20px;">
                                                        <div style=" margin-right: 20%;">
                                                            <img src="https://th.bing.com/th/id/R.5980a84df020a575b1e6b9e4d24c265e?rik=phr7zp%2fsNPdVWA&pid=ImgRaw&r=0" alt="Foto" style="width: 210px; height: 210px; border-radius: 50%;" />
                                                        </div>
                                                        <div>
                                                            <p style="font-weight: bold; font-size: 1.2em;">Origin: <%# Eval("Origin.NameCity") %></p>
                                                            <p style="font-weight: bold; font-size: 1.2em;">Destiny: <%# Eval("Destination.NameCity") %></p>
                                                            <p>Date of booking: <%# Eval("DateBooking") %></p>
                                                            <p>Date of petition: <%# Eval("SolicitudDate") %></p>
                                                            <p>State of reservation: <strong><%# Eval("StateBooking") %></strong></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>                       
                          </center>
                     </asp:Panel>
                  </ContentTemplate>       
                 </asp:UpdatePanel>
               </div>
             </div>
           </div>

              <%-----------------------------------------------------     MODALES         ----------------------------------------------%>

              <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
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



    
                 <div class="modal fade" id="staticBackdrop2" data-bs-backdrop="static"  data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                            
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">

                                        <asp:FileUpload ID="fileUpload1" runat="server" enctype="multipart/form-data"/>

                                    </div>
                                    <div class="modal-footer">
                                    <asp:Button ID = "ChangePhotoClient" class="btn btn-primary" runat="server" Text="Change photo" OnClick="ChangePhotoClient_Click"/>
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    </div>
                                </div>
                                </div>
                            </div>


</asp:Content>
