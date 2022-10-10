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
    public partial class Materias : ApplicationForm
    {
        public Materias(Plan p)
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            PlanActual = p;
            this.Text = "Materias del plan: " + p.DescripcionFull;
        }

        private Plan _PlanActual { get; set; }

        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.dgvMaterias.DataSource = ml.GetMateriasPlan(PlanActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMat = new MateriaDesktop(ApplicationForm.ModoForm.Alta, PlanActual);
            formMat.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMat = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMat.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la materia?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaLogic mat = new MateriaLogic();
                mat.Delete(ID);
                this.Listar();
            }
        }

        private void dgvMaterias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvMaterias.Rows)
            {
                row.Cells["plan"].Value = ((Materia)row.DataBoundItem).Plan.DescripcionFull;
            }
        }
    }
}
