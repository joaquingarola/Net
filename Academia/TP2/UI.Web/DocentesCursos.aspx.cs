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
    public partial class DocentesCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Administrador")
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        this.ddlCurso.DataSource = CursoLogic.GetAll();
                        this.ddlCurso.DataBind();
                        this.LoadGrid();
                        this.ddlDocente.DataSource = PersonaLogic.GetAll(Persona.TipoPersonas.Profesor, SelectedCurso.Materia.Plan.ID);
                        this.ddlDocente.DataBind();
                        this.ddlCargo.Items.Add("Profesor");
                        this.ddlCargo.Items.Add("Auxiliar");
                        lblError.Text = "";
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                    }
                }
            }
            else
            {
                this.lblCurso.Visible = false;
                this.ddlCurso.Visible = false;
                this.gridDocenteCurso.Visible = false;
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

        private DocenteCursoLogic _DocenteCursoLogic;

        public DocenteCursoLogic DocenteCursoLogic
        {
            get
            {
                if (_DocenteCursoLogic == null)
                {
                    _DocenteCursoLogic = new DocenteCursoLogic();
                }
                return _DocenteCursoLogic;
            }
        }

        private CursoLogic _CursoLogic;

        public CursoLogic CursoLogic
        {
            get
            {
                if (_CursoLogic == null)
                {
                    _CursoLogic = new CursoLogic();
                }
                return _CursoLogic;
            }
        }

        private PersonaLogic _PersonaLogic;

        public PersonaLogic PersonaLogic
        {
            get
            {
                if (_PersonaLogic == null)
                {
                    _PersonaLogic = new PersonaLogic();
                }
                return _PersonaLogic;
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


        private Curso SelectedCurso
        {
            get;
            set;
        }

        private DocenteCurso Entity
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
                SelectedCurso = CursoLogic.GetOne(int.Parse(ddlCurso.SelectedValue));
                this.gridDocenteCurso.DataSource = this.DocenteCursoLogic.GetAll(SelectedCurso);
                this.gridDocenteCurso.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCurso = CursoLogic.GetOne(int.Parse(ddlCurso.SelectedValue));
            this.gridDocenteCurso.SelectedIndex = -1;
            this.SelectedID = 0;
            this.ddlDocente.DataSource = PersonaLogic.GetAll(Persona.TipoPersonas.Profesor, SelectedCurso.Materia.Plan.ID);
            this.ddlDocente.DataBind();
            this.LoadGrid();
        }

        private void EnableForm(bool enable)
        {
            this.ddlCurso.Enabled = enable;
            this.ddlCargo.Enabled = enable;
            this.ddlDocente.Enabled = enable;
        }

        private void loadForm(int id)
        {
            this.Entity = this.DocenteCursoLogic.GetOne(id);
            this.ddlDocente.SelectedValue = this.Entity.Docente.ID.ToString();
            this.ddlCargo.SelectedValue = this.Entity.Cargo.ToString();
        }

        private void LoadEntity(DocenteCurso doc)
        {
            doc.Docente = new Persona();
            doc.Curso = new Curso();
            if (ddlCargo.SelectedValue == "Profesor")
            {
                doc.Cargo = DocenteCurso.TipoCargos.Profesor;
            }
            else
            {
                doc.Cargo = DocenteCurso.TipoCargos.Auxiliar;
            }
            doc.Docente.ID = int.Parse(ddlDocente.SelectedValue);
            doc.Curso.ID = int.Parse(ddlCurso.SelectedValue);
        }

        private void SaveEntity(DocenteCurso doc)
        {
            try
            {
                this.DocenteCursoLogic.Save(doc);
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
                this.DocenteCursoLogic.Delete(id);
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridDocenteCurso.SelectedValue;
            this.formPanel.Visible = false;
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
            this.EnableForm(true);
            this.ddlCurso.Enabled = false;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.ddlCurso.Enabled = true;
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    
                    if (!(DocenteCursoLogic.ExisteDocente(this.Entity.Docente.ID, this.Entity.Curso.ID)))
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        lblError.Text = "";
                    }
                    else
                    {
                        lblError.Text = "Este docente ya está participando del curso seleccionado";
                    }
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gridDocenteCurso.SelectedIndex = -1;
                    this.SelectedID = 0;
                    this.formPanel.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ddlCurso.Enabled = true;
            this.formPanel.Visible = false;
        }
    }
}