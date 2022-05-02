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
                if (IsPostBack == false)
                {
                    clsUsuario usuario = (clsUsuario)Session["usuario_ingresado"];

                    lb_user_logged.Text = $"{usuario.nombre1_Prop} {usuario.nombre2_Prop} {usuario.apellido1_Prop} {usuario.apellido2_Prop}";

                    cargarTipoCambio();
                    MostrasOpciones();
                }
            }
            else
            {
                Response.Redirect($"/ingresar");
            }
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

                if (vError == null)
                {
                    link_precios.Visible = TieneAlgunPermiso(loggeado.id_rol_Prop, blHelpers.PRECIOS);
                    link_permisos.Visible = TieneAlgunPermiso(loggeado.id_rol_Prop, blHelpers.PERMISOS);
                    link_facturado.Visible = TieneAlgunPermiso(loggeado.id_rol_Prop, blHelpers.FACTURADO);
                }
            }
            if(vError == null)
            {
                link_personas.Visible = TieneAlgunPermiso(loggeado.id_rol_Prop, blHelpers.USUARIOS);
                link_peliculas.Visible = TieneAlgunPermiso(loggeado.id_rol_Prop, blHelpers.PELICULAS);
            }
        }

        private Boolean TieneAlgunPermiso(int id_rol, int id_pagina)
        {
            blPermiso lg_permiso = new blPermiso();
            string vError = null;
            clsPermiso permisos = lg_permiso.CosultarPemisosPorRolModulo(id_rol, id_pagina, ref vError);

            if (vError == null)
            {
                if (permisos.consultar_Prop || permisos.registrar_Prop)
                {
                    return true;
                }
            }
            return false;
        }
    }
}