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
    public partial class Personas : System.Web.UI.Page
    {
        PersonaLogic _Logic;

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

        private PersonaLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new PersonaLogic();
                }
                return _Logic;
            }
        }

        private Persona Entity
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
                        this.LoadGrid();
                        this.ddlTipoPersona.DataBind();
                        PlanLogic pl = new PlanLogic();
                        this.ddlPlan.DataSource = pl.GetAll();
                        this.ddlPlan.DataBind();
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
                this.gridPersonas.DataSource = this.Logic.GetAll();
                this.gridPersonas.DataBind();
                this.ddlTipoPersona.DataBind();
                this.ddlPlan.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
}

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)gridPersonas.SelectedValue;
            this.formPanel.Visible = false;
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtApellido.Text = Entity.Apellido;
            txtDireccion.Text = Entity.Direccion;
            txtEmail.Text = Entity.Email;
            txtFechaNacimiento.Text = Entity.FechaNacimiento.ToString();
            ddlTipoPersona.SelectedValue = Entity.TipoPersona.ToString();
            ddlPlan.SelectedValue = Entity.Plan.ID.ToString();
            txtLegajo.Text = Entity.Legajo.ToString();
            txtNombre.Text = Entity.Nombre.ToString();
            txtTelefono.Text = Entity.Telefono;
        }

        private void LoadEntity(Persona per)
        {
            per.Plan = new Plan();
            per.Apellido = txtApellido.Text;
            per.Direccion = txtDireccion.Text;
            per.Email = txtEmail.Text;
            per.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            per.Plan.ID = int.Parse(ddlPlan.SelectedValue);
            per.Legajo = int.Parse(txtLegajo.Text);
            per.Nombre = txtNombre.Text;
            per.Telefono = txtTelefono.Text;
            per.TipoPersona = getSelected(); ;
        }

        protected Persona.TipoPersonas getSelected()
        {
            Persona.TipoPersonas tipoPers;
            if (ddlTipoPersona.SelectedValue == "Alumno") 
            {
                tipoPers = Persona.TipoPersonas.Alumno;
            }
            else
            {
                tipoPers = Persona.TipoPersonas.Profesor;
            }
            return tipoPers;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void SaveEntity(Persona per)
        {
            try { 
                this.Logic.Save(per);
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
                    this.gridPersonas.SelectedIndex = -1;
                    this.SelectedID = 0;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
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
            this.txtApellido.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtFechaNacimiento.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtNombre.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.ddlTipoPersona.Enabled = enable;
            this.ddlPlan.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            try { 
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
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtFechaNacimiento.Text = string.Empty;
            this.txtLegajo.Text = string.Empty; ;
            this.txtNombre.Text = string.Empty; ;
            this.txtTelefono.Text = string.Empty; ;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
        }
    }
}