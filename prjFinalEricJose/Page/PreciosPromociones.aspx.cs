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
    public partial class PreciosPromociones : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario_ingresado"] != null)
            {
                if (IsPostBack == false)
                {
                    ConsultarPermisosPagina();
                }
            }
            else
            {
                Response.Redirect($"/ingresar");
            }
        }

        private void ConsultarPermisosPagina()
        {
            blPermiso lg_permisos = new blPermiso();
            string vError = null;


            clsUsuario usuario_actual = (clsUsuario)Session["usuario_ingresado"];

            clsPermiso dt_permiso = lg_permisos.CosultarPemisosPorRolModulo(usuario_actual.id_rol_Prop, blHelpers.PRECIOS, ref vError);

            if (dt_permiso.consultar_Prop)
            {
                pnl_precios_promociones.Visible = true;
                pnl_precios_categorias.Visible = true;
                pnl_puntos_canjes.Visible = true;
                ConsultarPromociones();
                ConsultarPreciosCategorias();
                ConsultarPuntosCanjesMinimos();
            }
            if (dt_permiso.editar_Prop)
            {
                PuedeEditar();
            }
        }

        private void PuedeEditar()
        {
            foreach (GridViewRow item in grd_promociones.Rows)
            {
                ((TextBox)item.FindControl("txt_domingo")).Enabled = true;
                ((TextBox)item.FindControl("txt_lunes")).Enabled = true;
                ((TextBox)item.FindControl("txt_martes")).Enabled = true;
                ((TextBox)item.FindControl("txt_miercoles")).Enabled = true;
                ((TextBox)item.FindControl("txt_jueves")).Enabled = true;
                ((TextBox)item.FindControl("txt_viernes")).Enabled = true;
                ((TextBox)item.FindControl("txt_sabado")).Enabled = true;
            }

            btn_actualizar_promociones.Visible = true;

            foreach (GridViewRow item in grd_precios_categorias.Rows)
            {
                ((TextBox)item.FindControl("txt_general")).Enabled = true;
                ((TextBox)item.FindControl("txt_nino")).Enabled = true;
                ((TextBox)item.FindControl("txt_adulto")).Enabled = true;
            }

            btn_actualizar_precios_categorias.Visible = true;

            txt_puntos_minimos.Enabled = true;
            txt_canjes_minimos.Enabled = true;

            btn_actualizar_puntos_canjes.Visible = true;
        }

        private void ConsultarPromociones()
        {
            blSemanaPromocion lg_promociones = new blSemanaPromocion();

            string vError = null;

            List<clsSemanaPromicion> lista_promociones = lg_promociones.CosultarPromociones(ref vError);

            if (vError == null)
            {
                grd_promociones.DataSource = lista_promociones;
                grd_promociones.DataBind();
            }
        }

        private void ConsultarPreciosCategorias()
        {
            blPreciosCategorias lg_precio_categoria = new blPreciosCategorias();

            string vError = null;

            List<clsPreciosCategorias> lista_promociones = lg_precio_categoria.CosultarPreciosCategorias(ref vError);

            if (vError == null)
            {
                grd_precios_categorias.DataSource = lista_promociones;
                grd_precios_categorias.DataBind();
            }
        }

        private void ActualizarPromociones()
        {
            List<clsSemanaPromicion> promociones_semana = new List<clsSemanaPromicion>();
            blSemanaPromocion lg_promociones = new blSemanaPromocion();
            string vError = null;

            for (int tipo_sala = 1; tipo_sala <= 3; tipo_sala++)
            {

                clsSemanaPromicion semana = new clsSemanaPromicion();
                semana.dia_domingo_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_domingo")).Text);
                semana.dia_lunes_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_lunes")).Text);
                semana.dia_martes_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_martes")).Text);
                semana.dia_miercoles_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_miercoles")).Text);
                semana.dia_jueves_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_jueves")).Text);
                semana.dia_viernes_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_viernes")).Text);
                semana.dia_sabado_prop = float.Parse(((TextBox)grd_promociones.Rows[tipo_sala - 1].FindControl("txt_sabado")).Text);

                promociones_semana.Add(semana);
            }

            lg_promociones.ActualizarPromociones(promociones_semana, ref vError);

            if (vError == null)
            {
                ConsultarPermisosPagina();
            }
            else
            {
                Mensaje("Ocurrio un error al intentar actualizar las promociones");
            }
        }

        protected void btn_actualizar_promociones_Click(object sender, EventArgs e)
        {
            ActualizarPromociones();
        }

        protected void btn_actualizar_precios_categorias_Click(object sender, EventArgs e)
        {
            ActualizarPreciosCategorias();
        }

        private void ActualizarPreciosCategorias()
        {
            List<clsPreciosCategorias> precios_categorias = new List<clsPreciosCategorias>();
            blPreciosCategorias lg_categorias = new blPreciosCategorias();
            string vError = null;

            for (int tipo_sala = 1; tipo_sala <= 3; tipo_sala++)
            {

                clsPreciosCategorias dt_precio = new clsPreciosCategorias();
                dt_precio.precio_general_prop = float.Parse(((TextBox)grd_precios_categorias.Rows[tipo_sala - 1].FindControl("txt_general")).Text);
                dt_precio.precio_nino_prop = float.Parse(((TextBox)grd_precios_categorias.Rows[tipo_sala - 1].FindControl("txt_nino")).Text);
                dt_precio.precio_adulto_prop = float.Parse(((TextBox)grd_precios_categorias.Rows[tipo_sala - 1].FindControl("txt_adulto")).Text);

                precios_categorias.Add(dt_precio);

            }

            lg_categorias.ActualizarPreciosCategorias(precios_categorias, ref vError);

            if (vError == null)
            {
                ConsultarPermisosPagina();
            }
            else
            {
                Mensaje("Ocurrio un error al intentar actualizar los precios de las categorias");
            }
        }

        private void ConsultarPuntosCanjesMinimos()
        {
            blPuntosCanjesMinimos lg_puntos_canjes = new blPuntosCanjesMinimos();
            string vError = null;

            clsPuntosCanjesMinimos puntos_canges = lg_puntos_canjes.CosultarPuntosCangesMinimos(ref vError);

            if (vError == null)
            {
                txt_puntos_minimos.Text = puntos_canges.puntos_necesarios_Prop.ToString();
                txt_canjes_minimos.Text = puntos_canges.canjes_necesarios_Prop.ToString();
            }
        }

        protected void btn_actualizar_puntos_canjes_Click(object sender, EventArgs e)
        {
            blPuntosCanjesMinimos lg_puntos_canjes = new blPuntosCanjesMinimos();
            clsPuntosCanjesMinimos dt_puntos_canjes = new clsPuntosCanjesMinimos();
            string vError = null;

            dt_puntos_canjes.puntos_necesarios_Prop = Convert.ToInt32(txt_puntos_minimos.Text);
            dt_puntos_canjes.canjes_necesarios_Prop = Convert.ToInt32(txt_canjes_minimos.Text);

            lg_puntos_canjes.ActualizarPuntosCanjesMinimos(dt_puntos_canjes, ref vError);

            if (vError == null)
            {
                ConsultarPermisosPagina();
            }
            else
            {
                Mensaje("Ocurrio un error al intentar actualizar los precios de las categorias");
            }

        }
    }
}