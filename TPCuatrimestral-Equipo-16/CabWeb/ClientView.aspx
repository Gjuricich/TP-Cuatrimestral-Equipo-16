<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="CabWeb.ClientView" %>

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
                            <asp:LinkButton ID="btnProfile" runat="server" OnClick="btnProfile_Click" class="nav-link p-0" ToolTip="Profile">
                                <img src="/IconSidebar/svg1 (5).svg" alt="Profile" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnBookingInProgress" runat="server" Onclick="btnBookingInProgress_Click" class="nav-link p-0" ToolTip="Reservation Request">
                                <img src="/IconSidebar/svg1 (2).svg" alt="Bookings" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnBooking" runat="server" OnClick="btnBooking_Click" class="nav-link p-0" ToolTip="Reservation">
                                <img src="/IconSidebar/Bookings.svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                         <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnAddBooking" runat="server" OnClick="btnAddBooking_Click" class="nav-link p-0" ToolTip="Create Reservation">
                                <img src="/IconSidebar/svg1 (3).svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                                 <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnFlight" runat="server" OnClick="btnFlight_Click" class="nav-link p-0" ToolTip="Flight History">
                                <img src="/IconSidebar/svg1 (4).svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
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
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  ID="txtName" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblLastName" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtLastName" runat="server" ></asp:TextBox><br />
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblCel" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;" ID="txtCel" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblAdress" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;"  ID="txtAdress" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />                         
                           <%--<asp:Label class="text-secondary" ID="lblRepetPassword" runat="server"></asp:Label>--%>
                                 <%-- <div style="display:flex;">--%>
                               <%-- <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Repeat Password" ID="RepetPassword" runat="server" TextMode="Password"></asp:TextBox>--%>
                            <asp:Label class="text-secondary" ID="infoPass" runat="server" ></asp:Label>
                                <asp:LinkButton ID="btnOpenModal" runat="server" CssClass="btn btn-secondary" OnClientClick="return openModal();" ToolTip="New Password" >
                                    <i class="bi bi-pencil-fill"></i>
                                    </asp:LinkButton>
                                   <%-- </div>--%>
                                
                           <asp:LinkButton ID="btnSaveChanges" class="btn btn-primary" runat="server" Text="Save changes" Onclick="btnSaveChanges_Click" OnClientClick="return confirm('Are you sure do you want to save your changes ?')"/>

                            <asp:LinkButton ID="btnDeleteClient" runat="server" Tooltip="Delete account" class="btn btn-danger" OnClick="btnDeleteClient_Click" OnClientClick="return confirm('¿Are you sure that do you want delete your account ?')" >
                                <i class="bi bi-trash"></i> 
                            </asp:LinkButton>         
                            </div>
                            </center>
                     </div>
                  </div>                  
              </asp:Panel>

                   <%------------------   Reservas en proceso    ---------------%>

        <asp:Panel ID="panelBookings" runat="server" CssClass="hidden">
            <center>
                            <h1> Reservation Request</h1>                            
                                    <div class="row" style="display: flex; flex-direction: column; margin-top: 70px; margin-left: 25%; margin-right: 25%; margin-bottom: 70px; overflow: auto; align-items: center;">
                                     <asp:Repeater ID="rptActiveBokings" runat="server">
                                        <ItemTemplate>
                                            <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(169, 169, 169, 0.7); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
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
                           
                           <div class="centered-inputs DefaultBox" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%);">
                            <div class="container text-center" style="display: flex; justify-content: center; align-items: center;">
                                <div  class="ProfileBox">
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
                                        <input type="number" id="passengerInput" runat="server" min="1" max="12" style="background-color: transparent; max-width: 600%;" required>
                                      </div>
                                                               
                                    <asp:Button ID="Bookflight" runat="server" class="btn btn-primary" OnClick="Bookflight_Click" Text="Book flight" Style="font-weight: bold; border-color: dimgrey; margin-top: 4%;" />

                               </div>      
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
                                                <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(169, 169, 169, 0.7); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
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
                     
          <%------------------  PANEL  Vuelos    ---------------%>

        <asp:Panel ID="panelFlight" runat="server" CssClass="hidden">
             <center>
                        <h1>Flights</h1>
                        <div class="col-10" style="margin-top: 20px; margin-bottom: 20px; margin-left: auto; margin-right: auto;">
                        <table id="example" class="table table-striped" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Flight date</th>
                                    <th>Origin</th>
                                    <th>Destination</th>                                   
                                    <th>Aircraft</th>
                                    <th>Passengers</th>
                                    <th>Request status</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repeaterFlight" runat="server">
                                    <ItemTemplate>
                                      <tr>
                                        <td><%# Eval("booking.DateBooking") %></td>
                                        <td><%# Eval("booking.Origin.NameCity") %></td>
                                        <td><%# Eval("booking.Destination.NameCity")%></td>
                                        <td><%# Eval("aircraft.Model") %></td>
                                        <td><%# Eval("booking.Passengers") %></td>
                                        <td><%# Eval("FlightState") %></td>
                                        <td>
                                         <asp:LinkButton ID="btnDetail" runat="server"  class="btn btn-secondary" OnClick="btnDetail_Click"  CommandArgument='<%# Eval("ID_Flight") %>'>
                                            <i class="bi bi-plus-square"></i>
                                         </asp:LinkButton>                                  
                                        </td>
                                        <td>
                                             <asp:LinkButton ID="btnaddPassengerPanel" runat="server"  class="btn btn-primary" OnClick="btnaddPassengerPanel_Click" CommandArgument='<%# Eval("ID_Flight") %>'>
                                             Add passenger
                                         </asp:LinkButton>
                                        </td>
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>
                         
                            </tbody>
                        </table>
                    </center>           
              </asp:Panel>

                      
                  <%------------------  PANEL  AGREGAR PASAJERO    ---------------%>
                 <asp:Panel ID="panelAddPassengers" runat="server" CssClass="hidden">
                <center>

                     <div class="col-4" style="margin-top: 10px; margin-bottom: 10px; margin-left: auto; margin-right: auto;">
                    <div  class="ProfileBox">
                        
                           <center>                         
                                  <h1> Passenger flight  </h1>
                                <br/>
                           </center>


                        
                                                    
                            <div>   
                            <asp:Label class="text-dark" ID="lblNameP" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  placeholder="Name" ID="txtNameP" runat="server" ></asp:TextBox><br />                            
                            <asp:Label class="text-dark" ID="lblLastNameP" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtLastNameP"  placeholder="Surname" runat="server"></asp:TextBox><br />      
                            <asp:Label class="text-dark" ID="lblDNIP" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="DNI" ID="txtDNIP" runat="server" ></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="lblGenderP" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtGenderP" placeholder="Gender" runat="server" MaxLength="1"></asp:TextBox><br /> 
                            <asp:Label class="text-dark" ID="lblcellphone" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtcellphone" placeholder="Cellphone" runat="server" MaxLength="12"></asp:TextBox><br />     
                       
                             <div style="margin-top: 10px;">
                                   <asp:LinkButton ID="BtnAddPassenger" runat="server" Text="Add Passenger" class="btn btn-secondary" OnClick="btnAddPassenger_Click" OnClientClick="return confirm('¿Are you sure that do you want add this passenger ?')"/>

                                 
                            </div>          
                            </div>
                            </center>
                           </div>
                         </div>                  



                          </center> 
                          </asp:Panel>

             <%------------------  PANEL  Detalles vuelo    ---------------%>

             <asp:Panel ID="panelDetail" runat="server" CssClass="hidden">
                    
                 <h1> Flight Details</h1>
            


                       <div class="col-10" style="margin-top: 20px; margin-bottom: 20px; margin-left: auto; margin-right: auto;"> 
                       
                     
                         <%------------------------------------------       PASAJEROS       ----------------------------------------------%>
                          <div  class="ProfileBox" style="margin-top: 20px;">                      
                             <h2> Passengers </h2> 
                               <table class="table">
                               <thead>
                                <tr>
                                  <th scope="col">DNI</th>
                                  <th scope="col">Name</th>
                                  <th scope="col">Surname</th>
                                  <th scope="col">Gender</th>                          
                                </tr>
                             </thead>
                          <tbody>
                                 <asp:Repeater ID="rptCurrentFlightPassengers" runat="server">
                                    <ItemTemplate>
                                      <tr>
                                        <td><%# Eval("Dni ") %></td>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Surname") %></td>
                                        <td><%# Eval("Gender") %></td>                                                     
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>

                         </tbody>
                        </table>
                     </div>

                            

                     <%------------------------------------------      ITINERARIO       ----------------------------------------------%>
                     <div  class="ProfileBox" style="margin-top: 20px;">   
                       <h2> Itinerary </h2>
                         <div>       

                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  placeholder="Name" ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="Label2"  Text="Flight Arrival" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="DNI" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="Label3" Text="Flight Departure" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="TextBox3"  placeholder="Surname" runat="server"></asp:TextBox><br />              
                            <asp:Label class="text-dark" ID="Label4" Text="Airport Arrival"  runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;" placeholder="Cellphone" ID="TextBox4" runat="server"></asp:TextBox><br />                          
                            <asp:Label class="text-dark" ID="Label5" Text="AirportDeparture" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="TextBox5" placeholder="Gender" runat="server" MaxLength="1"></asp:TextBox><br />                          
                       </div>
                         </div>
                                


               
                           
                 </div>
            </asp:Panel>
                  </ContentTemplate>       
                 </asp:UpdatePanel>
               </div>
             </div>
           </div>

              <%-----------------------------------------------------     MODALES         ----------------------------------------------%>
    
                 <div class="modal fade" id="staticBackdrop2" data-bs-backdrop="static"  data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                            
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">

                                        <asp:FileUpload ID="fileUpload1" runat="server" enctype="multipart/form-data" />

                                    </div>
                                    <div class="modal-footer">
                                        <asp:LinkButton ID="ChangePhotoClient" class="btn btn-primary" runat="server" Text="Change photo" OnClick="ChangePhotoClient_Click" />



                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    </div>
                                </div>
                                </div>
                 </div>


         <%-----------------------------------------------------     MODAL PASSWORD     ----------------------------------------------%>
    <div class="modal fade" id="passwordChanged" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div style="text-align: center; margin-bottom: 10px;">
                    <img src="/images/ShowMessage/sucessfully.png" alt="" style="width: 50px; height: 50px;">
                </div >
                <p style="text-align: center;">The password has changed correctly</p>
            </div>
        </div>
    </div>
