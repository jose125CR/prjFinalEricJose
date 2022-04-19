using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;
using System.Net;
using System.Web.Script.Serialization;

namespace prjFinalEricJose.Page
{
    public partial class SelectTicket : System.Web.UI.Page
    {
        private List<clsButaca> lista_butacas = new List<clsButaca>();
        const string ocupada = "o";
        const string disponible = "d";
        const string seleccionada = "s";
        int id_pelicula = 0;
        int id_horario = 0;
        int id_sala = 0;
        int id_dia_seleccionado = 0;
        const int id_categoria_persona = 1;
        const string dni_persona = "115960067";

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

        private void Cargar_butacas()
        {
            blButaca lg_butaca = new blButaca();

            string vError = null;

            lista_butacas = lg_butaca.ConsultarButacasHorarioSalaPelicula(id_pelicula, id_horario, id_sala, ref vError);

            if (vError == null)
            {
                for (int index = 1; index <= lista_butacas.Count; index++)
                {
                    Button btn = new Button();
                    btn.CssClass = "seat me-1 ms-1 mt-2" + ConseguirClaseButaca(index, lista_butacas[index - 1]);
                    btn.Text = lista_butacas[index - 1].identificador_Prop;
                    btn.Click += new EventHandler(buataca_preciona);
                    PlaceholderControls.Controls.Add(btn);
                }
            }
            else
            {
                Mensaje(vError);
            }
        }

        private void CargarPreciosCantidad()
        {
            blPreciosEntradasSalaDia lg_precios_entradas = new blPreciosEntradasSalaDia();
            string vError = null;
            List<clsPreciosEntradasSalaDia> precios = new List<clsPreciosEntradasSalaDia>();

            float precio_final = 0;

            ValoresDefecto();

            precios = lg_precios_entradas.CosultarPreciosPorSalaDiaHorario(id_pelicula, id_horario, id_sala, id_dia_seleccionado, ref vError);

            foreach (clsPreciosEntradasSalaDia pe in precios)
            {
                if (pe.id_categoria_persona_Prop == 1)
                {
                    txt_cantidad_general.Text = pe.cantidad_butacas_Prop.ToString();
                    txt_precio_general.Text = "₡" + pe.precio_total_categoria_prop.ToString();
                    precio_final += pe.precio_total_categoria_prop;
                }
                else if (pe.id_categoria_persona_Prop == 2)
                {
                    txt_cantidad_ninos.Text = pe.cantidad_butacas_Prop.ToString();
                    txt_precio_ninos.Text = "₡" + pe.precio_total_categoria_prop.ToString();
                    precio_final += pe.precio_total_categoria_prop;
                }
                else if (pe.id_categoria_persona_Prop == 3)
                {
                    txt_cantidad_adulto.Text = pe.cantidad_butacas_Prop.ToString();
                    txt_precio_adulto.Text = "₡" + pe.precio_total_categoria_prop.ToString();
                    precio_final += pe.precio_total_categoria_prop;
                }
            }

            txt_total_pagar_colones.Text = precio_final.ToString();



            txt_total_pagar_dolares.Text = blHelpers.ConseguirValorDolares(precio_final).ToString();
        }

        private void ValoresDefecto()
        {
            txt_cantidad_general.Text = "0";
            txt_cantidad_ninos.Text = "0";
            txt_cantidad_adulto.Text = "0";

            txt_precio_general.Text = "₡0";
            txt_precio_ninos.Text = "₡0";
            txt_precio_adulto.Text = "₡0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["id_pelicula"] != null &&
                Page.RouteData.Values["id_horario"] != null &&
                Page.RouteData.Values["id_sala"] != null &&
                Page.RouteData.Values["id_dia"] != null
            )
            {
                id_pelicula = Convert.ToInt32(Page.RouteData.Values["id_pelicula"]);
                id_horario = Convert.ToInt32(Page.RouteData.Values["id_horario"]);
                id_sala = Convert.ToInt32(Page.RouteData.Values["id_sala"]);
                id_dia_seleccionado = Convert.ToInt32(Page.RouteData.Values["id_dia"]);
            }
            if (!IsPostBack)
            {
                CargarDdlCategoriaPersona();
                CargarPreciosCantidad();
            }
            Cargar_butacas();
        }

        private string ConseguirClaseButaca(int index, clsButaca bt)
        {
            string clase_final = " ";

            if (index % 5 == 0 || (index - 2) % 5 == 0)
            {
                clase_final += " ms-5";
            }
            else if ((index - 1) % 5 == 0 || (index + 1) % 5 == 0)
            {
                clase_final += " me-5";
            }

            if (bt != null)
            {
                if (bt.estado_Prop == seleccionada)
                {
                    clase_final += " seleccionada";
                }
                else if (bt.estado_Prop == ocupada)
                {
                    clase_final += " ocupada";
                }
            }

            return clase_final;
        }

