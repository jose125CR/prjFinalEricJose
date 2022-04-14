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
        
        int idSeleccionado;
        public void Mensaje(string pMensaje)
        {
            //HttpUtility.ParseQueryString(myU)
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
            //for(int i = 1; i <= 10; i++)
            //{
            //    Button btn = new Button();
            //    btn.Text = "A-" + i.ToString();
            //    btn.Click += (se, ev) => button_Click(se, ev, 10);
            //    pnl_btns.Controls.Add(btn);
            //}

            //btn.Click += (2, 1) => { your code; }; ;

            if (IsPostBack == false)
            {
                MostrarListaPeliculas();
                MostrarListaHorariosDisponibles();
                MostrarListaCategoriasEdades();
            }
        }

        protected void ltvPeliculas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            idSeleccionado = Convert.ToInt32(e.CommandArgument);
        }

        protected void ltvPeliculas_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            blPelicula lg_pelicula = new blPelicula();
            string vError = null;

            lg_pelicula.EliminarPelicula(idSeleccionado, ref vError);


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
            Mensaje(idSeleccionado.ToString());
        }

        protected void ltvPeliculas_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            ListViewItem item = ltvPeliculas.Items[e.ItemIndex];

            DropDownList textBox = (DropDownList)item.FindControl("horario");

            Session["id_pelicula"] = textBox.SelectedValue.ToString();

            Response.Redirect("SelectTicket.aspx");
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
    }
}