<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <h1>Bienvenido al sistema!</h1>
        <h3 id="nombreUsuario" runat="server"></h3>
        <h4 id="sessionActual" runat="server" style="margin: 0px;"></h4>
    </div>
</asp:Content>
