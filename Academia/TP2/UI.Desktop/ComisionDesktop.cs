using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this._Modo = modo;
            cargarPlan();
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            cargarPlan();
            ComisionLogic cl = new ComisionLogic();
            try
            {
                ComisionActual = cl.GetOne(ID);
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.MapearDeDatos();
        }

        public void cargarPlan()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                this.cmbPlan.DataSource = pl.GetAll();
                this.cmbPlan.DisplayMember = "Descripcion";
                this.cmbPlan.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Comision _ComisionActual;

        public Business.Entities.Comision ComisionActual 
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtAnioEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.txtID.Text = ComisionActual.ID.ToString();
            foreach (Plan p in ((List<Plan>)cmbPlan.DataSource))
            {
                if (p.ID == ComisionActual.Plan.ID)
                {
                    this.cmbPlan.SelectedItem = p;
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
                    ComisionActual = new Business.Entities.Comision();
                    ComisionActual.State = BusinessEntity.States.New;
                }
                else
                {
                    ComisionActual.State = BusinessEntity.States.Modified;
                }
                ComisionActual.Descripcion = txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);
                ComisionActual.Plan = (Business.Entities.Plan)cmbPlan.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                ComisionActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic comi = new ComisionLogic();
            try
            {
                comi.Save(ComisionActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override bool Validar()
        {
            if (Util.Validar.isEmpty(txtDescripcion.Text) || Util.Validar.isEmpty(txtAnioEspecialidad.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!int.TryParse(txtAnioEspecialidad.Text, out int result))
            {
                Notificar("El año debe estar expresado como número", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbPlan.SelectedItem == null)
            {
                Notificar("Debe seleccionar una especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
