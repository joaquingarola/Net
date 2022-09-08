using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Valido Nombre de Usuario y Contraseña
            if (txtUsuario.Text.ToLower() == "admin" && this.txtClave.Text == "admin")
            {
                Page.Response.Write("Ingreso OK");
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrectos");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}