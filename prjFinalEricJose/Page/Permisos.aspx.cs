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
    public partial class Permisos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario_ingresado"] != null)
            {
                if (IsPostBack == false)
                {
                    List<clsPermiso> lista_permisos = new List<clsPermiso>();
                    blPermiso lg_permiso = new blPermiso();
                    string vError = null;

                    clsPermiso permiso = lg_permiso.CosultarPemisosPorRolModulo(1, 1, ref vError);
                    lista_permisos.Add(permiso);

                    grd_permisos.DataSource = lista_permisos;
                    grd_permisos.DataBind();

                    caragarListaRoles();
                    caragarListaModulos();
                }
            }
            else
            {
                Response.Redirect($"/ingresar");
            }
        }

        public void caragarListaRoles()
        {
            blRol lg_rol = new blRol();
            string vError = null;

            List<clsRol> lista_roles = lg_rol.CosultarRoles(ref vError);

            if (vError == null)
            {
                ddl_roles.DataSource = lista_roles;
                ddl_roles.DataTextField = "rol_Prop";
                ddl_roles.DataValueField = "id_rol_Prop";
                ddl_roles.DataBind();
            }
        }

        public void caragarListaModulos()
        {
            blModulo lg_modulo = new blModulo();
            string vError = null;

            List<clsModulo> lista_modulos = lg_modulo.CosultarModulos(ref vError);

            if (vError == null)
            {
                ddl_modulos.DataSource = lista_modulos;
                ddl_modulos.DataTextField = "nombre_pagina_Prop";
                ddl_modulos.DataValueField = "id_pagina_Prop";
                ddl_modulos.DataBind();
            }
        }

        protected void ddl_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rol_seleccionado = Convert.ToInt32(ddl_roles.SelectedValue);
            int modulo_seleccionado = Convert.ToInt32(ddl_modulos.SelectedValue);

            List<clsPermiso> lista_permisos = new List<clsPermiso>();
            blPermiso lg_permiso = new blPermiso();
            string vError = null;

            clsPermiso permiso = lg_permiso.CosultarPemisosPorRolModulo(rol_seleccionado, modulo_seleccionado, ref vError);
            lista_permisos.Add(permiso);

            grd_permisos.DataSource = lista_permisos;
            grd_permisos.DataBind();

            lb_mensaje_resultado.Visible = false;
        }

        protected void cbx_permisos_CheckedChanged(object sender, EventArgs e)
        {
            blPermiso lg_permiso = new blPermiso();
            clsPermiso dt_permisos = new clsPermiso();
            lb_mensaje_guardo.Visible = false;
            int rol_seleccionado = Convert.ToInt32(ddl_roles.SelectedValue);
            int modulo_seleccionado = Convert.ToInt32(ddl_modulos.SelectedValue);

            CheckBox cbx_consulta =  (CheckBox)grd_permisos.Rows[0].FindControl("cbx_consulta");
            CheckBox cbx_registrar =  (CheckBox)grd_permisos.Rows[0].FindControl("cbx_registrar");
            CheckBox cbx_modificar =  (CheckBox)grd_permisos.Rows[0].FindControl("cbx_modificar");
            CheckBox cbx_eliminar =  (CheckBox)grd_permisos.Rows[0].FindControl("cbx_eliminar");

            dt_permisos.consultar_Prop = cbx_consulta.Checked;
            dt_permisos.registrar_Prop = cbx_registrar.Checked;
            dt_permisos.editar_Prop = cbx_modificar.Checked;
            dt_permisos.eliminar_Prop = cbx_eliminar.Checked;

            string vError = null;

            lg_permiso.ActualizarPermisosPorRolModulo(rol_seleccionado, modulo_seleccionado, dt_permisos, ref vError);

            if(vError == null)
            {
                lb_mensaje_resultado.Visible = true;
                lb_mensaje_resultado.Text = "Se ha actualizado con exito";
            }
            else
            {
                lb_mensaje_resultado.Text = "Ha ocurrido un error al intentar actualizar";
                lb_mensaje_resultado.CssClass = "red-text";
            }
        }

        protected void btn_guardar_rol_Click(object sender, EventArgs e)
        {
            blRol lg_rol = new blRol();
            lb_mensaje_resultado.Visible = false;

            string vError = null;
            lg_rol.GuardarRol(txt_nombre_rol.Text, ref vError);

            if (vError == null)
            {
                lb_mensaje_guardo.Visible = true;
                lb_mensaje_guardo.Text = "Se ha registrado con exito";
                caragarListaRoles();
            }
            else
            {
                lb_mensaje_guardo.Text = "Ha ocurrido un error al intentar registrar";
                lb_mensaje_guardo.CssClass = "red-text";
            }
        }

        protected void btn_eliminar_rol_Click(object sender, EventArgs e)
        {
            blRol lg_rol = new blRol();
            lb_mensaje_guardo.Visible = false;
            int id_rol_eliminar = Convert.ToInt32(ddl_roles.SelectedValue);
            string vError = null;
            lg_rol.EliminarRol(id_rol_eliminar, ref vError);

            if (vError == null)
            {
                lb_mensaje_resultado.Visible = true;
                lb_mensaje_resultado.Text = "Se ha eliminado con exito";
                caragarListaRoles();
            }
            else
            {
                lb_mensaje_resultado.Text = "Ha ocurrido un error al intentar eliminar";
                lb_mensaje_resultado.CssClass = "red-text";
            }
        }
    }
}