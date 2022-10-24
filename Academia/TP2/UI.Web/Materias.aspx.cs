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
    public partial class Materias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Administrador")
            {
                if (!Page.IsPostBack)
                {
                    try 
                    {
                        this.ddlPlan.DataSource = PlanLogic.GetAll();
                        this.ddlPlan.DataBind();
                        this.LoadGrid();
                        lblError.Text = "";
                    }
                    catch(Exception ex)
                    {
                        lblError.Text = ex.Message;
                    }   
                }
            }
            else
            {
                this.lblPlan.Visible = false;
                this.ddlPlan.Visible = false;
                this.gridMaterias.Visible = false;
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

        private MateriaLogic _Logic;

        public MateriaLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new MateriaLogic();
                }
                return _Logic;
            }
        }

        private PlanLogic _PlanLogic;

        public PlanLogic PlanLogic
        {
            get
            {
                if (_PlanLogic == null)
                {
                    _PlanLogic = new PlanLogic();
                }
                return _PlanLogic;
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


        private Plan SelectedPlan
        {
            get;
            set;
        }

        private Materia Entity
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

        protected void LoadGrid()
        {
            try
            {
                SelectedPlan = PlanLogic.GetOne(int.Parse(ddlPlan.SelectedValue));
                this.gridMaterias.DataSource = this.Logic.GetMateriasPlan(SelectedPlan);
                this.gridMaterias.DataBind();
            } 
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPlan = PlanLogic.GetOne(int.Parse(ddlPlan.SelectedValue));
            this.gridMaterias.SelectedIndex = -1;
            this.SelectedID = 0;
            this.LoadGrid();
        }

        private void loadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtHSSemanales.Text = this.Entity.HSSemanales.ToString(); ;
            this.txtHSTotales.Text = this.Entity.HSTotales.ToString();
        }

        private void EnableForm(bool enable)
        {
            this.txtDescripcion.Enabled = enable;
            this.txtHSSemanales.Enabled = enable;
            this.txtHSTotales.Enabled = enable;
            this.ddlPlan.Enabled = !enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHSSemanales.Text = string.Empty;
            this.txtHSTotales.Text = string.Empty;
        }

        private void LoadEntity(Materia mat)
        {
            mat.Plan = new Plan();
            mat.Descripcion = this.txtDescripcion.Text;
            mat.HSSemanales = int.Parse(this.txtHSSemanales.Text);
            mat.HSTotales = int.Parse(this.txtHSTotales.Text);
            mat.Plan.ID = int.Parse(ddlPlan.SelectedValue);
        }

        private void SaveEntity(Materia mat)
        {
            try { 
                this.Logic.Save(mat);
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridMaterias.SelectedValue;
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
                this.ddlPlan.Enabled = false;
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
            this.ddlPlan.Enabled = true;
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gridMaterias.SelectedIndex = -1;
                    this.SelectedID = 0;
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Materia();
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
            this.ddlPlan.Enabled = true;
            this.formPanel.Visible = false;
        }
    }
}