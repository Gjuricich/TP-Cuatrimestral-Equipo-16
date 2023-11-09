﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="CabWeb.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["ClientLogged"] == null)
        {
            Response.Redirect("Default.aspx");
        }%>

    <style>
        body {
            background: url('montain.jpg') no-repeat center center fixed;
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


    <asp:ScriptManager ID="ScriptManager1" runat="server" />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-1" style="width: 9rem">
                    <div class="d-flex flex-column flex-shrink-0 bg-light" style="width: 9rem;">
                        <ul class="nav nav-pills nav-flush flex-column mb-auto text-center justify-content-center ">
                            <li>
                                <br />
                                <asp:LinkButton ID="linkButtonUser" runat="server" OnClick="linkButtonUser_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (5).svg"" alt="Descripción de la imagen"style="height:40px;width:40px;"/>
                                </asp:LinkButton>

                            </li>
                            <li class="nav-item">
                                <asp:LinkButton ID="linkButton1" runat="server" OnClick="linkButton1_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (1).svg"g" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>
                            </li>
                            <li>
                              <%--  <asp:LinkButton ID="linkButton2" runat="server" OnClick="linkButton2_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (2).svg"" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>--%>
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

                <div class="col-11 ClientBox" id="menuContent">
       

                    <%if (CurrentContent == 0)
                        {%>
                    <center>
                        <h1>Profile</h1>
                        <h2 style="margin-bottom:2%;"><%:CurrentClient.Name + " " + CurrentClient.Surname%></h2>
           
                          <asp:Label class="text-secondary" ID="lblName" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Name" ID="txtName" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblLastName" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Surname" ID="txtLastName" runat="server" ReadOnly="true"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblEmail" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Email" ID="txtEmail" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblPassword" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Password" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblRepetPassword" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Repeat Password" ID="RepetPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblDateOfBirth" runat="server" style="color: black;" Text="Date of Birth:"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Date of Birth" ID="txtDateOfBirth" type="date" data-date-format="dd/mm/yyyy" runat="server"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
                            <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Gender (M/F/X):" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />
                            <asp:Label class="text-secondary" ID="Label4" runat="server" style="color: black;" Text="Add profile picture"></asp:Label><br />
                            <asp:FileUpload ID="fileUploadProfilePicture" runat="server" /><br />

                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:2%;">
                             Edit
                            </button>

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
                            <a href="Default.aspx" class="btn btn-primary" style="margin-top:2%;">Back</a>

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
                    <%else if (CurrentContent == 3)
                        {%>
                    <center>
                        <h1>Petition</h1>

                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Ciudad de Origen:"></asp:Label>
                            <asp:DropDownList ID="ddlCiudadOrigen" runat="server">
                                <asp:ListItem Text="Selecciona una ciudad de origen" Value="" />
                                <asp:ListItem Text="Ciudad 1" Value="Ciudad1" />
                                <asp:ListItem Text="Ciudad 2" Value="Ciudad2" />

                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblEjemplo" runat="server" Text="Ciudad de Destino:"></asp:Label>
                            <asp:DropDownList ID="ddlCiudadDestino" runat="server">
                                <asp:ListItem Text="Selecciona una ciudad de destino" Value="" />
                                <asp:ListItem Text="Ciudad 1" Value="Destino1" />
                                <asp:ListItem Text="Ciudad 2" Value="Destino2" />
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Fecha y Hora del Viaje:"></asp:Label>
                            <asp:Calendar ID="calFecha" runat="server"></asp:Calendar>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Tipo de Avión Privado:"></asp:Label>
                            <asp:DropDownList ID="ddlTipoAvion" runat="server">
                                <asp:ListItem Text="Selecciona un tipo de avión" Value="" />
                                <asp:ListItem Text="Avión 1" Value="Avion1" />
                                <asp:ListItem Text="Avión 2" Value="Avion2" />

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnReservar" runat="server" Text="Reservar Vuelo" />
                        </div>




                    
                           <div class="centered-inputs DefaultBox" style="position: absolute; top: 90%; left: 50%; transform: translate(-50%, -50%);">
                            <div class="container text-center" style="display: flex; justify-content: center; align-items: center;">
                                <div class="row " display="flex" >
                                <div class="col"  >
                                    <h4><strong>FORM</strong></h4>
                                    <input type="text" list="fromOptions" id="fromInput" style="background-color: transparent;">
                                    <datalist id="fromOptions">
                                    <option value="Buenos Aires">
                                    <option value="Bariloche">
                                    <option value="Usuahia">
                                    </datalist>
                                </div>
                                <div class="col"   >
                                    <h4><strong>TO</strong></h4>
                                    <input type="text" list="toOptions" id="toInput"  style=" background-color: transparent;  max-width: 600%;">
                                    <datalist id="toOptions">
                                    <option value="Miami">
                                    <option value="España">
                                    <option value="Costa Rica">
                                    </datalist>
                                </div>
                                <div class="col" >
                                    <h4><strong>DATE</strong></h4>
                                    <input type="date" data-date-format="dd/mm/yyyy" style=" background-color: transparent;">
                                </div>
                                <div class="col" >
                                    <h4><strong>PASSENGER</strong></h4>
                                    <input type="number" id="passengerInput" min="1" max="10" style=" background-color: transparent; max-width: 600%;">
                                </div>
                                <%-- <div class="col"  >
                                    <%--<asp:button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:4%;" runat="server"> Search </asp:button>--%>
                
                                    <%-- </div>--%>
                                    <button type="button" class="btn btn-outline-secondary" style="font-weight: bold; border-color: dimgrey; margin-top:4%;">Book flight</button>

                                </div>
                            </div>
                           </div>
                          
                    </center>
                    <%} %>
                    <%else if (CurrentContent == 4)
                        {%>
                    <center>
                        <h1>Flyes</h1>
                    </center>
                    <%} %>
              
            </div>
              
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--DataTable--%>
     <section id="historical">
    <center>
        <h1 style="margin-top:2%;">Historical</h1>
    </center>
    <div class="p-5">
        <table id="example" class="table table-striped" style="width: 100%; ">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Position</th>
                    <th>Office</th>
                    <th>Age</th>
                    <th>Start date</th>
                    <th>Salary</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tiger Nixon</td>
                    <td>System Architect</td>
                    <td>Edinburgh</td>
                    <td>61</td>
                    <td>2011-04-25</td>
                    <td>$320,800</td>
                </tr>
                <tr>
                    <td>Garrett Winters</td>
                    <td>Accountant</td>
                    <td>Tokyo</td>
                    <td>63</td>
                    <td>2011-07-25</td>
                    <td>$170,750</td>
                </tr>
                <tr>
                    <td>Ashton Cox</td>
                    <td>Junior Technical Author</td>
                    <td>San Francisco</td>
                    <td>66</td>
                    <td>2009-01-12</td>
                    <td>$86,000</td>
                </tr>
                <tr>
                    <td>Cedric Kelly</td>
                    <td>Senior Javascript Developer</td>
                    <td>Edinburgh</td>
                    <td>22</td>
                    <td>2012-03-29</td>
                    <td>$433,060</td>
                </tr>
                <tr>
                    <td>Airi Satou</td>
                    <td>Accountant</td>
                    <td>Tokyo</td>
                    <td>33</td>
                    <td>2008-11-28</td>
                    <td>$162,700</td>
                </tr>
                <tr>
                    <td>Brielle Williamson</td>
                    <td>Integration Specialist</td>
                    <td>New York</td>
                    <td>61</td>
                    <td>2012-12-02</td>
                    <td>$372,000</td>
                </tr>
                <tr>
                    <td>Herrod Chandler</td>
                    <td>Sales Assistant</td>
                    <td>San Francisco</td>
                    <td>59</td>
                    <td>2012-08-06</td>
                    <td>$137,500</td>
                </tr>

                <tr>
                    <td>Jonas Alexander</td>
                    <td>Developer</td>
                    <td>San Francisco</td>
                    <td>30</td>
                    <td>2010-07-14</td>
                    <td>$86,500</td>
                </tr>
                <tr>
                    <td>Shad Decker</td>
                    <td>Regional Director</td>
                    <td>Edinburgh</td>
                    <td>51</td>
                    <td>2008-11-13</td>
                    <td>$183,000</td>
                </tr>
                <tr>
                    <td>Michael Bruce</td>
                    <td>Javascript Developer</td>
                    <td>Singapore</td>
                    <td>29</td>
                    <td>2011-06-27</td>
                    <td>$183,000</td>
                </tr>
                <tr>
                    <td>Donna Snider</td>
                    <td>Customer Support</td>
                    <td>New York</td>
                    <td>27</td>
                    <td>2011-01-25</td>
                    <td>$112,000</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th>Name</th>
                    <th>Position</th>
                    <th>Office</th>
                    <th>Age</th>
                    <th>Start date</th>
                    <th>Salary</th>
                </tr>
            </tfoot>
        </table>
    </div>
  </section>
</asp:Content>
