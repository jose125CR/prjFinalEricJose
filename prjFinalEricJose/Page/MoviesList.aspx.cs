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
    public partial class MoviesList : System.Web.UI.Page
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

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        public void MostrarListaPeliculas()
        {
            blPelicula lg_pelicula = new blPelicula();
            string vError = null;

            List<clsPelicula> lista_peliculas = lg_pelicula.CosultarPeliculas(ref vError);
            int id = lg_pelicula.ConseguirNuevoIdPelicula(ref vError);

            if (vError == null)
            {
                ltvPeliculas.DataSource = lista_peliculas;
                ltvPeliculas.DataBind();
            }
            else {
                Mensaje(vError);
            }
        }

        public void MostrarListaHorariosDisponibles()
        {
            blHorario lg_horario = new blHorario();
            string vError = null;

            List<clsHorario> lista_horarios = lg_horario.CosultarListaHorarios(ref vError);

            if (vError == null)
            {
                ltb_horarios_disponibles.DataSource = lista_horarios;
                ltb_horarios_disponibles.DataTextField = "horario_Prop";
                ltb_horarios_disponibles.DataValueField = "id_horario_Prop";
                ltb_horarios_disponibles.DataBind();
            }
        }

        public void MostrarListaCategoriasEdades()
        {
            blCategoriaEdad lg_categoria_edad = new blCategoriaEdad();
            string vError = null;

            List<clsCategoriaEdad> lista_categorias_edades = lg_categoria_edad.CosultarListaCategoriaEdades(ref vError);

            if (vError == null)
            {
                ddl_categoria_edad.DataSource = lista_categorias_edades;
                ddl_categoria_edad.DataTextField = "categoria_edad_prop";
                ddl_categoria_edad.DataValueField = "id_categoria_edad_pelicula_Prop";
                ddl_categoria_edad.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //string vError = null;

            //Boolean consultar = blPermiso.CosultarPermisoPagina(blHelpers.PELICULAS, blHelpers.CONSULTAR, ref vError);

            //if (consultar)
            //{
            //    ltvPeliculas.Visible = false;
            //}
            if (IsPostBack == false)
            {
                MostrarListaPeliculas();
                MostrarListaHorariosDisponibles();
                MostrarListaCategoriasEdades();
            }
        }

        protected void ltvPeliculas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ListViewItem item = e.Item;
            int id_pelicula = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "btn_bono_2d")
            {
                ReclamarBono2D(item, id_pelicula);
            }else if(e.CommandName == "seleccionar_butaca")
            {
                SeleccionarButaca(item, id_pelicula);
            }
            else if(e.CommandName == "btn_bono_imax")
            {
                ReclamarBonoIMAX(item, id_pelicula);
            }
            else if(e.CommandName == "eliminar_pelicula")
            {
                EliminarPelicula(id_pelicula);
            }
        }

        private void SeleccionarButaca(ListViewItem item, int id_pelicula)
        {
            DropDownList ddl_horario = (DropDownList)item.FindControl("horario");
            DropDownList ddl_sala = (DropDownList)item.FindControl("sala");
            DropDownList ddl_dia = (DropDownList)item.FindControl("dia");
            string id_peli = id_pelicula.ToString();
            string id_horario = ddl_horario.SelectedValue.ToString();
            string id_sala = ddl_sala.SelectedValue.ToString();
            string id_dia = ddl_dia.SelectedValue.ToString();

            Response.Redirect($"/tickets/{id_peli}/{id_horario}/{id_sala}/{id_dia}");
        }


        private void EliminarPelicula(int id_pelicula)
        {
            blPelicula lg_pelicula = new blPelicula();
            string vError = null;

            lg_pelicula.EliminarPelicula(id_pelicula, ref vError);


            if (vError == null)
            {
                Mensaje("Película eliminada con exito");
                MostrarListaPeliculas();
            }
            else
            {
                Mensaje("Error al eliminar la Película");
            }
        }

        protected void ltvPeliculas_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            
        }

        private void GuardarPelicula()
        {
            blHorario lg_horario = new blHorario();
            string vError = null;
            //Llamar a todos los horarios
            List<clsHorario> lista_horarios = lg_horario.CosultarListaHorarios(ref vError);
            //Lista horarios vacia
            List<clsHorario> lista_horarios_seleccionado = new List<clsHorario>();
            clsPelicula dt_pelicula = new clsPelicula();
            blPelicula lg_pelicula = new blPelicula();

            if (fud_imagen_pelicula.HasFile)
            {
                //si hay un archivo.
                string nombreArchivo = fud_imagen_pelicula.FileName;
                string ruta = "~/Sources/images/uploads/" + nombreArchivo;
                fud_imagen_pelicula.SaveAs(Server.MapPath(ruta));
                dt_pelicula.direccion_img_prop = nombreArchivo;

            }
            else
            {
                //si no se selecciona ninguna imagen selecciona una por defecto
                dt_pelicula.direccion_img_prop = "default.jpg";
            }

            //Se agregan al objeto de pelicula los campos que son solo texto
            dt_pelicula.nombre_pelicula_Prop = txt_nombre_pelicula.Text;
            dt_pelicula.sinopsis_Prop = txt_sipnosis.Text;

            //Primero se guardan lo indices seleccionados de la listbox
            //Luego se recorren los indices y se buscan los objetos en la lista de horarios y encontrarlos por el index
            int[] indexes = this.ltb_horarios_disponibles.GetSelectedIndices();
            foreach (int index in indexes)
            {
                lista_horarios_seleccionado.Add(lista_horarios[index]);
            }
            dt_pelicula.horarios_Prop = lista_horarios_seleccionado;

            dt_pelicula.id_categoria_edad_pelicula_Prop = Convert.ToInt32(ddl_categoria_edad.SelectedValue);

            //El método nos regresa la lista de salas que han sido marcadas
            dt_pelicula.salas_Prop = SalasSeleccionadas();

            lg_pelicula.GuardarPelicula(dt_pelicula, ref vError);

            if (vError == null)
            {
                Mensaje("Pelicula registrada con exito");
                MostrarListaPeliculas();
            }
            else
            {
                Mensaje("Error al registrar la Pelicula");
            }
        }

        protected void btn_guardar_pelicula_Click(object sender, EventArgs e)
        {
            GuardarPelicula();
        }

        private List<clsSalaPelicula> SalasSeleccionadas()
        {
            List<clsSalaPelicula> dt_salas_seleccionadas = new List<clsSalaPelicula>();

            if (sala1.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 1, nombre_tipo_sala_Prop = "sala1" });
            }
            if (sala2.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 2, nombre_tipo_sala_Prop = "sala2" });
            }
            if (sala3.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 3, nombre_tipo_sala_Prop = "sala3" });
            }
            if (sala4.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 4, nombre_tipo_sala_Prop = "sala4" });
            }
            if (sala5.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 5, nombre_tipo_sala_Prop = "sala5" });
            }
            if (sala6.Checked)
            {
                dt_salas_seleccionadas.Add(new clsSalaPelicula() { id_sala_cartelera_Prop = 6, nombre_tipo_sala_Prop = "sala6" });
            }

            return dt_salas_seleccionadas;
        }

        private void ReclamarBono2D(ListViewItem item, int id_pelicula)
        {
            DropDownList ddl_sala = (DropDownList)item.FindControl("sala");
            DropDownList ddl_horario = (DropDownList)item.FindControl("horario");
            //DropDownList ddl_dia = (DropDownList)item.FindControl("dia");

            int id_sala = Convert.ToInt32(ddl_sala.SelectedValue);
            int id_horario = Convert.ToInt32(ddl_horario.SelectedValue);

            if(id_sala == 1 || id_sala == 4)
            {
                blTicket lg_ticket = new blTicket();
                string vError = null;
                int resultado = lg_ticket.ReclamarPromo2D("115960067", id_pelicula, id_sala, id_horario, ref vError);

                if(resultado == -502)
                {
                    Mensaje("La sala esta llena");
                }

                if (resultado == -501)
                {
                    Mensaje("No dispones de los puntos suficientes");
                }

                if (vError != null)
                {
                    Mensaje("Ha ocurrido un error por favor reintenta");
                }

                if(resultado > 0 && vError == null)
                {
                    Response.Redirect($"/factura/{resultado}");
                }
            }
            else
            {
                Mensaje("Debe asegurarse de elegir una sala 2D");
            }
        }

        private void ReclamarBonoIMAX(ListViewItem item, int id_pelicula)
        {
            DropDownList ddl_sala = (DropDownList)item.FindControl("sala");
            DropDownList ddl_horario = (DropDownList)item.FindControl("horario");
            //DropDownList ddl_dia = (DropDownList)item.FindControl("dia");

            int id_sala = Convert.ToInt32(ddl_sala.SelectedValue);
            int id_horario = Convert.ToInt32(ddl_horario.SelectedValue);

            if (id_sala == 3 || id_sala == 6)
            {
                blTicket lg_ticket = new blTicket();
                string vError = null;
                int resultado = lg_ticket.ReclamarPromoIMAX("115960067", id_pelicula, id_sala, id_horario, ref vError);

                if (resultado == -502)
                {
                    Mensaje("La sala esta llena");
                }

                if (resultado == -501)
                {
                    Mensaje("No dispones de los canjeos suficientes");
                }

                if (vError != null)
                {
                    Mensaje("Ha ocurrido un error por favor reintenta");
                }

                if (resultado > 0 && vError == null)
                {
                    Response.Redirect($"/factura/{resultado}");
                }
            }
            else
            {
                Mensaje("Debe asegurarse de elegir una sala IMAX");
            }
        }

    }
}