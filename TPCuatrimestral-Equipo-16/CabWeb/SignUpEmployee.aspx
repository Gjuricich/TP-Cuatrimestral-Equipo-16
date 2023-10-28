<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="SignUpEmployee.aspx.cs" Inherits="CabWeb.SignUpEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: url('3.jpg') no-repeat center center fixed;
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
    <div class="container" style="margin-bottom:5%;">
        <center>
            <div class="row">
                <div class="col-md-4 offset-md-4">
                    <div class="SignUpBox">
                        <h5 class="display-1 text-dark">Sign up employee</h5>
                        <div class="form-group">
                            <label for="Mail"></label>
                            <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" placeholder="User" required></asp:TextBox>
                        </div>
                        <div class="form-group" style="margin-bottom:5%;">
                            <label for="Password"></label>
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                        </div>
                        <asp:Label class="text-secondary" ID="lblPosition" runat="server" Text="Position:"></asp:Label>
                        <select class="form-select" style="margin-bottom: 5%;">
                            <option selected>Select option</option>
                            <option value="1">Pilot</option>
                            <option value="2">Hostess</option>
                        </select>


                        <asp:Button class="btn btn-primary" ID="btnSignUpEmployee" runat="server" Text="Sign Up" OnClick="btnSignUpEmployee_Click" />
                        <a href="Login.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>
            </div>
        </center>
    </div>
    
</asp:Content>
