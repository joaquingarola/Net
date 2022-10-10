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
    public partial class VerInscripcionesAlumno : ApplicationForm
    {
        public VerInscripcionesAlumno()
        {
            InitializeComponent();
            this.dgvVerInscripciones.AutoGenerateColumns = false;
        }

        public Persona AlumnoActual { get; set; }

        public VerInscripcionesAlumno(Persona alumno) : this()
        {
            AlumnoActual = alumno;
            this.Text = "Inscripción a materias de " + AlumnoActual.Plan.DescripcionFull;
            this.ListarInscripciones();
        }

        public void ListarInscripciones()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            try
            {
                this.dgvVerInscripciones.DataSource = ail.GetInscripcionesAlumno(AlumnoActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvVerInscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvVerInscripciones.SelectedRows.Count != 0)
                {
                    var rta = MessageBox.Show("¿Esta seguro que desea eliminar la inscripción?", "Atencion", MessageBoxButtons.YesNo);
                    if (rta == DialogResult.Yes)
                    {
                        int ID = ((Business.Entities.AlumnoInscripcion)this.dgvVerInscripciones.SelectedRows[0].DataBoundItem).ID;
                        AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                        ail.Delete(ID);
                        this.ListarInscripciones();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontaron comisiones con cupo disponible");
            }
        }

        private void dgvVerInscripciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvVerInscripciones.Rows)
            {
                row.Cells["materia"].Value = ((AlumnoInscripcion)row.DataBoundItem).Curso.Materia.Descripcion;
                row.Cells["comision"].Value = ((AlumnoInscripcion)row.DataBoundItem).Curso.Comision.Descripcion;
            }
        }
    }
}
