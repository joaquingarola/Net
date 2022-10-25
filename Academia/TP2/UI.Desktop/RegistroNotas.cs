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
    public partial class RegistroNotas : ApplicationForm
    {
        public RegistroNotas()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
        }


        public RegistroNotas(Persona docente) : this()
        {
            this.Text = "Registro de notas - " + docente.DescripcionFull;
            CursoLogic cl = new CursoLogic();
            try
            {
                this.cmbCurso.DataSource = cl.getCursosDocente(docente);
                this.cmbCurso.DisplayMember = "Descripcion";
                // this.cmbCurso.AutoCompleteMode = AutoCompleteMode.Suggest;
                // this.cmbCurso.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        public void ListarAlumnos()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            try
            {
                this.dgvAlumnos.DataSource = ail.getInscripcionesCurso((Curso)cmbCurso.SelectedItem);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListarAlumnos();
        }

        private void dgvAlumnos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvAlumnos.Rows)
            {
                row.Cells["nombre"].Value = ((AlumnoInscripcion)row.DataBoundItem).Alumno.Apellido + ", " + ((AlumnoInscripcion)row.DataBoundItem).Alumno.Nombre;
                row.Cells["legajo"].Value = ((AlumnoInscripcion)row.DataBoundItem).Alumno.Legajo;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count != 0)
            {
                AlumnoInscripcion alumno = (Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem;
                IngresoNota ingreso = new IngresoNota(alumno);
                ingreso.FormClosed += new FormClosedEventHandler(Form_Closed);
                ingreso.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un alumno");
            } 
                
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.ListarAlumnos();
        }
    }
}
