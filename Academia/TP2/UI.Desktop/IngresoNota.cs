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
    public partial class IngresoNota : ApplicationForm
    {
        public IngresoNota()
        {
            InitializeComponent();
        }

        public AlumnoInscripcion inscripcion { get; set; }

        public IngresoNota(AlumnoInscripcion inscr) : this()
        {
            this.inscripcion = inscr;
            this.MapearDeDatos();
            this.Text = "Condición del alumno: " + inscripcion.Alumno.Apellido + ", " + inscripcion.Alumno.Nombre;
            cmbCondicion.Items.Add(AlumnoInscripcion.Condiciones.Aprobado);
            cmbCondicion.Items.Add(AlumnoInscripcion.Condiciones.Cursando);
            cmbCondicion.Items.Add(AlumnoInscripcion.Condiciones.Libre);
            cmbCondicion.Items.Add(AlumnoInscripcion.Condiciones.Regular);
            cmbCondicion.SelectedIndex = 0;
            for (int i = 6; i <= 10; i++)
                cmbNota.Items.Add(i);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void MapearDeDatos()
        {
            cmbCondicion.SelectedItem = inscripcion.Condicion;
        }

        public override void MapearADatos()
        {
            inscripcion.Condicion = (Business.Entities.AlumnoInscripcion.Condiciones)cmbCondicion.SelectedItem;
            if (inscripcion.Condicion == AlumnoInscripcion.Condiciones.Aprobado)
                inscripcion.Nota = (int)cmbNota.SelectedItem;
            inscripcion.State = BusinessEntity.States.Modified;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            try
            {
                ail.Save(inscripcion);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {
            if (cmbCondicion.SelectedItem == null)
            {
                Notificar("Debe seleccionar una condición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbNota.SelectedItem == null && (AlumnoInscripcion.Condiciones)cmbCondicion.SelectedItem == AlumnoInscripcion.Condiciones.Aprobado)
            {
                Notificar("Debe seleccionar una nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else return true;
        }

        private void cmbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Business.Entities.AlumnoInscripcion.Condiciones)cmbCondicion.SelectedItem == AlumnoInscripcion.Condiciones.Aprobado)
            {
                this.cmbNota.Enabled = true;
            }
            else this.cmbNota.Enabled = false;
        }
    }
}
