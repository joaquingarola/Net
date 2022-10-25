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
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        private Materia _MateriaActual;

        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        private Plan _PlanActual;

        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public MateriaDesktop(ModoForm modo, Plan p) : this()
        {
            PlanActual = p;
            cargarPlan();
            this._Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            cargarPlanes();
            this._Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            try
            {
                MateriaActual = ml.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.MapearDeDatos();
        }

        public void cargarPlan()
        {
            try
            {
                this.cmbPlan.Items.Insert(0, PlanActual);
                this.cmbPlan.SelectedIndex = 0;
                this.cmbPlan.DisplayMember = "DescripcionFull";
                // this.cmbPlan.AutoCompleteMode = AutoCompleteMode.Suggest;
                // this.cmbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void cargarPlanes()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                this.cmbPlan.DataSource = pl.GetAll();
                this.cmbPlan.DisplayMember = "DescripcionFull";
                this.cmbPlan.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtID.Text = MateriaActual.ID.ToString();
            this.txtHSSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = MateriaActual.HSTotales.ToString();
            foreach (Plan p in ((List<Plan>)cmbPlan.DataSource))
            {
                if (p.ID == MateriaActual.Plan.ID)
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
                    MateriaActual = new Business.Entities.Materia();
                    MateriaActual.State = BusinessEntity.States.New;
                }
                else
                {
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HSSemanales = Convert.ToInt32(txtHSSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(txtHSTotales.Text);
                MateriaActual.Plan = (Business.Entities.Plan)cmbPlan.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                MateriaActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic mat = new MateriaLogic();
            try
            {
                mat.Save(MateriaActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool Validar()
        {
            string msg = "";
            if (Validaciones.IsEmpty(txtDescripcion.Text))
            {
                msg += "\n- Complete con una descripción";
            }
            if (Validaciones.IsEmpty(txtHSSemanales.Text))
            {
                msg += "\n- Complete las horas semanales";
            }
            if (Validaciones.IsEmpty(txtHSTotales.Text))
            {
                msg += "\n- Complete las horas totales";
            }
            if (msg != "")
            {
                Notificar("Por favor: " + msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbPlan.SelectedItem == null)
            {
                Notificar("Debe seleccionar un plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtHSSemanales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHSTotales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
