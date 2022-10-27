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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(UsuarioActual != null)
            {
                this.nombreUsuario.InnerText = "Sesión actual: " + this.getPersonaActual().Nombre + " " + this.getPersonaActual().Apellido; 
                this.sessionActual.InnerText = "Privilegios: " + this.getPersonaActual().TipoPersona;
            }
        }

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }

        public Persona getPersonaActual()
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p = pl.GetOne(UsuarioActual.Persona.ID);
            return p;
        }
    }
}