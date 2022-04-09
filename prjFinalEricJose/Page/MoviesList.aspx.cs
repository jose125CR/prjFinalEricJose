using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;

namespace prjFinalEricJose.Page
{
    public partial class MoviesList : System.Web.UI.Page
    {
        int idSeleccionado;
        List<clsPelicula> listaGlobalPeliculas = new List<clsPelicula>();
        public void Mensaje(string pMensaje)
        {
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('" + pMensaje + "')";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
        }

        public void mostrarListaPeliculas()
        {
            blPelicula blm = new blPelicula();
            clsPelicula vPelicula = new clsPelicula();
            string vError = null;

            listaGlobalPeliculas = blm.CosultarPeliculas(ref vError);

            if (vError == null)
            {
                ltvPeliculas.DataSource = listaGlobalPeliculas;
                ltvPeliculas.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mostrarListaPeliculas();
            }
        }

        protected void ltvPeliculas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            idSeleccionado = Convert.ToInt32(e.CommandArgument);
        }

        protected void ltvPeliculas_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            Mensaje(idSeleccionado.ToString());
        }

        protected void ltvPeliculas_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            Mensaje(idSeleccionado.ToString());
        }

        protected void ltvPeliculas_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            Mensaje(idSeleccionado.ToString());
        }
    }
}