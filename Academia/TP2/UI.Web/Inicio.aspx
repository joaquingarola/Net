<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="UI.Web.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="/css/Style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <asp:label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema!" CssClass="sign"></asp:label>
            <asp:label runat="server">Usuario</asp:label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="user"></asp:TextBox>
            <asp:label runat="server">Contraseña</asp:label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="pass"></asp:TextBox>
            <asp:Label class="error" ID="lblIncorrecto" runat="server"></asp:Label>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="submit"/>
            <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click" CssClass="forgot"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
