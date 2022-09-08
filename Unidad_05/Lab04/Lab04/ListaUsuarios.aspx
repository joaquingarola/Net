<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Lab04.ListaUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 394px;
        }
        .auto-style1 {
            width: 144px;
        }
        .auto-style2 {
            width: 144px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsUsuarios" runat="server" DataObjectTypeName="Negocio.Usuario" DeleteMethod="BorrarUsuario" InsertMethod="AgregarUsuario" SelectMethod="GetAll" TypeName="Negocio.ManagerUsuarios" UpdateMethod="ActualizarUsuario"></asp:ObjectDataSource>
        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="odsUsuarios">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario" />
                <asp:BoundField DataField="FechaNac" HeaderText="FechaNac" SortExpression="FechaNac" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ListaUsuarios.aspx?id={0}" Text="Editar" />
            </Columns>
        </asp:GridView>
        <table border="1">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblAccion" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Apellido:
                </td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" align="right"> Nombre: </td>
                
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Tipo de Documento:</td>
                <td>
                    <asp:RadioButtonList ID="rblTipoDocumento" runat="server">
                        <asp:ListItem Value="1">DNI</asp:ListItem>
                        <asp:ListItem Value="2">LC / LE</asp:ListItem>
                        <asp:ListItem Value="3">C&#233;dula Identidad</asp:ListItem>
                        <asp:ListItem Value="4">Pasaporte</asp:ListItem>
                        <asp:ListItem Value="5">Otro</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Nro de Documento:</td>
                <td>
                    <asp:TextBox ID="txtNroDocumento" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Fecha de Nacimiento:</td>
                <td>
                    <asp:DropDownList ID="ddlDiaFechaNacimiento" runat="server" OnSelectedIndexChanged="ddlDiaFechaNacimiento_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMesFechaNacimiento" runat="server">
                        <asp:ListItem>Enero</asp:ListItem>
                        <asp:ListItem>Febrero</asp:ListItem>
                        <asp:ListItem>Marzo</asp:ListItem>
                        <asp:ListItem>Abril</asp:ListItem>
                        <asp:ListItem>Mayo</asp:ListItem>
                        <asp:ListItem>Junio</asp:ListItem>
                        <asp:ListItem>Julio</asp:ListItem>
                        <asp:ListItem>Agosto</asp:ListItem>
                        <asp:ListItem>Septiembre</asp:ListItem>
                        <asp:ListItem>Octubre</asp:ListItem>
                        <asp:ListItem>Noviembre</asp:ListItem>
                        <asp:ListItem>Diciembre</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtAnioFechaNacimiento" runat="server" MaxLength="4" Width="50px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Dirección:</td>
                <td>
                    <asp:TextBox ID="txtDirección" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Teléfono:</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Celular:</td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Nombre de Usuario:</td>
                <td>
                    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Clave:</td>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="right">
                    Confirmar Clave:</td>
                <td>
                    <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 150px" align="center">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" /></td>
                <td align="center">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
