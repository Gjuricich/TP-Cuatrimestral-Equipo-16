<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CabWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

          .DefaultBox {
            background-color: rgba(169, 169, 169, 0.2);
            padding:1%;
         
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="position: relative;">
  <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel">
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img src="https://i.pinimg.com/originals/5c/b5/ee/5cb5ee6b9df3f78c2c41fefb8b2d66fd.jpg" class="d-block w-100" style="height: 100vh; width: 100%;" alt="">
      </div>
       <div class="carousel-item">
 <img src="https://w0.peakpx.com/wallpaper/234/74/HD-wallpaper-private-jet-aircraft-airplane-flight-luxurious-plane.jpg" class="d-block w-100" style=" height: 100vh; width: 100%;" alt="">
    </div>
         <div class="carousel-item">
       <img src="https://e0.pxfuel.com/wallpapers/188/677/desktop-wallpaper-big-airplane-takes-off-on-airport-high-definition-airplane-background.jpg" class="d-block w-100" style=" height: 100vh; width: 100%;" alt="">
    </div>
    </div>
  </div>

   


      <div class="centered-inputs DefaultBox" style="position: absolute; top: 20%; left: 50%; transform: translate(-50%, -50%);">
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
                <asp:button ID="BtnSearch" class="btn btn-outline-secondary" style="font-weight: bold; border-color: dimgrey; margin-top:4%;" type="button" Text="Search" OnClick="BtnSearch_Click" runat="server"></asp:button>

            </div>
        </div>
        </div>




        <%--MODAL--%>
   <%--      <div class="col"  >
               <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:4%;" runat="server"> Search </button>
            </div>--%>

         <%--<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
            <%--     <h1 class="modal-title fs-5" id="staticBackdropLabel">Modal title</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                You need to register or login to continue.
                </div>
                <div class="modal-footer">
                      <a href="Login.aspx" class="btn btn-primary">Log in</a>
                      <a href="SignUp.aspx" class="btn btn-secondary">Register</a>
                </div>
            </div>
            </div>
        </div>--%>
        <%--FIN MODAL--%>

</asp:Content>
