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

        private Usuario _User;
        public Usuario User
        {
            get { return _User; }
            set { _User = value; }
        }

        private Persona _Persona;
        public Persona Pers
        {
            get { return _Persona; }
            set { _Persona = value; }
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

            else
            {
                User = appLogin.User;
                PersonaLogic pl = new PersonaLogic();
                Pers = pl.GetOne(User.Persona.ID);
                switch (Pers.TipoPersona)
                {
                    case Persona.TipoPersonas.Administrador:
                        this.mnuInscripcionCursado.Visible = false;
                        this.mnuVerInscripciones.Visible = false;
                        this.mnuRegistroNotas.Visible = false;
                        break;

                    case Persona.TipoPersonas.Alumno:
                        this.mnuABMC.Visible = false;
                        this.mnuRegistroNotas.Visible = false;
                        break;

                    case Persona.TipoPersonas.Profesor:
                        this.mnuABMC.Visible = false;
                        this.mnuInscripcionCursado.Visible = false;
                        this.mnuVerInscripciones.Visible = false;
                        break;
                }
            }
        }

        private void mnuItemUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios appUser = new Usuarios();
            appUser.Show();
        }

        private void mnuItemAlumnos_Click(object sender, EventArgs e)
        {
            Personas appAlumnos = new Personas(Persona.TipoPersonas.Alumno);
            appAlumnos.Show();
        }

        private void mnuItemProfesores_Click(object sender, EventArgs e)
        {
            Personas appProfesores = new Personas(Persona.TipoPersonas.Profesor);
            appProfesores.Show();
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

        private void mnuItemCursos_Click(object sender, EventArgs e)
        {
            Cursos appCursos = new Cursos();
            appCursos.Show();
        }

        private void mnuInscripcionCursado_Click(object sender, EventArgs e)
        {
            InscripcionAlumno appInscripcioAlumnos = new InscripcionAlumno(Pers);
            appInscripcioAlumnos.Show();
        }

        private void mnuVerInscripciones_Click(object sender, EventArgs e)
        {
            VerInscripcionesAlumno InscripcioesAlumno = new VerInscripcionesAlumno(Pers);
            InscripcioesAlumno.Show();

        }

        private void mnuRegistroDeNotas_Click(object sender, EventArgs e)
        {
            RegistroNotas appRegistroNotas = new RegistroNotas(Pers);
            appRegistroNotas.Show();
        }
    }
}
