<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div style="height: 20px;"></div>
        <h2>Planes</h2>
         
        <br />
    
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gvListadoPlanes" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID"
                CssClass="grid"
                OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="ID Plan" DataField="ID" />
                    <asp:BoundField HeaderText="Descripcion Plan" DataField="Descripcion" />
                    <asp:BoundField DataField="Especialidad.Descripcion" HeaderText="Especialidad" />
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

        <div>
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidatorDescripcion" 
                runat="server"
                ErrorMessage="Por favor ingrese una descripción" 
                ControlToValidate="txtDescripcion"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
            <asp:DropDownList ID="ddlEspecialidad" runat="server" DataTextField="Descripcion" DataValueField="ID"></asp:DropDownList>
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