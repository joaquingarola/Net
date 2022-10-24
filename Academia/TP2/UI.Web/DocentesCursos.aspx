<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
    <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="true" DataTextField="Descripcion" DataValueField="ID" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged"></asp:DropDownList>
    
    
    <asp:GridView ID="gridDocenteCurso" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID"
        OnSelectedIndexChanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Docente.DescripcionFull" HeaderText="Docente" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
    <br />
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblDocente" runat="server" Text="Docente: "></asp:Label>
        <asp:DropDownList ID="ddlDocente" runat="server" DataTextField="DescripcionFull" DataValueField="ID"></asp:DropDownList>
    
        <br />
    
        <asp:Label ID="lblCargo" runat="server" Text="Cargo: "></asp:Label>
        <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
    

        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="a" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
