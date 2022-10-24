using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private UsuarioLogic _Logic;

        public UsuarioLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new UsuarioLogic();
                }
                return _Logic;
            }
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Administrador")
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        PersonaLogic pl = new PersonaLogic();
                        this.LoadGrid();
                        this.ddlPersona.DataSource = pl.GetAll();
                        this.ddlPersona.DataBind();
                        this.lblError.Text = "";
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = ex.Message;
                    }
                }
            }
            else
            {
                this.gridPanel.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = false;
                this.lblError.Text = "Autorización denegada";
            }
        }

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }

        public Persona getPersonaActual()
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p = pl.GetOne(UsuarioActual.Persona.ID);
            return p;
        }

        private void LoadGrid()
        {
            try 
            { 
                this.gridUsuarios.DataSource = this.Logic.GetAll();
                this.gridUsuarios.DataBind();
                this.ddlPersona.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        private void loadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlPersona.SelectedValue = this.Entity.Persona.ID.ToString();
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
            this.txtClave.Text = this.Entity.Clave;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridUsuarios.SelectedValue;
            this.formPanel.Visible = false;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.loadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Persona = new Persona();
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.Persona.ID = int.Parse(ddlPersona.SelectedValue);
        }

        private void SaveEntity(Usuario usuario)
        {
            try 
            { 
                this.Logic.Save(usuario);
                this.lblError.Text = "";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gridUsuarios.SelectedIndex = -1;
                    this.SelectedID = 0;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.txtNombreUsuario.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;
            this.txtClave.Visible = enable;
            this.claveLabel.Visible = enable;
            this.txtRepetirClave.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
            this.ddlPersona.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.loadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            try 
            { 
                this.Logic.Delete(id);
                this.lblError.Text = "";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.habilitadoCheckBox.Checked = false;
            this.txtNombreUsuario.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
        }
    }
}