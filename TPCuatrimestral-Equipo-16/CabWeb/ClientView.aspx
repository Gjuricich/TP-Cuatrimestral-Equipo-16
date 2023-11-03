<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="CabWeb.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["UserLogged"] == null)
        {
            Response.Redirect("Default.aspx");
        }%>
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
                                <asp:LinkButton ID="linkButton2" runat="server" OnClick="linkButton2_Click" class="nav-link py-3 border-bottom">
    <img src="/IconSidebar/svg1 (2).svg"" alt="Descripción de la imagen"style="height:40px;width:40px;" />
                                </asp:LinkButton>
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

                <div class="col-11" id="menuContent" style="background-color: grey; width: 70%; height: 800px; overflow: auto;">

                    <%if (CurrentContent == 0)
                        {%>
                    <center>
                        <h1>Profile</h1>
                        <h2><%:CurrentClient.Name + " " + CurrentClient.Surname%></h2>
                        <
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
                        <h1>Historical</h1>
                        <script>new DataTable('#example');</script>
                        <table id="example" class="table table-striped" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>Nombre del Vuelo</th>
                                    <th>Avión</th>
                                    <th>Piloto</th>
                                    <th>Lugar de Origen</th>
                                    <th>Lugar de Destino</th>
                                    <th>Duración</th>
                                    <th>Precio</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Vuelo 1A2B</td>
                                    <td>Gulfstream G650</td>
                                    <td>John Smith</td>
                                    <td>New York</td>
                                    <td>Los Angeles</td>
                                    <td>4 horas</td>
                                    <td>$800.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 3C4D</td>
                                    <td>Cessna Citation XLS</td>
                                    <td>Mary Johnson</td>
                                    <td>Los Angeles</td>
                                    <td>Miami</td>
                                    <td>5 horas</td>
                                    <td>$950.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 5E6F</td>
                                    <td>Embraer Phenom 300</td>
                                    <td>Robert Williams</td>
                                    <td>Miami</td>
                                    <td>Chicago</td>
                                    <td>3.5 horas</td>
                                    <td>$700.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 7G8H</td>
                                    <td>Hawker 800XP</td>
                                    <td>Patricia Brown</td>
                                    <td>Chicago</td>
                                    <td>Las Vegas</td>
                                    <td>4 horas</td>
                                    <td>$800.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 9I0J</td>
                                    <td>Learjet 45XR</td>
                                    <td>Michael Davis</td>
                                    <td>Las Vegas</td>
                                    <td>San Francisco</td>
                                    <td>2.5 horas</td>
                                    <td>$500.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 1K2L</td>
                                    <td>Gulfstream G550</td>
                                    <td>Linda Wilson</td>
                                    <td>New York</td>
                                    <td>Chicago</td>
                                    <td>3 horas</td>
                                    <td>$600.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 3M4N</td>
                                    <td>Cessna Citation CJ3+</td>
                                    <td>William Lee</td>
                                    <td>Miami</td>
                                    <td>San Francisco</td>
                                    <td>5 horas</td>
                                    <td>$950.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 5O6P</td>
                                    <td>Embraer Legacy 650</td>
                                    <td>Cynthia Harris</td>
                                    <td>San Francisco</td>
                                    <td>Los Angeles</td>
                                    <td>2.5 horas</td>
                                    <td>$500.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 7Q8R</td>
                                    <td>Hawker 400XP</td>
                                    <td>John Clark</td>
                                    <td>Chicago</td>
                                    <td>New York</td>
                                    <td>3 horas</td>
                                    <td>$600.00</td>
                                </tr>
                                <tr>
                                    <td>Vuelo 9S0T</td>
                                    <td>Learjet 35A</td>
                                    <td>Mary Martin</td>
                                    <td>Las Vegas</td>
                                    <td>Chicago</td>
                                    <td>4 horas</td>
                                    <td>$800.00</td>
                                </tr>


                            </tbody>
                        </table>
                    </center>
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
    <center>
        <h1>Historical</h1>
    </center>
    <div class="p-5">
        <table id="example" class="table table-striped" style="width: 100%">
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
</asp:Content>