        public void buataca_preciona(object sender, EventArgs e)
        {
            blButaca lg_butaca = new blButaca();
            Button btn = (Button)sender;
            ViewState["seleccionada"] = btn.Text;
            string vError = null;

            string tex = btn.Text;

            clsButaca r_butaca = lg_butaca.ConsultarUnaButaca(id_pelicula, id_horario, id_sala, btn.Text, ref vError);

            if (vError == null)
            {
                int selected_index_btn = PlaceholderControls.Controls.IndexOf(btn);

                if (r_butaca.estado_Prop == seleccionada)
                {
                    PlaceholderControls.Controls.Remove(btn);

                    btn.CssClass = "seat me-1 ms-1 mt-2 disponible" + ConseguirClaseButaca(selected_index_btn + 1, null);
                    btn.Click += new EventHandler(buataca_preciona);
                    PlaceholderControls.Controls.AddAt(selected_index_btn, btn);

                    lg_butaca.ActualizarButaca(id_pelicula, id_horario, id_sala, id_categoria_persona, btn.Text, disponible, ref vError);

                    ddl_seleccionar_persona.Visible = false;
                }
                else if (r_butaca.estado_Prop == disponible)
                {
                    PlaceholderControls.Controls.Remove(btn);


                    btn.CssClass = "seat me-1 ms-1 mt-2 seleccionada" + ConseguirClaseButaca(selected_index_btn + 1, null);
                    btn.Click += new EventHandler(buataca_preciona);
                    PlaceholderControls.Controls.AddAt(selected_index_btn, btn);


                    lg_butaca.ActualizarButaca(id_pelicula, id_horario, id_sala, id_categoria_persona, btn.Text, seleccionada, ref vError);

                    ddl_seleccionar_persona.Visible = true;
                }
            }

            if (vError != null)
            {
                Mensaje("Ha ocurrido un error, por favor intente de nuevo");
            }
            else
            {
                CargarPreciosCantidad();
            }
        }

        private void CargarDdlCategoriaPersona()
        {
            blCategoriaPersona lg_categoria_persona = new blCategoriaPersona();

            string vError = null;

            List<clsCategoriaPersona> lista_categorias_personas = lg_categoria_persona.CosultarListaCategoriaPersonas(ref vError);

            if (vError == null)
            {
                ddl_seleccionar_persona.DataSource = lista_categorias_personas;
                ddl_seleccionar_persona.DataTextField = "nombre_categoria_prop";
                ddl_seleccionar_persona.DataValueField = "id_categoria_persona_Prop";
                ddl_seleccionar_persona.DataBind();
            }
        }

        protected void ddl_seleccionar_persona_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int valor_seleccionado = Convert.ToInt32(ddl.SelectedValue);

            blButaca lg_butaca = new blButaca();

            ddl_seleccionar_persona.Visible = false;

            string vError = null;

            string butaca_seleccionada = Convert.ToString(ViewState["seleccionada"]);

            lg_butaca.ActualizarButaca(id_pelicula, id_horario, id_sala, valor_seleccionado, butaca_seleccionada, seleccionada, ref vError);

            if (vError != null)
            {
                Mensaje(vError);
            }
            else
            {
                CargarPreciosCantidad();
            }
        }

        protected void btn_comprar_Click(object sender, EventArgs e)
        {
            blButaca lg_butaca = new blButaca();
            blTicket lg_ticket = new blTicket();
            blButacaTicket lg_butaca_ticket = new blButacaTicket();
            clsTicket dt_ticket = new clsTicket();
            string vError = null;

            List<clsButaca> butacas_seleccionadas = lg_butaca.ConsultarButacasHorarioSalaPeliculaSeleccionadas(id_pelicula, id_horario, id_sala, ref vError);

            int nuevo_id = -1;
            if (vError == null)
            {
                nuevo_id = lg_ticket.ConseguirNuevoIdTicket(ref vError);

                dt_ticket.id_ticket_Prop = nuevo_id;
                dt_ticket.id_pelicula_Prop = id_pelicula;
                dt_ticket.dni_persona_prop = dni_persona;
                dt_ticket.id_sala_pelicula_prop = id_sala;
                dt_ticket.id_horario_pelicula_prop = id_horario;

                lg_ticket.Guardarticket(dt_ticket, ref vError);

                if (vError == null)
                {
                    foreach (clsButaca bt in butacas_seleccionadas)
                    {
                        float precio_butaca = lg_butaca.ConsultarPrecioButaca(id_sala, id_dia_seleccionado, bt.id_categoria_persona_Prop, ref vError);

                        if (vError == null)
                        {
                            lg_butaca_ticket.GuardarButacaTicket(nuevo_id, bt.id_butaca_Prop, precio_butaca, ref vError);

                            if (vError == null)
                            {
                                lg_butaca.ActualizarButaca(id_pelicula, id_horario, id_sala, bt.id_categoria_persona_Prop, bt.identificador_Prop, ocupada, ref vError);
                            }
                        }
                    }
                }
            }

            if (vError == null)
            {
                Response.Redirect($"/factura/{nuevo_id}");
            }
        }
    }
}