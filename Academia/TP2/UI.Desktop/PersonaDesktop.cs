using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public Persona PersonaActual { get; set; }

        protected Persona.TipoPersonas tipoPers;

        public PersonaDesktop(ModoForm modo, Persona.TipoPersonas tipo) : this()
        {
            tipoPers = tipo;
            this.Adaptar(modo, tipo);
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                PersonaActual = pl.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Adaptar(modo, PersonaActual.TipoPersona);
            MapearDeDatos();
        }

        private void Adaptar(ModoForm modo, Persona.TipoPersonas tipo)
        {
            this.Modo = modo;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
            }
            PlanLogic pl = new PlanLogic();
            try
            {
                this.cmbPlan.DataSource = pl.GetAll();
                this.cmbPlan.DisplayMember = "DescripcionFull";
                this.cmbPlan.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            switch (tipo)
            {
                case (Persona.TipoPersonas.Profesor):
                    this.Text = "ABM Profesor";
                    break;

                case (Persona.TipoPersonas.Alumno):
                    this.Text = "ABM Alumno";
                    break;

                case (Persona.TipoPersonas.Administrador):
                    this.Text = "Ingresar datos de administrador";
                    this.txtLegajo.Hide();
                    this.lblLegajo.Hide();
                    this.cmbPlan.Hide();
                    this.lblPlan.Hide();
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtApellido.Text = PersonaActual.Apellido;
            this.txtNombre.Text = PersonaActual.Nombre;
            this.txtFechaNac.Text = PersonaActual.FechaNacimiento.ToShortDateString();
            this.txtDireccion.Text = PersonaActual.Direccion;
            this.txtTelefono.Text = PersonaActual.Telefono;
            this.txtEmail.Text = PersonaActual.Email;
            this.txtID.Text = PersonaActual.ID.ToString();
            if (tipoPers != Persona.TipoPersonas.Administrador)
            {
                foreach (Plan p in ((List<Plan>)cmbPlan.DataSource))
                {
                    if (p.ID == PersonaActual.Plan.ID)
                    {
                        this.cmbPlan.SelectedItem = p;
                        break;
                    }
                }
                this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    PersonaActual = new Persona();
                    PersonaActual.State = BusinessEntity.States.New;
                    PersonaActual.TipoPersona = tipoPers;
                }
                else
                {
                    PersonaActual.State = BusinessEntity.States.Modified;
                }
                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Telefono = txtTelefono.Text;
                PersonaActual.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                if (tipoPers != Persona.TipoPersonas.Administrador)
                {
                    PersonaActual.Plan = (Business.Entities.Plan)cmbPlan.SelectedItem;
                    PersonaActual.Legajo = int.Parse(txtLegajo.Text);
                }
            }
            else if (Modo == ModoForm.Baja)
                PersonaActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pers = new PersonaLogic();
            try
            {
                pers.Save(PersonaActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool Validar()
        {
            if (Validaciones.IsEmpty(txtNombre.Text) || Validaciones.IsEmpty(txtApellido.Text) || Validaciones.IsEmpty(txtFechaNac.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!int.TryParse(txtLegajo.Text, out int result) && tipoPers != Persona.TipoPersonas.Administrador)
            {
                Notificar("Legajo debe ser un número", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!DateTime.TryParse(txtFechaNac.Text, out DateTime result2))
            {
                Notificar("Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!Validaciones.EsMailValido(txtEmail.Text) && !Validaciones.IsEmpty(txtEmail.Text))
            {
                Notificar("Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbPlan.SelectedItem == null && tipoPers != Persona.TipoPersonas.Administrador)
            {
                Notificar("Debe seleccionar una especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Modo == ModoForm.Alta && tipoPers != Persona.TipoPersonas.Administrador && PersonaLogic.ExisteLegajo(Convert.ToInt32(txtLegajo.Text)))
            {
                Notificar("El legajo ingresado ya fue asignado a otra persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool salidaPorCancelar { get; set; }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
