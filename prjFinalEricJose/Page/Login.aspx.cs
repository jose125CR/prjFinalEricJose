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
    public partial class Login : System.Web.UI.Page
    {

        public void Mensaje(string pMensaje)
        {
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String csConsole = "console.log('" + pMensaje + "')";
                String cstext = "alert('" + pMensaje + "')";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                cs.RegisterStartupScript(cstype, "PopupScript", csConsole, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ingresar_persona_Click(object sender, EventArgs e)
        {

            blUsuario lg_persona = new blUsuario();
            string vError = null;
            string usuario = txt_usuario.Text.ToLower();
            string contrasena = txt_contrasena.Text;

            clsUsuario dt_persona = lg_persona.CosultarLogin(usuario, contrasena, ref vError);

            if (vError == null && dt_persona != null)
            {
                Session["loggueao"] = true;
                Response.Redirect("UsersList.aspx");
            }
            else
            {
                Session["loggueado"] = false;
                Mensaje("Nombre de usuario y/o contraseñas no coinciden, por favor verifique");
            }
        }
    }
}