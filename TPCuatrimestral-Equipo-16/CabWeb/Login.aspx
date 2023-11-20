<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CabWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <style>
        body {
            background: url('2.jpg') no-repeat center center fixed;
            background-size: cover;
        }

        .loginBox {
            background-color: rgba(169, 169, 169, 0.7);
            padding: 20px;
            border-radius: 5px;
            margin-top: 140px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container" style="margin-bottom:5%;">
       <center>
        <div class="row">
            <div class="col-md-4 offset-md-4">
                <div class="loginBox">
                    <h2 class="text-center"> AirJets </h2>               
                        <div class="form-group">
                            <label for="Mail"></label>
                            <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" placeholder="User"></asp:TextBox>
                         
                        </div>
                        <div class="form-group">
                            <label for="Password"></label>
                            <asp:TextBox runat="server" ID="txtPassword"  TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>     
                        </div>  
                        <div>
                        <asp:Button Text="Log in" runat="server" OnClick="liveAlertBtn_Click" CssClass="btn btn-primary btn-block" ID="liveAlertBtn" style="margin-bottom: 50px; margin-top: 20px" />
                        <a class="btn btn-secondary text-light text-decoration-none" href="Default.aspx" style="margin-bottom: 50px; margin-top: 20px"><strong>Back</strong></a><br />                 
                        <a class="btn btn-outline-secondary" style="font-weight: bold; border-color: dimgrey;" href="SignUp.aspx"><strong>Register</strong></a>                 
                </div>
            </div>
        </div>
            </div>
      </center>
    </div>

      <%-----------------------------------------------------     MODAL ADVERTENCIA     ----------------------------------------------%>
    <div class="modal fade" id="errorMessage" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div style="text-align: center; margin-bottom: 10px;">
                    <img src="/images/ShowMessage/Yellow-Warning.png" alt="Advertencia" style="width: 50px; height: 50px;">
                </div >
                <p style="text-align: center;">The user mail or password is incorrect!</p>
            </div>
        </div>
    </div>
</div>


</asp:Content>




