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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            CursoLogic ul = new CursoLogic();
            try
            {
                this.dgvCursos.DataSource = ul.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
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

        private void dgvCursos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvCursos.Rows)
            {
                row.Cells["materia"].Value = ((Curso)row.DataBoundItem).Materia.Descripcion;
                row.Cells["comision"].Value = ((Curso)row.DataBoundItem).Comision.Descripcion;
            }
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCursos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DocentesCurso form = new DocentesCurso((Curso)dgvCursos.Rows[e.RowIndex].DataBoundItem);
                form.ShowDialog();
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0) {
                var rta = MessageBox.Show("¿Esta seguro que desea eliminar el curso?", "Atencion", MessageBoxButtons.YesNo);
                if(rta == DialogResult.Yes) { 
                    int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoLogic cur = new CursoLogic();
                    cur.Delete(ID);
                    this.Listar();
                }
            }
        }
    }
}
