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

        public Usuario Usr { get; set; }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Valido Nombre de Usuario y Contraseña
            lblIncorrecto.Visible = false;
            UsuarioLogic ul = new UsuarioLogic();
            Usr = ul.GetOne(this.txtUsuario.Text, this.txtClave.Text);
            if (Usr.ID != 0)
            {
                Session["UsuarioActual"] = Usr;
                Response.Redirect("~/Default.aspx");
                
            }
            else
            {
                lblIncorrecto.Text = "Usuario y/o contraseña incorrecto";
                lblIncorrecto.Visible = true;
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            lblIncorrecto.Text = "Usted es un usuario muy olvidadizo, haga memoria";
        }
    }
}