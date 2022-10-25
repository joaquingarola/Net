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
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            cargarEsp();
            this._Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            cargarEsp();
            this._Modo = modo;
            PlanLogic pl = new PlanLogic();
            try
            {
                PlanActual = pl.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.MapearDeDatos();
        }

        public void cargarEsp()
        {         
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                this.cmbEspecialidad.DataSource = el.GetAll();
                this.cmbEspecialidad.DisplayMember = "Descripcion";
                // this.cmbEspecialidad.AutoCompleteMode = AutoCompleteMode.Suggest;
                // this.cmbEspecialidad.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Plan _PlanActual;

        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = PlanActual.Descripcion;
            this.txtID.Text = PlanActual.ID.ToString();
            foreach (Especialidad esp in ((List<Especialidad>)cmbEspecialidad.DataSource))
            {
                if (esp.ID == PlanActual.Especialidad.ID)
                {
                    this.cmbEspecialidad.SelectedItem = esp;
                    break;
                }
            }

            switch (this._Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    PlanActual = new Business.Entities.Plan();
                    PlanActual.State = BusinessEntity.States.New;
                }
                else
                {
                    PlanActual.State = BusinessEntity.States.Modified;
                }
                PlanActual.Descripcion = txtDescripcion.Text;
                PlanActual.Especialidad = (Business.Entities.Especialidad)cmbEspecialidad.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                PlanActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic plan = new PlanLogic();
            try
            {
                plan.Save(_PlanActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool Validar()
        {
            if (Validaciones.IsEmpty(txtDescripcion.Text))
            {
                Notificar("Ingrese una descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbEspecialidad.SelectedItem == null)
            {
                Notificar("Debe seleccionar una especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
