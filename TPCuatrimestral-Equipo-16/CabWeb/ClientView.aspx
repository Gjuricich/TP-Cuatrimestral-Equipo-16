<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="CabWeb.ClientView" %>

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


   
        <asp:FileUpload ID="fileUpload1" runat="server" enctype="multipart/form-data"/><br />
    <asp:Button ID = "ChangePhoto" class="btn btn-primary" runat="server" Text="Change photo" Onclick="ChangePhoto2_Click"/>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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


                           <a href="EditClient.aspx" class="btn btn-primary" style="margin-top:5%;">Edit Profile</a>
           

                           <img src='<%:ProfilePhoto%>' alt="Foto" style="width: 200px; height: 200px; border-radius: 50%;" />
           
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
               
                           <div class="centered-inputs DefaultBox" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%);">
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
                                        <input type="number" id="passengerInput" runat="server" min="1" max="10" style="background-color: transparent; max-width: 600%;">
                                      </div>
                                    <%-- <div class="col"  >
                                    <%--<asp:button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:4%;" runat="server"> Search </asp:button>--%>

                                    <%-- </div>--%>
                                    <asp:Button ID="Bookflight" runat="server" class="btn btn-outline-secondary" OnClick="Bookflight_Click" Text="Book flight" Style="font-weight: bold; border-color: dimgrey; margin-top: 4%;" />

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

                          <%else if (CurrentContent == 5)
                        {%>
                        <center>
                            <h1>Your Reservations</h1>

                            <div class="row" style="margin-top: 50px; margin-left: 25px; margin-right: 25px; margin-bottom: 50px;overflow:auto">
                                <asp:Repeater ID="rptActiveBokings" runat="server">
                                    <ItemTemplate>
                                        <div class="col-12 col-md-6 col-lg-4 mb-2" style="background-color: rgba(0, 0, 0, 0.5);">
                                            <center>
                                                <div style="max-width: 18rem;">
                                                    <center>
                                                        <img src="https://th.bing.com/th/id/R.5980a84df020a575b1e6b9e4d24c265e?rik=phr7zp%2fsNPdVWA&pid=ImgRaw&r=0" alt="Foto" style="width: 100px; height: 100px; border-radius: 50%;" />
                                                    </center>
                                                    <p>Origin: <%# Eval("Origin.NameCity") %></p>
                                                    <p>Destiny: <%# Eval("Destination.NameCity") %></p>
                                                    <p>Date of booking: <%# Eval("DateBooking") %></p>
                                                    <p>Date of petition: <%# Eval("SolicitudDate") %></p>
                                                    <p>State of reservation: <%# Eval("StateBooking") %></p>
                                                </div>
                                            </center>
                                        </div>

                                    </ItemTemplate>
                        </asp:Repeater>
                    </div>
       
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
