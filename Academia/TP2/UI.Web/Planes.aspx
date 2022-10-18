<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListadoPlanes" runat="server" AutoGenerateColumns="false"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Plan" DataField="ID" />
                <asp:BoundField HeaderText="Descripcion Plan" DataField="Descripcion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" /> 
            </Columns>
        </asp:GridView>
    </asp:Panel>

     <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">

        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label1" runat="server" Text="ID Especialidad: "></asp:Label>
        <asp:TextBox ID="IdEspecialidad" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorDescripcion" 
            runat="server"
            ErrorMessage="Por favor ingrese una descripción" 
            ControlToValidate="descripcionTextBox"
            Display="Dynamic" 
            ForeColor="red"
            ValidationGroup="a"
            SetFocusOnError="True">
            *
        </asp:RequiredFieldValidator>
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