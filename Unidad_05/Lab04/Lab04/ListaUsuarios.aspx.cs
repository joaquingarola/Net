using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab04
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarDiasCalendario();
            }

            if (PaginaEnEstadoEdicion())
            {
                lblAccion.Text = "Editar Usuario";
            }
            else
            {
                lblAccion.Text = "Agregar Nuevo Usuario";
            }
        }

        private void cargarDiasCalendario()
        {
            //Cargar en el combo los items correspondientes a los días
            //(del 1 al 31)
            for(int i = 1; i <= 31; i++)
            {
                ddlDiaFechaNacimiento.Items.Add(i.ToString());
            }
        }

        private bool PaginaEnEstadoEdicion()
        {
            if (Request.QueryString["id"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CargarDatosUsuario(int idUsuario)
        {
            // 1 - Obtener los datos del usuario en cuestión
            // 2 - Cargar en los controles de la tabla los datos del usuario obtenido
        }


    }
}