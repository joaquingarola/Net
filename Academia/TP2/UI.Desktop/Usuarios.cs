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
    public partial class Usuarios : ApplicationForm
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                this.dgvUsuarios.DataSource = ul.GetAll();
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0) { 
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop UserDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                UserDesktop.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count != 0) {
                var rta = MessageBox.Show("¿Esta seguro que desea eliminar al usuario?", "Atencion", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                    UsuarioLogic user = new UsuarioLogic();
                    user.Delete(ID);
                    this.Listar();
                }
            }
        }

        private void dgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvUsuarios.Rows)
            {
                row.Cells["nombre"].Value = ((Usuario)row.DataBoundItem).Persona.Nombre + " " + ((Usuario)row.DataBoundItem).Persona.Apellido;
                row.Cells["legajo"].Value = ((Usuario)row.DataBoundItem).Persona.Legajo;
                row.Cells["Tipo"].Value = ((Usuario)row.DataBoundItem).Persona.TipoPersona.ToString();
            }
        }
    }
}
