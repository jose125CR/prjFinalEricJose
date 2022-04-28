using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;

/*Libreria para definir las rutas*/

namespace prjFinalEricJose.Masters
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario_ingresado"] != null)
            {
                clsUsuario usuario = (clsUsuario)Session["usuario_ingresado"];

                lb_user_logged.Text = $"{usuario.nombre1_Prop} {usuario.nombre2_Prop} {usuario.apellido1_Prop} {usuario.apellido2_Prop}";

            }

            cargarTipoCambio();
        }

        private void cargarTipoCambio()
        {
            lb_tipo_cambio.Text = $"₡{blHelpers.TipoCambio().ToString("0.00")}";
        }
    }
}