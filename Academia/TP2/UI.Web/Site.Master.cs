using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] r = { this.getPersonaActual().TipoPersona.ToString() };
            HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, r);
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