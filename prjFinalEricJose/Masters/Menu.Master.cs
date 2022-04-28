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
            MostrasOpciones();
        }

        private void cargarTipoCambio()
        {
            lb_tipo_cambio.Text = $"₡{blHelpers.TipoCambio().ToString("0.00")}";
        }


        private void MostrasOpciones()
        {
            blPermiso lg_permiso = new blPermiso();

            clsUsuario loggeado = (clsUsuario)Session["usuario_ingresado"];
            string vError = null;


            Boolean permiso_drop = lg_permiso.CosultarPermisoDropAdministracion(loggeado.id_rol_Prop, ref vError);

            if (permiso_drop && vError == null)
            {
                link_drop.Visible = true;
                clsPermiso permisos_precios = lg_permiso.CosultarPemisosPorRolModulo(loggeado.id_rol_Prop, blHelpers.PRECIOS, ref vError);

                if (vError == null)
                {
                    if (TieneAlgunPermiso(permisos_precios))
                    {
                        link_precios.Visible = true;
                    }
                }

                clsPermiso permisos_permisos = lg_permiso.CosultarPemisosPorRolModulo(loggeado.id_rol_Prop, blHelpers.PERMISOS, ref vError);

                if (vError == null)
                {
                    if (TieneAlgunPermiso(permisos_permisos))
                    {
                        link_permisos.Visible = true;
                    }
                }

                clsPermiso permisos_facturado = lg_permiso.CosultarPemisosPorRolModulo(loggeado.id_rol_Prop, blHelpers.FACTURADO, ref vError);

                if (vError == null)
                {
                    if (TieneAlgunPermiso(permisos_facturado))
                    {
                        link_facturado.Visible = true;
                    }
                }
            }

            if(vError == null)
            {
                clsPermiso permisos_usuarios = lg_permiso.CosultarPemisosPorRolModulo(loggeado.id_rol_Prop, blHelpers.USUARIOS, ref vError);

                if (vError == null)
                {
                    if (TieneAlgunPermiso(permisos_usuarios))
                    {
                        link_personas.Visible = true;
                    }
                }

                clsPermiso permisos_peliculas = lg_permiso.CosultarPemisosPorRolModulo(loggeado.id_rol_Prop, blHelpers.PELICULAS, ref vError);

                if (vError == null)
                {
                    if (TieneAlgunPermiso(permisos_peliculas))
                    {
                        link_peliculas.Visible = true;
                    }
                }
            }
        }

        private Boolean TieneAlgunPermiso(clsPermiso permisos)
        {
            if (permisos.consultar_Prop || permisos.editar_Prop || permisos.eliminar_Prop || permisos.registrar_Prop)
            {
                return true;
            }
            return false;
        }
    }
}