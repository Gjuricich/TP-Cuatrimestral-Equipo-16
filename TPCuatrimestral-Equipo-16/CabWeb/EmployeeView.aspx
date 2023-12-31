﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="CabWeb.EmployeeView"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <style>
        body 
        {
            background: url('images/JeteditEmployee.jpg') no-repeat center center fixed;
            background-size: cover;
        }

        .ProfileBox {
            background-color: rgba(169, 169, 169, 0.7);
            padding: 20px;
            border-radius: 5px;
            max-width: 100%;
            margin-top : 5px;       
        }
         .DetailBox {
            background-color: rgba(169, 169, 169, 0.5);
            padding: 20px;
            border-radius: 5px;
            max-width: 100%;
            margin-top : 5px;       
        }

        .BookingBox
        {
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

      <%if (Session["EmployeeLogged"] == null)
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
                            <asp:LinkButton ID="btnDashboard" runat="server" OnClick="btnDashboard_Click" class="nav-link p-0" ToolTip="Reservation requests">
                                <img src="/IconSidebar/svg1 (2).svg" alt="Bookings" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                        <li class="nav-item mb-5">
                            <asp:LinkButton ID="btnFlight" runat="server" OnClick="btnFlight_Click" class="nav-link p-0" ToolTip="Flight history">
                                <img src="/IconSidebar/svg1 (4).svg" alt="Flight" style="height: 40px; width: 40px; margin: 0 auto;" />
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
      
       

     <%-----------------------------------------------------    Contenido íconos        ----------------------------------------------%>

        <div class="col">

     <%------------------   PROFILE    ---------------%> 
        <asp:UpdatePanel ID="updatePanelGeneral" runat="server" UpdateMode="Conditional">
        <ContentTemplate>


        <asp:Panel ID="panelHome" runat="server" CssClass="hidden">
           
              <div class="col-4" style="margin-top: 10px; margin-bottom: 10px; margin-left: auto; margin-right: auto;">
                    <div  class="ProfileBox">
                        
                           <center>
                               <img src='<%:CurrentEmployee.credentials.Photo%>' alt="Foto" style="width: 200px; height: 200px; border-radius: 50%; margin-bottom:2%;" />
                                <br/>
                                  <h1><%:CurrentEmployee.Name + " " + CurrentEmployee.Surname%></h1>
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
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtLastName" runat="server"></asp:TextBox><br />
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox><br />
                           <asp:Label class="text-secondary" ID="lblCel" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;" ID="txtCel" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblAdress" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;"  ID="txtAdress" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />                         
                             <asp:Label class="text-secondary" ID="infoPass" runat="server" ></asp:Label>
                                <asp:LinkButton ID="btnOpenModal" runat="server" CssClass="btn btn-secondary" OnClientClick="return openModal();" ToolTip="New Password" >
                                    <i class="bi bi-pencil-fill"></i>
                                    </asp:LinkButton>
                             <asp:LinkButton ID="btnSaveChanges" class="btn btn-primary" runat="server" Text="Save changes" Onclick="btnSaveChanges_Click" OnClientClick="return confirm('Are you sure do you want to save your changes ?')"/>
 
                            </div>
                            </center>
                    </div>
            </div>                  
        </asp:Panel>


          <%------------------   Reservas en proceso    ---------------%>

        <asp:Panel ID="panelDashboard" runat="server" CssClass="hidden">
            <center>
                            <h1> Reservation request </h1>


                            

                                    <div class="row" style="display: flex; flex-direction: column; margin-top: 70px; margin-left: 25%; margin-right: 25%; margin-bottom: 70px; overflow: auto; align-items: center;">
                                    <asp:Repeater ID="rptActiveBokings" runat="server">
                                        <ItemTemplate>
                                            <div class="col-12 col-md-8 col-lg-6 mb-3" style="background-color: rgba(169, 169, 169, 0.7); width: 100%; border-radius: 10px; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
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
                                                        <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="Cancel_Click" OnClientClick="return confirm('¿Are you sure that do you want cancel ticket ?')" CommandArgument='<%# Eval("IdBooking") %>' />
                                                        <asp:LinkButton ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="Approve_Click" OnClientClick="return confirm('¿Are you sure that do you want approve ticket ?')" CommandArgument='<%# Eval("IdBooking") %>' />
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
                       <div class="col-12" style="margin-top: 20px; margin-bottom: 20px; margin-left: auto; margin-right: auto;">
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
                                         <%-- 
                                         <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#menuEdit" style="margin-top:2%; margin-bottom:2%;">
                                         <i class="bi bi-pencil-fill"></i>
                                         </button> --%>
                                           
                                        </td>
                                        <td>
                                            <button type="button" class="btn btn-danger">
                                            <i class="bi bi-trash"></i> 
                                            </button>
                                        </td>
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>
                         
                            </tbody>
                        </table>
                    </center>           
            </asp:Panel>

            <%------------------  PANEL  Detalles vuelo    ---------------%>

             <asp:Panel ID="panelDetail" runat="server" CssClass="hidden">
                    
                 <h1> Flight Details</h1>
                 <center>

                       <div class="col-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: auto; margin-right: auto;"> 
                         
                     
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
                                  <th scope="col"></th>
                                  <th scope="col"></th>
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
                                        <td>
                                         <asp:LinkButton ID="btnEditPassenger" runat="server"  class="btn btn-secondary" OnClick="btnEditPassenger_Click"  CommandArgument='<%# Eval("IdPerson") %>'>
                                             <i class="bi bi-pencil-fill"></i>
                                         </asp:LinkButton>                                                                           
                                        </td>
                                        <td>
                                         <asp:LinkButton ID="btnDeletePassenger" runat="server"  class="btn btn-secondary" OnClick="btnDeletePassenger_Click" OnClientClick="return confirm('¿Are you sure that do you want delete this passenger ?')"  CommandArgument='<%# Eval("IdPerson") %>'>
                                             <i class="bi bi-trash"></i> 
                                         </asp:LinkButton>                                                                                 
                                        </td>
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>

                         </tbody>
                        </table>
                     </div>

                            

                           <%------------------------------------------       CREW       ----------------------------------------------%>
                      <div  class="ProfileBox" style="margin-top: 20px;">   
                           <h2> Crew </h2>   
                           <asp:LinkButton ID="btnAvaibleCrew" runat="server"  class="btn btn-secondary" OnClick="btnAvaibleCrew_Click" >
                                  <i class="bi bi-pencil-fill"></i>
                           </asp:LinkButton>
                          <table class="table">
                             <thead>
                                <tr>
                                  <th scope="col">Position</th>
                                  <th scope="col">Name</th>
                                  <th scope="col">Surname</th>
                                  <th scope="col">Gender</th>
                                  <th scope="col">DNI</th>
                                  <th scope="col"></th>
                                </tr>
                             </thead>
                          <tbody>
                               <asp:Repeater ID="rptFlightEmployee" runat="server">
                                    <ItemTemplate>
                                      <tr>
                                        <td><%# Eval("Position") %></td>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Surname") %></td>
                                        <td><%# Eval("Gender") %></td> 
                                        <td><%# Eval("Dni") %></td>                                                                                                     
                                        <td>
                                         <asp:LinkButton ID="btnDeleteEmployeeFlight" runat="server"  class="btn btn-secondary" OnClick="btnDeleteEmployeeFlight_Click"  OnClientClick="return confirm('¿Are you sure that do you want delete this employee ?')"  CommandArgument='<%# Eval("IdEmployee") %>'>
                                             <i class="bi bi-trash"></i> 
                                         </asp:LinkButton>                                                                                 
                                        </td>
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>

                         </tbody>
                        </table>
                     </div>
                     <%------------------------------------------      ITINERARIO       ----------------------------------------------%>
                     <div  class="ProfileBox" style="margin-top: 20px;">   
                       <h2> Itinerary </h2>

                         <div class="row">
            <div class="col-md-6">
                
                <asp:Label class="text-dark" ID="lblDepartureAirport"  Text="Departure airport" runat="server"></asp:Label>
                <div class="input-group mb-3">
                    <span class="input-group-text" style="background-color: rgba(0, 0, 0, 0.1);"><img src="/IconSidebar/departure_icon.svg" alt="Icon" style="height: 1rem; width: auto;" /></span>
                       <asp:DropDownList ID="ddlDepartureAirport" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div>
                    <asp:Label class="text-dark" ID="lblDepartureFlight"  Text="Departure Flight Date" runat="server"></asp:Label>
                    <asp:TextBox class="form-control form-control-sm rounded"  ID="txtDepartureFlight" type="date"  data-date-format="dd/mm/yyyy" runat="server"></asp:TextBox><br />
                </div>
                
                <div>
                    <asp:Label class="text-dark" ID="LblFlightHour"  Text="Departure Flight Hour" runat="server"></asp:Label>
                    <asp:TextBox ID="TxbTimePickeddepature" class="form-control form-control-sm rounded" style="max-width: 500px;" type="time" runat="server"></asp:TextBox>
                </div>
                 <div>
                    <asp:Label class="text-dark" ID="lblEta"  Text="ETA" runat="server"></asp:Label>
                    <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  ID="txtEta" runat="server" ReadOnly="true"></asp:TextBox><br />
                </div> 
                 <asp:Label class="text-dark" ID="lblPassengers"  Text="Passengers Flight" runat="server"></asp:Label>
                 <div class="input-group mb-3">
                    <span class="input-group-text"><i class="bi bi-people-fill"></i></span>
                    <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  ID="txtPassengers" runat="server" ReadOnly="true"></asp:TextBox><br />
                </div>
            </div>

            <div class="col-md-6">
    
               <asp:Label class="text-dark" ID="lblArriveAirport"  Text="Arrive airport" runat="server"></asp:Label>
                <div class="input-group mb-3">
                    <span class="input-group-text" style="background-color: rgba(0, 0, 0, 0.1);"><img src="/IconSidebar/arrival_icon.svg" alt="Icon" style="height: 1.2rem; width: auto;" /></span>
                       <asp:DropDownList ID="ddlArriveAirport" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div>
                    <asp:Label class="text-dark" ID="lblArrivalFlight"  Text="Arrival Flight Date" runat="server"></asp:Label>
                    <asp:TextBox class="form-control form-control-sm rounded"  ID="txtArrivalFlight" type="date"  data-date-format="dd/mm/yyyy" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label class="text-dark" ID="lblArrivalFlihtHour"  Text="Arrival Flight Hour" runat="server"></asp:Label>
                    <asp:TextBox ID="txtArrivalFlihtHour" class="form-control form-control-sm rounded" style="max-width: 500px;" type="time" runat="server"></asp:TextBox>
                </div>

                 <div>
                    <asp:Label class="text-dark" ID="lblFlightHours"  Text="Flight hours" runat="server"></asp:Label>
                    <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  ID="txtFlightHours" runat="server" ReadOnly="true"></asp:TextBox><br />
                </div>
                 <asp:Label class="text-dark" ID="lblAircraft"  Text="Aircraft Flight" runat="server"></asp:Label>
                 <div class="input-group mb-3">
                    <asp:DropDownList ID="DropDownAircraft" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                </div>
                <div class="input-group mb-3">
                   <textarea id="updateTrip" class="form-control" rows="4" placeholder="Update Trip"></textarea>
                </div>
            </div>  
                    
                    
        </div>
        </div>
                           
                
               







                        <%--  <div>       

                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;"  placeholder="Name" ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="Label2"  Text="Flight Arrival" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="DNI" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="Label3" Text="Flight Departure" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="TextBox3"  placeholder="Surname" runat="server"></asp:TextBox><br />              
                            <asp:Label class="text-dark" ID="Label4" Text="Airport Arrival"  runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded"  style="max-width: 500px;" placeholder="Cellphone" ID="TextBox4" runat="server"></asp:TextBox><br />                          
                            <asp:Label class="text-dark" ID="Label5" Text="AirportDeparture" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="TextBox5" placeholder="Gender" runat="server" MaxLength="1"></asp:TextBox><br />                          
                       </div> --%> 
                
              
            </asp:Panel>
             
          
             
            <%------------------  PANEL  EDITAR PASAJERO   ---------------%>

                  <asp:Panel ID="panelEditPassengers" runat="server" CssClass="hidden">
       

                     <div class="col-4" style="margin-top: 10px; margin-bottom: 10px; margin-left: auto; margin-right: auto;">
                    <div  class="ProfileBox">
                        
                           <center>                         
                                  <h1> Passenger flight  </h1>
                                <br/>
                           </center>
        
                                                    
                            <div>   
                            <asp:Label class="text-dark" ID="lblNameP"  Text="Name" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtNameP" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="lblDNIP" Text="DNI"   runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtDNIP" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-dark" ID="lblLastNameP" Text="Surname"  runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtLastNameP"  runat="server"></asp:TextBox><br />                                     
                            <asp:Label class="text-dark" ID="lblGenderP" Text="Gender"  runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" ID="txtGenderP"  runat="server" MaxLength="1"></asp:TextBox><br />                          
                       
                             <div style="margin-top: 10px;">
                                          <asp:LinkButton ID="BtnUpdatePassenger" runat="server" Text="Save changes" class="btn btn-secondary" OnClick="BtnUpdatePassenger_Click" OnClientClick="return confirm('¿Are you sure that do you want edit this passenger ?')"     />     
                            </div>          
                            </div>
                           
                    </div>
            </div>                  



                       
            </asp:Panel>
            
            
     

          

                  <asp:Panel ID="panelEditItinerary" runat="server" CssClass="hidden">
                 <center>







                 </center>           
            </asp:Panel>

             <%------------------  Agregar empleado a vuelo  ---------------%>
            <asp:Panel ID="panelEditCrew" runat="server" CssClass="hidden">
                 <center>
                        <h1>Crew Flight</h1>
                       <div class="col-12" style="margin-top: 20px; margin-bottom: 20px; margin-left: auto; margin-right: auto;">
                        <table id="tablaEmpleados" class="table table-striped" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Position</th>
                                    <th>Name</th>
                                    <th>Surname</th>                                   
                                    <th>DNI</th>
                                    <th>Gender</th>
                                    <th>Available</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptEditEmployees" runat="server">
                                    <ItemTemplate>
                                      <tr>
                                        <td><%# Eval("Position") %></td>
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Surname")%></td>
                                        <td><%# Eval("Dni") %></td>
                                        <td><%# Eval("Gender") %></td>
                                        <td><%# Eval("Available") %></td>
                                        <td>
                                         <asp:LinkButton ID="btnAddcreW" runat="server"  class="btn btn-secondary" OnClick="btnAddcreW_Click" OnClientClick="return confirm('¿Are you sure that do you want to add this employee ?')"  CommandArgument='<%# Eval("IdEmployee") %>'>
                                            <i class="bi bi-plus-square"></i>
                                         </asp:LinkButton>                                                                                
                                        </td>                                   
                                      </tr>  
                                    </ItemTemplate>
                               </asp:Repeater>
                         
                            </tbody>
                        </table>
                           </div>
                    </center>           
        
            </asp:Panel>
                </ContentTemplate>       
            </asp:UpdatePanel>

             </div>
         </div>
      </div>
          
           

        <%-----------------------------------------------------     MODALES         ----------------------------------------------%>

    <div class="modal fade" id="staticBackdrop2" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                            
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">

                                        <asp:FileUpload ID="fileUpload1" runat="server" enctype="multipart/form-data"/>

                                    </div>
                                    <div class="modal-footer">
                                    <asp:Button ID = "ChangePhoto2" class="btn btn-primary" runat="server" Text="Change photo" Onclick="ChangePhoto2_Click" />
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






             <%-- <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                    You want to modify the fields?
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID = "btnEditProfile" class="btn btn-primary" runat="server" Text="Yes" Onclick="btnEditProfile_Click" />
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    </div>
                                </div>
                                </div>
                            </div>--%>



   

       <%-- -

        <div class="modal fade" id="menuEdit" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                            
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                      <center>
                                      <div>
                                           <asp:Button ID="btnEditCrew" runat="server" Text="Edit Crew" class="btn btn-secondary" OnClick="btnEditCrew_Click" />
                                      </div>                
                                      <div style="margin-top: 10px;">
                                          <asp:Button ID="btnEditPassengers" runat="server" Text="Edit Passengers" class="btn btn-secondary" OnClick="btnEditPassengers_Click" />
                                     </div>
                                     <div style="margin-top: 10px;">
                                          <asp:Button ID="btnEditItinerary" runat="server" Text="Edit Itinerary" class="btn btn-secondary" OnClick="btnEditItinerary_Click" />
                                     </div>
                                      </center>
                                    </div>
                                
                                    </div>
                                </div>
                                </div>
                            </div>
             --%>
</asp:Content>


