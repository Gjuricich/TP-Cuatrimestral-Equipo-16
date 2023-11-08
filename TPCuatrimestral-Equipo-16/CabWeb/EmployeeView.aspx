<%@ Page Title="" Language="C#" MasterPageFile="~/Cab.Master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="CabWeb.EmployeeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <%if (Session["EmployeeLogged"] == null)
        {
            Response.Redirect("Default.aspx");
        }%>
</asp:Content>
