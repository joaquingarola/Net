using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Usuario User { get; set; }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Valido Nombre de Usuario y Contraseña
            UsuarioLogic ul = new UsuarioLogic();
            User = ul.GetOne(this.txtUsuario.Text, this.txtClave.Text);
            if (User.NombreUsuario == this.txtUsuario.Text && this.txtClave.Text == User.Clave)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrectos");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Usted es un usuario muy olvidadizo, haga memoria");
        }
    }
}