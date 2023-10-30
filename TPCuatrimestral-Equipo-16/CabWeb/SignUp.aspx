<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CabWeb.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: url('2.jpg') no-repeat center center fixed;
            background-size: cover;
        }

        .SignUpBox {
            background-color: rgba(169, 169, 169, 0.7);
            padding: 30px;
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
                        <h1 class="text-dark">Register</h1>
                        <br />
                        <asp:Label class="text-secondary" ID="lblName" runat="server"></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" placeholder="Name" ID="txtName" runat="server"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="lblLastName" runat="server"></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" placeholder="Surname" ID="txtLastName" runat="server"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="lblEmail" runat="server"></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" placeholder="Email" ID="txtEmail" runat="server"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="lblPassword" runat="server" ></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" placeholder="Password"  ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="lblDateOfBirth" runat="server" style="color:black;" Text="Date of Birth:"></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" placeholder="Date of Birth"  ID="txtDateOfBirth" type="date"  data-date-format="dd/mm/yyyy" runat="server"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
                        <asp:TextBox class="form-control form-control-sm rounded" ID="txtGender" placeholder="Gender (M/F/X):" runat="server" MaxLength="1"></asp:TextBox><br />
                        <asp:Label class="text-secondary" ID="Label4" runat="server" style="color:black;" Text="Add profile picture"></asp:Label><br />
                        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" /><br />
                        <br />
                        <asp:Button class="btn btn-primary" ID="btnSignUp" runat="server" Text="Register" OnClick="btnSignUp_Click" OnClientClick="return confirm('¿Do you want to submit ?')" />
                        <a href="Login.aspx" class="btn btn-primary">Back</a>
                    </div>
                </div>
            </div>
        </center>
    </div>
</asp:Content>
