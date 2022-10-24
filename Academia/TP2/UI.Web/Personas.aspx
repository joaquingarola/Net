<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" HorizontalAlign="Center">
            <br />
            Personas<br /> &nbsp;
        <asp:GridView ID="gridPersonas" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="TipoPersona" HeaderText="Tipo de Persona" />
                <asp:BoundField DataField="Plan.DescripcionFull" HeaderText="Plan" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">

        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server"
            ErrorMessage="Por favor ingrese un nombre" 
            ControlToValidate="txtNombre"
            Display="Dynamic" 
            ForeColor="red"
            ValidationGroup="a"
            SetFocusOnError="True">
            *
        </asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator2" 
            runat="server"
            ErrorMessage="Por favor ingrese un apellido" 
            ControlToValidate="txtApellido"
            Display="Dynamic" 
            ForeColor="red"
            ValidationGroup="a"
            SetFocusOnError="True">
            *
        </asp:RequiredFieldValidator>

        &nbsp;<br />
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLegajo" Display="Dynamic" ErrorMessage="Por favor ingrese un legajo" ForeColor="red" SetFocusOnError="True" ValidationGroup="a">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion" Display="Dynamic" ErrorMessage="Por favor ingrese una direccion" ForeColor="red" SetFocusOnError="True" ValidationGroup="a">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefono" Display="Dynamic" ErrorMessage="Por favor ingrese un telefono" ForeColor="red" SetFocusOnError="True" ValidationGroup="a">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Por favor ingrese un Email" ForeColor="red" SetFocusOnError="True" ValidationGroup="a">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="DateTime"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha de nacimiento" ForeColor="red" SetFocusOnError="True" ValidationGroup="a">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo de Persona: "></asp:Label>
        <asp:DropDownList ID="ddlTipoPersona" runat="server" DataSourceID="dsTipo" DataTextField="valor" DataValueField="valor"></asp:DropDownList>
        <asp:SqlDataSource ID="dsTipo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT 'Alumno' valor union select 'Profesor' valor"></asp:SqlDataSource>
        
        <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server" DataTextField="DescripcionFull" DataValueField="ID"></asp:DropDownList>
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
            <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="a" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