</div>

        <div class="modal fade" id="wrongPassword" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div style="text-align: center; margin-bottom: 10px;">
                    <img src="/images/ShowMessage/Yellow-Warning.png" alt="Advertencia" style="width: 50px; height: 50px;">
                </div >
                <p style="text-align: center;">The current password is wrong,Try again.</p>
            </div>
        </div>
    </div>
</div>

           <div class="modal fade" id="notEqualPassword" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div style="text-align: center; margin-bottom: 10px;">
                    <img src="/images/ShowMessage/Yellow-Warning.png" alt="Advertencia" style="width: 50px; height: 50px;">
                </div >
                <p style="text-align: center;">The new password and his confirmation are not equal,Try again.</p>
            </div>
        </div>
    </div>
</div>

               <div class="modal fade" id="incompletePassword" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div style="text-align: center; margin-bottom: 10px;">
                    <img src="/images/ShowMessage/Yellow-Warning.png" alt="Advertencia" style="width: 50px; height: 50px;">
                </div >
                <p style="text-align: center;">Incomplete</p>
            </div>
        </div>
    </div>
</div>


    <div id="myModal" class="modal" style="width :30%; margin-left:39%;margin-top:10%;" >
        <div class="modal-content" style="padding:5%;" >
            <span class="close" onclick="closeModal();">&times;</span>
            <h2>Confirm Change Password</h2>
            <asp:Label class="text-secondary" ID="Label1" runat="server" Text="Enter your current password"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" Style="max-width: 500px;" placeholder="Password" ID="txtCurrentPass" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="Label6" runat="server" Text="Enter your new password"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" Style="max-width: 500px; " placeholder="Password" ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Label class="text-secondary" ID="Label7" runat="server" Text="Confirm your new password"></asp:Label>
            <asp:TextBox class="form-control form-control-sm rounded" Style="max-width: 500px;" placeholder="Password" ID="txtConfirmNewPass" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:LinkButton ID="btnConfirmNewPass" runat="server" Text="Confirm" OnClientClick="return confirmDelete();" OnClick="btnConfirmNewPass_Click" CssClass="btn btn-danger" />
            <asp:LinkButton ID="btnCancelNewPass" runat="server" Text="Cancel" OnClientClick="return cancelDelete();" CssClass="btn" />
        </div>
    </div>
    <script type="text/javascript">
        function openModal() {
            var modal = document.getElementById('myModal');
            modal.style.display = 'block';
            return false; // Evita el postback del LinkButton
        }
        function closeModal() {
            var modal = document.getElementById('myModal');
            modal.style.display = 'none';
        }
        function confirmDelete() {
            closeModal();
            return true;
        }
        function cancelDelete() {
            closeModal();
            return false;
        }
    </script>


</asp:Content>
