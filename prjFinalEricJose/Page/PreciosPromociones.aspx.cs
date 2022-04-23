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
            if (!IsPostBack)
            {
                ConsultarPromociones();
                ConsultarPreciosCategorias();
            }
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

                int asd = 0;
            }

            lg_promociones.ActualizarPromociones(promociones_semana, ref vError);

            if (vError == null)
            {
                ConsultarPromociones();
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
    }
}