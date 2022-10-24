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
    public partial class RegistroNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getPersonaActual().TipoPersona.ToString() == "Profesor")
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        this.ddlCurso.DataSource = CursoLogic.getCursosDocente(getPersonaActual());
                        this.ddlCurso.DataBind();
                        this.LoadGrid();
                        this.ddlCondicion.Items.Add("Aprobado");
                        this.ddlCondicion.Items.Add("Cursando");
                        this.ddlCondicion.Items.Add("Libre");
                        this.ddlCondicion.Items.Add("Regular");
                        this.ddlCondicion.Items.Add("Inscripto");
                        for (int i = 6; i <= 10; i++)
                            ddlNota.Items.Add(i.ToString());
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
                this.gridRegistroNotas.Visible = false;
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = false;
                this.lblError.Text = "Autorización denegada";
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

        private AlumnoInscripcion Entity
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
                this.gridRegistroNotas.DataSource = this.AILogic.getInscripcionesCurso(SelectedCurso);
                this.gridRegistroNotas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCurso = CursoLogic.GetOne(int.Parse(ddlCurso.SelectedValue));
            this.gridRegistroNotas.SelectedIndex = -1;
            this.SelectedID = 0;
            this.LoadGrid();
        }

        private void EnableForm(bool enable)
        {
            this.ddlCurso.Enabled = !enable;
            this.ddlCondicion.Enabled = enable;
            this.ddlNota.Enabled = enable;
            this.txtAlumno.Enabled = !enable;
        }

        private void loadForm(int id)
        {
            this.Entity = this.AILogic.GetOne(id);
            this.txtAlumno.Text = this.Entity.Alumno.DescripcionFull;
            this.ddlCondicion.SelectedValue = this.Entity.Condicion.ToString();
            if(this.Entity.Nota.ToString() == "0")
            {
                this.ddlNota.SelectedValue = "6";
            }
            else
            {
                this.ddlNota.SelectedValue = this.Entity.Nota.ToString();
            }
            this.updateDdlNota();
        }

        private void LoadEntity(AlumnoInscripcion ai)
        {
            switch (ddlCondicion.SelectedValue)
            {
                case "Aprobado":
                    ai.Condicion = AlumnoInscripcion.Condiciones.Aprobado;
                    ai.Nota = int.Parse(ddlNota.SelectedValue);
                    break;
                case "Libre":
                    ai.Condicion = AlumnoInscripcion.Condiciones.Libre;
                    ai.Nota = 0;
                    break;
                case "Cursando":
                    ai.Condicion = AlumnoInscripcion.Condiciones.Cursando;
                    ai.Nota = 0;
                    break;
                case "Regular":
                    ai.Condicion = AlumnoInscripcion.Condiciones.Regular;
                    ai.Nota = 0;
                    break;
                default:
                    break;
            }
            
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
            this.SelectedID = (int)this.gridRegistroNotas.SelectedValue;
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

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.ddlCurso.Enabled = true;
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity = this.AILogic.GetOne(this.SelectedID);
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
            this.ddlCurso.Enabled = true;
            this.formPanel.Visible = false;
        }

        protected void ddlCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updateDdlNota();
        }

        private void updateDdlNota()
        {
            switch (this.ddlCondicion.SelectedValue)
            {
                case "Aprobado":
                    this.ddlNota.Enabled = true;
                    break;
                case "Libre":
                    this.ddlNota.Enabled = false;
                    break;
                case "Cursando":
                    this.ddlNota.Enabled = false;
                    break;
                case "Regular":
                    this.ddlNota.Enabled = false;
                    break;
                default:
                    this.ddlNota.Enabled = false;
                    break;
            }
        }

        protected void gridRegistroNotas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell notaCell = e.Row.Cells[2];
                if (notaCell.Text == "0")
                {
                    notaCell.Text = "-";
                }
            }
        }
    }
}