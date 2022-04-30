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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario_ingresado"] != null)
            {
                if (IsPostBack == false)
                {
                    CargarPerfilUsuario();
                }
            }
            else
            {
                Response.Redirect($"/ingresar");
            }
        }

        public void CargarPerfilUsuario()
        {
            blPerfil lg_perfil = new blPerfil();
            string vError = null;

            clsUsuario loggeado = (clsUsuario)Session["usuario_ingresado"];

            clsPerfil perfil_usuario = lg_perfil.CosultarUsuarioPerfil(loggeado.dni_persona_Prop, ref vError);

            if (vError == null)
            {
                lb_nombre_completo.Text = perfil_usuario.nombre_completo_Prop;
                lb_rol.Text = perfil_usuario.rol_Prop;
                lb_correo.Text = perfil_usuario.correo_Prop;
                lb_fecha_nac.Text = perfil_usuario.fecha_nac_Prop;
                lb_telefono.Text = perfil_usuario.telefono_Prop;
                lb_fecha_registro.Text = perfil_usuario.fecha_registro_Prop;
                lb_puntos.Text = perfil_usuario.puntos_Prop;
                lb_canjeos.Text = perfil_usuario.canjes_Prop;
                lb_puntos_necesarios.Text = perfil_usuario.puntos_necesarios_Prop;
                lb_canjes_necesarios.Text = perfil_usuario.canjes_necesarios_Prop;
            }
        }
    }
}