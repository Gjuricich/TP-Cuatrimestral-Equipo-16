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
            <% foreach (CabDominio.Aircraft aircraft in aircrafts) { %>
                <div class="carousel-item<%: aircraft == aircrafts.First() ? " active" : "" %>">
                    <img src='<%: PhotoByModel(aircraft.Model) %>' class="d-block w-100" style="height: 100vh; width: 100%;" alt="">
                    <div class="carousel-caption d-none d-md-block">
                        <h2><%: aircraft.Model %></h2>
                        <p>Capacidad : <%: aircraft.PassengerCapacity %></p>
                    </div>
                </div>
            <% } %>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleSlidesOnly" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleSlidesOnly" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</div>

<script>
    // Agrega un evento para cambiar el contenido al cambiar de diapositiva
    $('#carouselExampleSlidesOnly').on('slid.bs.carousel', function () {
        var activeSlide = $('.carousel-item.active');
        var model = activeSlide.find('img').attr('alt');
        var capacity = activeSlide.find('img').attr('capacity');
        
        // Actualiza los elementos h2 y p con los nuevos valores
        activeSlide.find('h2').text(model);
        activeSlide.find('p').text('Capacidad: ' + capacity);
    });
</script>



    



    

</asp:Content>
