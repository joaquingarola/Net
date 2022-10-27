<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div style="height: 20px;"></div>
        <h2>Materias</h2>
        <div>
            <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="true" DataTextField="DescripcionFull" DataValueField="ID" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        <br />

        <asp:GridView ID="gridMaterias" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID"
            CssClass="grid"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                <asp:BoundField DataField="Plan.DescripcionFull" HeaderText="Plan" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Button"/>
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    
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
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
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
            <asp:Label ID="lblHSSemanales" runat="server" Text="Horas Semanales: "></asp:Label>
            <asp:TextBox ID="txtHSSemanales" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server"
                ErrorMessage="Por favor ingrese las horas semanales" 
                ControlToValidate="txtHSSemanales"
                Display="Dynamic" 
                ForeColor="red"
                ValidationGroup="a"
                SetFocusOnError="True">
                *
            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <asp:Label ID="lblHSTotales" runat="server" Text="Horas Totales: "></asp:Label>
            <asp:TextBox ID="txtHSTotales" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator2" 
                runat="server"
                ErrorMessage="Por favor ingrese las horas totales" 
                ControlToValidate="txtHSTotales"
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
