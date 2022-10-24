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
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Administrador")
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        this.LoadGrid();
                        this.ddlMateria.DataSource = MateriaLogic.GetAll();
                        this.ddlMateria.DataBind();
                        this.UpdateDdlComision();
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
                this.gridCursos.Visible = false;
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

        CursoLogic _Logic;

        private CursoLogic Logic
        {
            get
            {
                if (_Logic == null)
                {
                    _Logic = new CursoLogic();
                }
                return _Logic;
            }
        }

        MateriaLogic _MateriaLogic;

        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_MateriaLogic == null)
                {
                    _MateriaLogic = new MateriaLogic();
                }
                return _MateriaLogic;
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

        private Curso Entity
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
                this.gridCursos.DataSource = this.Logic.GetAll();
                this.gridCursos.DataBind();
            }
            catch(Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateDdlComision();
        }

        private void UpdateDdlComision()
        {
            ComisionLogic cl = new ComisionLogic();
            try
            {
                Materia mat = MateriaLogic.GetOne(int.Parse(ddlMateria.SelectedValue));
                SelectedPlan = mat.Plan;
                this.ddlComision.DataSource = cl.GetComisionesPlan(SelectedPlan);
                this.ddlComision.DataBind(); 
                this.LoadGrid();
                lblError.Text = "";
            } catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void loadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtAnioCalendario.Text = this.Entity.AnioCalendario.ToString();
            this.txtCupo.Text = this.Entity.Cupo.ToString();
            this.ddlComision.SelectedValue = this.Entity.Comision.ID.ToString();
            this.ddlMateria.SelectedValue = this.Entity.Materia.ID.ToString();     
        }

        private void EnableForm(bool enable)
        {
            this.txtAnioCalendario.Enabled = enable;
            this.txtCupo.Enabled = enable;
            this.ddlMateria.Enabled = !enable;
            this.ddlComision.Enabled = !enable;
        }

        private void ClearForm()
        {
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
        }

        private void LoadEntity(Curso cur)
        {
            cur.Materia = new Materia();
            cur.Comision = new Comision();
            cur.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
            cur.Cupo = int.Parse(this.txtCupo.Text);
            cur.Materia.ID = int.Parse(ddlMateria.SelectedValue);
            cur.Comision.ID = int.Parse(ddlComision.SelectedValue);
        }

        private void SaveEntity(Curso cur)
        {
            try
            {
                this.Logic.Save(cur);
                lblError.Text = "";
            } catch(Exception ex)
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
            this.SelectedID = (int)this.gridCursos.SelectedValue;
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
                this.ddlComision.Enabled = false;
                this.ddlMateria.Enabled = false;
                this.loadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.ddlComision.Enabled = true;
            this.ddlMateria.Enabled = true;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    if(! (CursoLogic.ExisteCurso(this.Entity.AnioCalendario, this.Entity.Comision.ID, this.Entity.Materia.ID)))
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        lblError.Text = "";
                    }
                    else
                    {
                        lblError.Text = "Ya existe un curso para el año, materia y comisión seleccionados";
                    }
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gridCursos.SelectedIndex = -1;
                    this.SelectedID = 0;
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
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