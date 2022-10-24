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
    public partial class Planes : System.Web.UI.Page
    {
        PlanLogic _Logic;

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

        private PlanLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new PlanLogic();
                }
                return _Logic;
            }
        }

        private Plan Entity
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
                    try {
                        EspecialidadLogic el = new EspecialidadLogic();
                        this.LoadGrid();
                        this.ddlEspecialidad.DataSource = el.GetAll();
                        this.ddlEspecialidad.DataBind();
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

        protected void LoadGrid()
        {
            try
            {
                this.gvListadoPlanes.DataSource = this.Logic.GetAll();
                this.gvListadoPlanes.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        private void loadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlEspecialidad.SelectedValue = this.Entity.Especialidad.ID.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.ddlEspecialidad.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
        }

        private void LoadEntity(Plan plan)
        {
            plan.Especialidad = new Especialidad();
            plan.Descripcion = this.txtDescripcion.Text;
            plan.Especialidad.ID = int.Parse(ddlEspecialidad.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            try 
            { 
                this.Logic.Save(plan);
                this.lblError.Text = "";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvListadoPlanes.SelectedValue;
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

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Plan();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gvListadoPlanes.SelectedIndex = -1;
                    this.SelectedID = 0;
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.formPanel.Visible = false;
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
        }
    }
}