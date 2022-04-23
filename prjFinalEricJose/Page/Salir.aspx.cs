using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFinalEricJose.Page
{
    public partial class Salir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario_ingresado"] != null)
            {
                Session["usuario_ingresado"] = null;
                Response.Redirect("ingresar");
            }
            else
            {
                Response.Redirect("ingresar");
            }
        }
    }
}