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
    public partial class DocentesCurso : ApplicationForm
    {
        public DocentesCurso(Curso cur)
        {
            InitializeComponent();
            this.dgvDocentesCurso.AutoGenerateColumns = false;
            cursoActual = cur;
            this.Text = cursoActual.Materia.Descripcion + " - " +cursoActual.Comision.Descripcion;
            this.Listar();
        }

        private Curso cursoActual { get; set; }

        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            try
            {
                this.dgvDocentesCurso.DataSource = dcl.GetAll(cursoActual);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ElegirDocente form = new ElegirDocente(cursoActual);
            form.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCurso.SelectedRows.Count != 0)
            {
                var rta = MessageBox.Show("¿Esta seguro que desea eliminar al docente de este curso?", "Atención", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCurso.SelectedRows[0].DataBoundItem).ID;
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.Delete(ID);
                    this.Listar();
                }
            }
        }

        private void dgvDocentes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvDocentesCurso.Rows)
            {
                row.Cells["docente"].Value = ((DocenteCurso)row.DataBoundItem).Docente.DescripcionFull;
            }
        }
    }
}
