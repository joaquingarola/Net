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
    public partial class FormMain : ApplicationForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Login appLogin = new Login();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void mnuItemUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios appUser = new Usuarios();
            appUser.Show();
        }

        private void mnuItemEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades appEsp = new Especialidades();
            appEsp.Show();
        }

        private void mnuItemPlanes_Click(object sender, EventArgs e)
        {
            Planes appPlan = new Planes();
            appPlan.Show();
        }

        private void mnuItemComisiones_Click(object sender, EventArgs e)
        {
            Comisiones appCom = new Comisiones();
            appCom.Show();
        }
    }
}
