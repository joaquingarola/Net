<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionAlumno.aspx.cs" Inherits="UI.Web.InscripcionAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div style="height: 20px;"></div>
        <h2>Inscripción a materias</h2>

        <br />
        <asp:GridView ID="gridInscripcionAlumno" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID"
            CssClass="grid"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Materia" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Button"/>
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
   
        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>

        <asp:Panel ID="gridActionsPanel" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ID="inscripcionLinkButton" runat="server" OnClick="inscripcionLinkButton_Click" CssClass="btn edit">Inscribirse</asp:LinkButton>
        </asp:Panel>
    </div>

    <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="container">
        <div>
            <asp:Label ID="lbl1" runat="server" Text="Materia: "></asp:Label>
            <asp:Label ID="lblMateria" runat="server"></asp:Label>
        </div>
        <br />

        <div>
            <asp:Label ID="lblComision" runat="server" Text="Comisión: "></asp:Label>
            <asp:DropDownList ID="ddlComision" runat="server" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>    
        </div>
        <br />

        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="a" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn edit">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn delete">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
