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
    public partial class ElegirComision : Form
    {
        public ElegirComision()
        {
            InitializeComponent();
            this.dgvElegirComision.AutoGenerateColumns = false;
        }

        public Persona AlumnoActual { get; set; }

        public ElegirComision(Materia mat, Persona alu) : this()
        {
            this.AlumnoActual = alu;
            this.Text = "Comisiones - " + mat.Descripcion;
            CursoLogic cl = new CursoLogic();
            try
            {
                this.dgvElegirComision.DataSource = cl.GetPosibles(mat);
                if (this.dgvElegirComision.Rows.Count == 0)
                {
                    this.Close();
                }
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (this.dgvElegirComision.SelectedRows.Count != 0)
            {
                AlumnoInscripcion nuevaInscripcion = new AlumnoInscripcion();    
                nuevaInscripcion.Curso = new Curso();
                nuevaInscripcion.Curso.ID = ((Business.Entities.Curso)this.dgvElegirComision.SelectedRows[0].DataBoundItem).ID;
                nuevaInscripcion.Alumno = new Persona();
                nuevaInscripcion.Alumno.ID = this.AlumnoActual.ID;
                nuevaInscripcion.State = BusinessEntity.States.New;
                AlumnoInscripcionLogic inscr = new AlumnoInscripcionLogic();
                try
                {
                    inscr.Save(nuevaInscripcion);
                }
                catch (Exception ExcepcionManejada)
                {
                    MessageBox.Show(ExcepcionManejada.Message);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvElegirComision_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvElegirComision.Rows)
            {
                row.Cells["anioEspecialidad"].Value = ((Curso)row.DataBoundItem).Comision.AnioEspecialidad;
                row.Cells["comision"].Value = ((Curso)row.DataBoundItem).Comision.Descripcion;
            }
        }
    }
}
