<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div style="height: 20px;"></div>
        <h2>Usuarios</h2>
         
        <br />
    
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID"
                CssClass="grid"
                OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Persona.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Persona.Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Persona.Email" HeaderText="Email" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Button"/>
                </Columns>
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
        
        </asp:Panel>

        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>

        <asp:Panel ID="gridActionsPanel" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn edit">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn delete">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn new">Nuevo</asp:LinkButton>
        </asp:Panel>
    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="container">
        <br />
        <div>
            <asp:Label ID="lblPersona" runat="server" Text="Persona: "></asp:Label>
            <asp:DropDownList ID="ddlPersona" runat="server" DataTextField="DescripcionFull" DataValueField="ID"></asp:DropDownList>
        </div>
        <br />

        <div>
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
        </div>
        <br />

        <div>
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidatorUsuario" 
                runat="server"
                ErrorMessage="Por favor ingrese un usuario" 
                ControlToValidate="txtNombreUsuario"
                Display="Dynamic" 
                ValidationGroup="a"
                ForeColor="red"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidatorClave" 
                runat="server"
                ErrorMessage="Por favor ingrese un clave" 
                ControlToValidate="txtClave"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidatorRepetirClave" 
                runat="server"
                ErrorMessage="Por favor ingrese un clave" 
                ControlToValidate="txtRepetirClave"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
            <asp:CompareValidator 
                ID="CompareValidator1" 
                runat="server" 
                ControlToValidate="txtRepetirClave"
                ControlToCompare="txtClave"
                ErrorMessage="Las contraseñas no coinciden" 
                ForeColor="red"
                ValidationGroup="a">
                *
            </asp:CompareValidator>
        </div>
        <br />

        <asp:ValidationSummary 
            runat="server" 
            ID="ValidationSummary1" 
            DisplayMode="BulletList"
            ShowMessageBox="False" 
            ForeColor="red"
            ValidationGroup="a"
            ShowSummary="True"
        />

        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="a" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn edit">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn delete">Cancelar</asp:LinkButton>
        </asp:Panel>

    </asp:Panel>
</asp:Content>
