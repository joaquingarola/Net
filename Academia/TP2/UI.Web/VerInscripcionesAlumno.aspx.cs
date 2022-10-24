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
    public partial class VerInscripcionesAlumno : System.Web.UI.Page
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
                this.gridInscripciones.Visible = false;
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

        private AlumnoInscripcion Entity
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
                this.gridInscripciones.DataSource = this.AILogic.GetInscripcionesAlumno(this.getPersonaActual());
                this.gridInscripciones.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void loadForm(int id)
        {
            this.Entity = this.AILogic.GetOne(id);
            this.lblInscripcion.Text = this.Entity.Curso.Descripcion;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.AILogic.Delete(id);
                this.lblError.Text = "";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridInscripciones.SelectedValue;
            this.formPanel.Visible = false;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.loadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.gridInscripciones.SelectedIndex = -1;
                    this.SelectedID = 0;
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