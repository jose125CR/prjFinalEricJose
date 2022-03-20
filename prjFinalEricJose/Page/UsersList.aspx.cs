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
    public partial class UsersList : System.Web.UI.Page
    {
        public void Mensaje(string pMensaje)
        {
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "console.log('" + pMensaje + "')";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
        }

        public void mostrarListaUsuarios()
        {
            blUsuario blm = new blUsuario();
            clsUsuario vUsario = new clsUsuario();
            string vError = null;

            List<clsUsuario> lista = new List<clsUsuario>();

            lista = blm.CosultarUsuarios(ref vError);

            if (vError == null)
            {
                grdUsuarios.DataSource = null;
                grdUsuarios.DataBind();
                grdUsuarios.DataSource = lista;
                grdUsuarios.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mostrarListaUsuarios();
            }
        }
    }
}