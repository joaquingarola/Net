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
    public partial class InscripcionAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Alumno")
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        this.LoadGrid();
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
                this.gridInscripcionAlumno.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = false;
                this.lblError.Text = "Autorización denegada";
            }
        }

        private AlumnoInscripcionLogic _AILogic;

        public AlumnoInscripcionLogic AILogic
        {
            get
            {
                if (_AILogic == null)
                {
                    _AILogic = new AlumnoInscripcionLogic();
                }
                return _AILogic;
            }
        }

        private MateriaLogic _MateriaLogic;

        public MateriaLogic MateriaLogic
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

        private Materia Entity
        {
            get;
            set;
        }

        private AlumnoInscripcion Inscripcion
        {
            get;
            set;
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
                this.gridInscripcionAlumno.DataSource = this.MateriaLogic.GetPosibles(this.getPersonaActual());
                this.gridInscripcionAlumno.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void EnableForm(bool enable)
        {
            this.ddlComision.Enabled = enable;
        }

        private bool loadForm(int id)
        {
            CursoLogic cl = new CursoLogic();
            this.Entity = this.MateriaLogic.GetOne(id);
            List<Curso> posibles = cl.GetPosibles(this.Entity);
            if (posibles.Count != 0)
            {
                this.lblMateria.Text = this.Entity.Descripcion;
                this.ddlComision.DataSource = posibles;
                this.ddlComision.DataBind();
                lblError.Text = "";
                return true;
            }
            else
            {
                lblError.Text = "No hay comisiones con cupos disponibles";
                return false;
            }
        }

        private void LoadEntity(AlumnoInscripcion ai)
        {
            ai.Curso = new Curso();
            ai.Curso.ID = int.Parse(ddlComision.SelectedValue);
            ai.Alumno = new Persona();
            ai.Alumno.ID = this.getPersonaActual().ID;
        }

        private void SaveEntity(AlumnoInscripcion ai)
        {
            try
            {
                this.AILogic.Save(ai);
                lblError.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridInscripcionAlumno.SelectedValue;
            this.formPanel.Visible = false;
        }

        protected void inscripcionLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                if (this.loadForm(this.SelectedID))
                {
                    this.formPanel.Visible = true;
                    this.EnableForm(true);
                    this.FormMode = FormModes.Alta;
                }
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Inscripcion = new AlumnoInscripcion();
                    this.LoadEntity(this.Inscripcion);
                    this.SaveEntity(this.Inscripcion);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }
    }
}