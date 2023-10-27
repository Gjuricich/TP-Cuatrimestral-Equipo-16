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

     <div class="container">
       <center>
        <div class="row">
            <div class="col-md-4 offset-md-4">
                <div class="loginBox">
                    <h2 class="text-center"> e-Cab </h2>               
                        <div class="form-group">
                            <label for="Username"></label>
                            <asp:TextBox runat="server" ID="Username" CssClass="form-control" placeholder="User" required></asp:TextBox>
                         
                        </div>
                        <div class="form-group">
                            <label for="Password"></label>
                            <asp:TextBox runat="server" ID="Password"  TextMode="Password" CssClass="form-control" placeholder="Password" required></asp:TextBox>     
                        </div>  
                        <div>
                        <asp:Button Text="Log in" runat="server" OnClick="liveAlertBtn_Click" CssClass="btn btn-primary btn-block" ID="liveAlertBtn" style="margin-bottom: 50px; margin-top: 20px" />
                        <a class="btn btn-secondary text-light text-decoration-none" href="Default.aspx" style="margin-bottom: 50px; margin-top: 20px"><strong>Back</strong></a>                 
                        </div>
                            <div class="text-center mt-2">
                        <a class="btn btn-primary btn-block" href="SignUp.aspx"><strong> Sign Up </strong></a>
                    </div>
                    <div class="text-center mt-2">
                        <a class="btn btn-primary btn-block" href="SignUpEmployed.aspx"><strong> Sign Up Employed </strong></a>
                    </div>
                </div>
            </div>
        </div>
      </center>
    </div>

</asp:Content>




