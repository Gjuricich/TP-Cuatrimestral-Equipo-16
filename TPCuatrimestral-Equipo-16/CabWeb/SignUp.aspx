<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CabWeb.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: url('2.jpg') no-repeat center center fixed;
            background-size: cover;
        }

        .SignUpBox {
            background-color: rgba(169, 169, 169, 0.7);
            padding: 20px;
            border-radius: 5px;
            margin-top: 140px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="container">
       <center>
        <div class="row">
            <div class="col-md-4 offset-md-4">
                <div class="SignUpBox">
                    
                    <%-- Acá van las cajas de texto botones etc--%>


                </div>
            </div>
        </div>
      </center>
    </div>
</asp:Content>
