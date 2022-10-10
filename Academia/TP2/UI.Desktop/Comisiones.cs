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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            try
            {
                this.dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvComisiones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvComisiones.Rows)
            {
                row.Cells["plan"].Value = ((Comision)row.DataBoundItem).Plan.DescripcionFull;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComs = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComs.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComs = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComs.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la comisión?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionLogic comi = new ComisionLogic();
                comi.Delete(ID);
                this.Listar();
            }
        }
    }
}
