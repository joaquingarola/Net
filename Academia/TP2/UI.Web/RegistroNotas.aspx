﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
    <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="true" DataTextField="Descripcion" DataValueField="ID" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged"></asp:DropDownList>
    
    <asp:GridView ID="gridRegistroNotas" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID"
        OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowDataBound="gridRegistroNotas_RowDataBound" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="Alumno.DescripcionFull" HeaderText="Alumno" />
            <asp:BoundField DataField="Condicion" HeaderText="Condición" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>

    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>

    <asp:Panel ID="gridActionsPanel" runat="server" HorizontalAlign="Center">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar condición</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblAlumni" runat="server" Text="Alumno: "></asp:Label>
        <asp:TextBox ID="txtAlumno" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="lblCondicion" runat="server" Text="Condición: "></asp:Label>
        <asp:DropDownList ID="ddlCondicion" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCondicion_SelectedIndexChanged"></asp:DropDownList>
    
        <br />
    
        <asp:Label ID="lblNota" runat="server" Text="Nota: "></asp:Label>
        <asp:DropDownList ID="ddlNota" runat="server"></asp:DropDownList>
    

        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="a" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>