<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div style="height: 20px;"></div>
        <h2>Cursos</h2>
        <asp:GridView ID="gridCursos" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID"
            CssClass="grid"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Materia.Descripcion" HeaderText="Materia" />
                <asp:BoundField DataField="Comision.Descripcion" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupos" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Button"/>
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>

        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
        <br />

        <asp:Panel ID="gridActionsPanel" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn edit">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn delete">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn new">Nuevo</asp:LinkButton>
        </asp:Panel>
    </div>
    <asp:Panel ID="formPanel" Visible="false" runat="server" Font-Bold="False" CssClass="container">

        <div>
            <asp:Label ID="lblAnioCalendario" runat="server" Text="Año calendario: "></asp:Label>
            <asp:TextBox ID="txtAnioCalendario" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidatorDescripcion" 
                runat="server"
                ErrorMessage="Por favor ingrese un año calendario" 
                ControlToValidate="txtAnioCalendario"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label ID="lblMateria" runat="server" Text="Materia: "></asp:Label>
            <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="true" DataTextField="Descripcion" DataValueField="ID" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <br />

        <div>
            <asp:Label ID="lblComision" runat="server" Text="Comision: "></asp:Label>
            <asp:DropDownList ID="ddlComision" runat="server" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
        </div>
        <br />
    
        <div>
            <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
            <asp:TextBox ID="txtCupo" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server"
                ErrorMessage="Por favor ingrese el cupo del curso" 
                ControlToValidate="txtCupo"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
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
