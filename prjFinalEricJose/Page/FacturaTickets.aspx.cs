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
    public partial class FacturaTickets : System.Web.UI.Page
    {
        int id_ticket = 0;

        private void CargarLabelsFactura()
        {
            blFacturaFinal lg_factura_final = new blFacturaFinal();
            string vError = null;

            clsFacturaFinal dt_factura_final = lg_factura_final.CosultarFacturaFinal(id_ticket, ref vError);

            txt_fecha_hora_compra.Text = dt_factura_final.dia_hora_compra_Prop;
            txt_nombre_pelicula.Text = dt_factura_final.nombre_pelicula_Prop;
            txt_categoria_pelicula.Text = dt_factura_final.categoria_edad_Prop;
            txt_dni_cliente.Text = dt_factura_final.dni_persona_Prop;
            txt_nombre_completo_cliente.Text = dt_factura_final.nombre_completo_persona_Prop;
            txt_butacas_general.Text = NumeroONinguna(dt_factura_final.contador_butacas_general_Prop);
            txt_butacas_nino.Text = NumeroONinguna(dt_factura_final.contador_butacas_ninos_Prop);
            txt_butacas_adulto.Text = NumeroONinguna(dt_factura_final.contador_butacas_adultos_Prop);
            txt_lista_butacas.Text = dt_factura_final.butacas_ordenadas_Prop;
            txt_sala.Text = dt_factura_final.sala_Prop;
            txt_hora_pelicula.Text = dt_factura_final.hora_pelicula_Prop;
            txt_puntos_ganados.Text = dt_factura_final.puntos_acumulados_Prop;
            
            if(dt_factura_final.monto_total_Prop == 0)
            {
                var num = dt_factura_final.sala_Prop.Split(' ');
                if (num[1] == "1" || num[1] == "4")
                {
                    txt_total_pagado_colones.Text = "Promocion 2D";
                    txt_total_pagado_dolares.Text = "Promocion 2D";
                }
                else
                {
                    txt_total_pagado_colones.Text = "Promocion IMAX";
                    txt_total_pagado_dolares.Text = "Promocion IMAX";
                }
            }
            else
            {
                txt_total_pagado_colones.Text = "₡" + dt_factura_final.monto_total_Prop.ToString();
                txt_total_pagado_dolares.Text = "$" + blHelpers.ConseguirValorDolares(dt_factura_final.monto_total_Prop).ToString();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            id_ticket = Convert.ToInt32(Page.RouteData.Values["id_ticket"]);
            CargarLabelsFactura();
        }

        private string NumeroONinguna(string numero_butacas)
        {
            if (numero_butacas != null)
            {
                return numero_butacas;
            }
            return "Ninguna";
        }

        protected void btn_guardar_pdf_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/imprimir/{id_ticket}");
        }
    }
}