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
using System.Text.RegularExpressions; /* para validar email */

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
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            UsuarioLogic UsuarioNegocio = new UsuarioLogic();
            _UsuarioActual = UsuarioNegocio.GetOne(ID);
            this.MapearDeDatos();
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }


        #region Metodos

        public override void MapearDeDatos() 
        {
            this.txtID.Text = _UsuarioActual.ID.ToString();
            this.txtNombre.Text = _UsuarioActual.Nombre;
            this.txtApellido.Text = _UsuarioActual.Apellido;
            this.txtEmail.Text = _UsuarioActual.Email;
            this.txtUsuario.Text = _UsuarioActual.NombreUsuario;
            this.txtClave.Text = _UsuarioActual.Clave;
            this.txtConfirmarClave.Text = _UsuarioActual.Clave;
            this.chkHabilitado.Checked = _UsuarioActual.Habilitado;

            switch (this._Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Baja:
                    _UsuarioActual.State = Usuario.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _UsuarioActual.State = Usuario.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _UsuarioActual = new Usuario();
                    _UsuarioActual.State = Usuario.States.New;
                    break;
                case ModoForm.Modificacion:
                    _UsuarioActual.State = Usuario.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _UsuarioActual.ID = Convert.ToInt32(this.txtID.Text);
                _UsuarioActual.Nombre = this.txtNombre.Text;
                _UsuarioActual.Apellido = this.txtApellido.Text;
                _UsuarioActual.Email = this.txtEmail.Text;
                _UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                _UsuarioActual.Clave = this.txtClave.Text;
                _UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            }
        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioLogic userlogic = new UsuarioLogic();
            userlogic.Save(_UsuarioActual);
        }

        public override bool Validar() 
        {
            Boolean EsValido = true;
      
            //Falta validad que los campos no estén vacíos

            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                EsValido = false;
                this.Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.txtClave.Text.Length < 8)
            {
                EsValido = false;
                this.Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (EsMailValido(this.txtEmail.Text) == false)
            {
                EsValido = false;
                this.Notificar("Email no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return EsValido;
        }

        private Boolean EsMailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
