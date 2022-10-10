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
    public partial class InscripcionAlumno : ApplicationForm
    {
        public InscripcionAlumno()
        {
            InitializeComponent();
            this.dgvInscripcion.AutoGenerateColumns = false;
        }

        public Persona AlumnoActual { get; set; }

        public InscripcionAlumno(Persona alumno) : this()
        {
            AlumnoActual = alumno;
            this.Text = "Inscripción a materias de " + AlumnoActual.Plan.DescripcionFull;
            this.ListarPosibles();
        }

        public void ListarPosibles()
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.dgvInscripcion.DataSource = ml.GetPosibles(AlumnoActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.ListarPosibles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInscripcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvInscripcion.SelectedRows.Count != 0)
                {
                    ElegirComision elegir = new ElegirComision((Materia)dgvInscripcion.Rows[e.RowIndex].DataBoundItem, AlumnoActual);
                    elegir.Show();
                    elegir.FormClosed += new FormClosedEventHandler(Form_Closed);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontaron comisiones con cupo disponible");
            }
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.ListarPosibles();
        }
    }
}
