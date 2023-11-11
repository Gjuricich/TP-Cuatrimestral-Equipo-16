<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="EditClient.aspx.cs" Inherits="CabWeb.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        body {
            background: url('montain.jpg') no-repeat center center fixed;
            background-size: cover;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <center>
      <h1 style="margin-top:5%;">Edit profile</h1>
      <h2 style="margin-bottom:2%;"><%:CurrentClient.Name + " " + CurrentClient.Surname%></h2>

        <asp:Label class="text-secondary" ID="lblName" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Name" ID="txtName" runat="server" ReadOnly="true"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblLastName" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Surname" ID="txtLastName" runat="server" ReadOnly="true"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblEmail" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Email" ID="txtEmail" runat="server"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblPassword" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="New Password" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblRepetPassword" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Repeat Password" ID="RepetPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblDateOfBirth" runat="server" style="color: black;" Text="Date of Birth:"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Date of Birth" ID="txtDateOfBirth" type="date" data-date-format="dd/mm/yyyy" runat="server"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="lblGender" runat="server"></asp:Label>
        <asp:TextBox class="form-control form-control-sm rounded" style="max-width: 500px;" placeholder="Gender (M/F/X):" ID="txtGender" runat="server" MaxLength="1"></asp:TextBox><br />
        <asp:Label class="text-secondary" ID="Label4" runat="server" style="color: black;" Text="Add profile picture"></asp:Label><br />
        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" /><br />

        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="margin-top:2%; margin-bottom:5%;">
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
        <a href="ClientView.aspx" class="btn btn-secondary" style="margin-top:2%; margin-bottom:5%; margin-left:1%">Back</a>

   </center>
</asp:Content>
