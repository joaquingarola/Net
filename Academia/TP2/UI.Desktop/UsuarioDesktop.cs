using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this._Modo = modo;
            this.Adaptar(modo);
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            UsuarioLogic usuarioLog = new UsuarioLogic();
            try
            {
                UsuarioActual = usuarioLog.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Adaptar(modo);
            this.MapearDeDatos();
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }


        #region Metodos

        private void Adaptar(ModoForm modo)
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.cmbPersona.DataSource = pl.GetAll();
                this.cmbPersona.DisplayMember = "Legajo";
                this.cmbPersona.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPersona.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Modo = modo;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    chkHabilitado.Hide();
                    lnkVerAlumnos.Hide();
                    lnkVerProfesores.Hide();
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    chkHabilitado.Hide();
                    lnkVerAlumnos.Hide();
                    lnkVerProfesores.Hide();
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    lnkVerAlumnos.Hide();
                    lnkVerProfesores.Hide();
                    if (UsuarioActual.Persona.TipoPersona != Persona.TipoPersonas.Administrador)
                    {
                        chkAdmin.Hide();
                    }
                    else
                    {
                        cmbPersona.Hide();
                        lblLegajo.Hide();
                    }
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            txtClave.Text = UsuarioActual.Clave;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            if (UsuarioActual.Persona.TipoPersona == Persona.TipoPersonas.Administrador)
            {
                chkAdmin.Checked = true;
            }
            else
            {
                foreach (Persona p in ((List<Persona>)cmbPersona.DataSource))
                {
                    if (p.ID == UsuarioActual.Persona.ID)
                    {
                        this.cmbPersona.SelectedItem = p;
                        break;
                    }
                }
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                    if (chkAdmin.Checked)
                    {
                        PersonaDesktop form = new PersonaDesktop(ModoForm.Alta, Persona.TipoPersonas.Administrador);
                        form.ShowDialog();
                        if (!form.salidaPorCancelar)
                        {
                            UsuarioActual.Persona = form.PersonaActual;
                        }
                        else throw new Exception("Registro cancelado");

                    }
                    else UsuarioActual.Persona = (Business.Entities.Persona)cmbPersona.SelectedItem;
                }
                else
                {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                if (UsuarioActual.Persona.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    UsuarioActual.Persona = (Business.Entities.Persona)cmbPersona.SelectedItem;
                }

            }
            else if (Modo == ModoForm.Baja)
                UsuarioActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                user.Save(UsuarioActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool Validar() 
        {
            Boolean EsValido = true;

            if (Validaciones.IsEmpty(txtClave.Text) || Validaciones.IsEmpty(txtUsuario.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EsValido = false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                EsValido = false;
                this.Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.txtClave.Text.Length < 8)
            {
                EsValido = false;
                this.Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbPersona.SelectedItem == null && !chkAdmin.Checked)
            {
                this.Notificar("Debe seleccionar un legajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return EsValido;
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerAlumnos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personas form = new Personas(Persona.TipoPersonas.Alumno);
            form.ShowDialog();
        }

        private void btnVerProfesores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personas form = new Personas(Persona.TipoPersonas.Profesor);
            form.ShowDialog();
        }

        private void checkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked)
            {
                this.cmbPersona.Hide();
                this.lblLegajo.Hide();
            }
        }
    }
}
