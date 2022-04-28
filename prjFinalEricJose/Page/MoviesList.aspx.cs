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
        static readonly string actualizar_pelicula = "actualizar_pelicula";
        #region EVENTOS
        /// <summary>
        /// Evento que se ejecuta al precionar uno de los botones dentro de el ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ltvPeliculas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            ListViewItem item = e.Item;
            int id_pelicula = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "btn_bono_2d")
            {
                ReclamarBono2D(item, id_pelicula);
            }
            else if (e.CommandName == "seleccionar_butaca")
            {
                SeleccionarButaca(item, id_pelicula);
            }
            else if (e.CommandName == "editar_pelicula")
            {
                EditarPelicula(item, id_pelicula);
            }
            else if (e.CommandName == "btn_bono_imax")
            {
                ReclamarBonoIMAX(item, id_pelicula);
            }
            else if (e.CommandName == "eliminar_pelicula")
            {
                EliminarPelicula(id_pelicula);
            }
        }
        /// <summary>
        /// Evento que se ejuecuta al completar los campos e intentar guardar/actualizar la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_guardar_pelicula_Click(object sender, EventArgs e)
        {
            if (camposLlenos())
            {
                if (((Button)sender).CommandName == actualizar_pelicula)
                {
                    ActualizarPeliculaEnDB();
                }
                else
                {
                    GuardarPelicula();
                }
            }
        }
        /// <summary>
        /// Evento que se ejecuta al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario_ingresado"] = blHelpers.UsuarioDefecto();//Borrar

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
        /// <summary>
        /// Evento que se ejecuta al precionarl el boton de abrir al panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_abrir_panel_nueva_pelicula_Click(object sender, EventArgs e)
        {
            lb_mensaje.Visible = false;
            pnl_formulario.Visible = true;
            btn_abrir_panel_nueva_pelicula.Visible = false;
            LimpiarDatos();
        }
        protected void btn_cancelar_formulario_Click(object sender, EventArgs e)
        {
            pnl_formulario.Visible = false;
            btn_abrir_panel_nueva_pelicula.Visible = true;
            LimpiarDatos();
        }
        #endregion

        #region Funciones
        
        #region Consultar
        /// <summary>
        /// Muestra la lista de peliculas, consultandolas desde la base de datos
        /// </summary>
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
            else
            {
                Mensaje(vError);
            }
        }
        /// <summary>
        /// Carga el DDL de los horarios disponibles a la hora de intentar registrar una pelicula
        /// </summary>
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
        /// <summary>
        /// Carga el DDL de las categorias de edades disponibles a la hora de intentar registrar una pelicula
        /// </summary>
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
        /// <summary>
        /// Funcion que consulta cual o cuales permisos tiene el usuario ingresado
        /// </summary>
        private void ConsultarPermisosPagina()
        {
            blPermiso lg_permisos = new blPermiso();
            string vError = null;


            clsUsuario usuario_actual = (clsUsuario)Session["usuario_ingresado"];

            clsPermiso dt_permiso = lg_permisos.CosultarPemisosPorRolModulo(usuario_actual.id_rol_Prop, blHelpers.PELICULAS, ref vError);

            if (dt_permiso.consultar_Prop)
            {
                MostrarListaPeliculas();
                MostrarListaHorariosDisponibles();
                MostrarListaCategoriasEdades();
            }
            if (dt_permiso.registrar_Prop)
            {
                PuedeAgregar();
            }
            if (dt_permiso.editar_Prop)
            {
                PuedeEditar();
            }
            if (dt_permiso.eliminar_Prop)
            {
                PuedeEliminar();
            }
        }
        #endregion

        #region Registrar
        /// <summary>
        /// Funcion que se ejecuta si el usuario puede registrar
        /// </summary>
        private void PuedeAgregar()
        {
            btn_abrir_panel_nueva_pelicula.Visible = true;
        }
        /// <summary>
        /// Funcion que se llama si los campos de las peliculas estan llenos y no hay errores
        /// </summary>
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
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "green-text";
                lb_mensaje.Text = "La película se ha regitrado con exito";
                MostrarListaPeliculas();
                ConsultarPermisosPagina();
                LimpiarDatos();
                pnl_formulario.Visible = false;
            }
            else
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "red-text";
                lb_mensaje.Text = "Ha ocurrido un error al intentar guardar la película";
            }
        }

        #endregion

        #region Editar
        /// <summary>
        /// Funcion que se llama a la hora de estar seguro que queremos actualizar la pelicula en la base de datos
        /// </summary>
        private void ActualizarPeliculaEnDB()
        {
            blPelicula lg_pelicula = new blPelicula();
            clsPelicula pelicula = (clsPelicula)Session["pelicula_seleccionada"];
            pelicula.nombre_pelicula_Prop = txt_nombre_pelicula.Text;
            pelicula.sinopsis_Prop = txt_sipnosis.Text;
            pelicula.id_categoria_edad_pelicula_Prop = Convert.ToInt32(ddl_categoria_edad.SelectedValue);
            string vError = null;

            lg_pelicula.ActualizarPelicula(pelicula, ref vError);

            if (vError == null)
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "green-text";
                lb_mensaje.Text = "La película se ha actualizado con exito";
                MostrarListaPeliculas();
                ConsultarPermisosPagina();
                LimpiarDatos();
                pnl_formulario.Visible = false;
            }
            else
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "red-text";
                lb_mensaje.Text = "Ha ocurrido un error al intentar actualizar la película";
            }
        }
        /// <summary>
        /// Funcion que se llama si el usuario puede editar en esta pagina
        /// </summary>
        private void PuedeEditar()
        {
            foreach (ListViewDataItem item in ltvPeliculas.Items)
            {
                ((Button)item.FindControl("btn_edit")).Visible = true;
            }
        }
        /// <summary>
        /// Funcion que se llama cuando el usuario preciona sobre el editar de una pelicula, muestra el panel y carga los datos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id_pelicula"></param>
        private void EditarPelicula(ListViewItem item, int id_pelicula)
        {
            blPelicula lg_pelicula = new blPelicula();
            string vError = null;

            List<clsPelicula> lista_peliculas = lg_pelicula.CosultarPeliculas(ref vError);

            if (vError == null)
            {
                pnl_formulario.Visible = true;
                clsPelicula pelicula = lista_peliculas.Find(peli => peli.id_pelicula_Prop == id_pelicula);
                Label lb_categoria_edad = (Label)item.FindControl("lb_categoria_edad");
                string nombre_categoria = lb_categoria_edad.Text.Substring(1, lb_categoria_edad.Text.Length - 2);

                txt_nombre_pelicula.Text = pelicula.nombre_pelicula_Prop;
                fud_imagen_pelicula.Enabled = false;
                txt_sipnosis.Text = pelicula.sinopsis_Prop;
                ddl_categoria_edad.SelectedIndex = ddl_categoria_edad.Items.IndexOf(ddl_categoria_edad.Items.FindByText(nombre_categoria));
                ltb_horarios_disponibles.Attributes.Add("disabled", "");
                sala1.Enabled = false;
                sala2.Enabled = false;
                sala3.Enabled = false;
                sala4.Enabled = false;
                sala5.Enabled = false;
                sala6.Enabled = false;

                Session["pelicula_seleccionada"] = pelicula;

                btn_guardar_pelicula.Text = "Actualizar Pelicula";
                btn_guardar_pelicula.CommandName = actualizar_pelicula;

                lb_mensaje.Visible = false;

            }
            else
            {
                Mensaje(vError);
            }
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// Funcion que se llama si el usuario puede eliminar, y de ser asi muestra en la vista los respectivos botones
        /// </summary>
        private void PuedeEliminar()
        {
            foreach (ListViewDataItem item in ltvPeliculas.Items)
            {
                ((Button)item.FindControl("btn_delete")).Visible = true;
            }
        }
        /// <summary>
        /// Funcion que se llama cuando el usuario preciona en el boton de  eliminar
        /// </summary>
        /// <param name="id_pelicula"></param>
        private void EliminarPelicula(int id_pelicula)
        {
            blPelicula lg_pelicula = new blPelicula();
            string vError = null;

            lg_pelicula.EliminarPelicula(id_pelicula, ref vError);


            if (vError == null)
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "green-text";
                lb_mensaje.Text = "La pelicula se ha eliminado con exito";
                MostrarListaPeliculas();
                ConsultarPermisosPagina();
                pnl_formulario.Visible = false;
            }
            else
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "red-text";
                lb_mensaje.Text = "Ha ocurrido un error al intentar eliminar la pelicula";
            }
        }
        #endregion

        #region Generales
        /// <summary>
        /// Funcion que muestra un alert en la pagina con el parametro string que se le envie
        /// </summary>
        /// <param name="pMensaje"></param>
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
        /// <summary>
        /// Funcion que se llama a la hora de precionar el boton de comprar ticket de una pelicula, y te lleva a seleccionar las butacas
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id_pelicula"></param>
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
        /// <summary>
        /// Funcion que devuelve la pagina a su estado por defecto
        /// </summary>
        private void LimpiarDatos()
        {
            txt_nombre_pelicula.Text = null;
            fud_imagen_pelicula.Dispose();
            txt_sipnosis.Text = null;
            if(ddl_categoria_edad != null && ddl_categoria_edad.Items.Count > 2)
            {
                ddl_categoria_edad.SelectedIndex = 0;
            }
            sala1.Checked = false;
            sala2.Checked = false;
            sala3.Checked = false;
            sala4.Checked = false;
            sala5.Checked = false;
            sala6.Checked = false;

            btn_guardar_pelicula.CommandName = null;
            btn_guardar_pelicula.Text = "Guardar Pelicula";
        }
        /// <summary>
        /// Funcion que filtra cuales sala de los checkbox fueron seleccionadas
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Funcion que se llama a la hora de reclamar un bono 2D en una de las peliculas
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id_pelicula"></param>
        private void ReclamarBono2D(ListViewItem item, int id_pelicula)
        {
            DropDownList ddl_sala = (DropDownList)item.FindControl("sala");
            DropDownList ddl_horario = (DropDownList)item.FindControl("horario");

            int id_sala = Convert.ToInt32(ddl_sala.SelectedValue);
            int id_horario = Convert.ToInt32(ddl_horario.SelectedValue);

            if (id_sala == 1 || id_sala == 4)
            {
                blTicket lg_ticket = new blTicket();
                string vError = null;
                clsUsuario usuario_actual = (clsUsuario)Session["usuario_ingresado"];

                int resultado = lg_ticket.ReclamarPromo2D(usuario_actual.dni_persona_Prop, id_pelicula, id_sala, id_horario, ref vError);

                if (resultado == -502)
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

                if (resultado > 0 && vError == null)
                {
                    Response.Redirect($"/factura/{resultado}");
                }
            }
            else
            {
                Mensaje("Debe asegurarse de elegir una sala 2D");
            }
        }
        /// <summary>
        /// Funcion que se llama  a la hora de precionar el boton de 3D en la lista de peliculas
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id_pelicula"></param>
        private void ReclamarBonoIMAX(ListViewItem item, int id_pelicula)
        {
            DropDownList ddl_sala = (DropDownList)item.FindControl("sala");
            DropDownList ddl_horario = (DropDownList)item.FindControl("horario");

            int id_sala = Convert.ToInt32(ddl_sala.SelectedValue);
            int id_horario = Convert.ToInt32(ddl_horario.SelectedValue);

            if (id_sala == 3 || id_sala == 6)
            {
                blTicket lg_ticket = new blTicket();
                string vError = null;
                clsUsuario usuario_actual = (clsUsuario)Session["usuario_ingresado"];

                int resultado = lg_ticket.ReclamarPromoIMAX(usuario_actual.dni_persona_Prop, id_pelicula, id_sala, id_horario, ref vError);

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
        /// <summary>
        /// Busca si existen campos sin rellenar en el Formulario
        /// </summary>
        /// <returns></returns>
        private Boolean camposLlenos()
        {
            if (string.IsNullOrEmpty(txt_nombre_pelicula.Text))
            {
                Mensaje("En nombre de la pelicula no puede estar vacio");
                txt_nombre_pelicula.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_sipnosis.Text))
            {
                Mensaje("La sinpsis no puede estar vacia");
                txt_sipnosis.Focus();
                return false;
            }
            if (!fud_imagen_pelicula.HasFile && btn_guardar_pelicula.CommandName != actualizar_pelicula)
            {
                Mensaje("Por favor seleccione una imagen para la Película");
                return false;
            }
            if(SalasSeleccionadas().Count < 1 && btn_guardar_pelicula.CommandName != actualizar_pelicula)
            {
                Mensaje("Debe selecciona al menos una sala donde se presentara la Película");
                return false;
            }
            if(ltb_horarios_disponibles.GetSelectedIndices().Length < 1 && btn_guardar_pelicula.CommandName != actualizar_pelicula)
            {
                Mensaje("Debe selecciona al menos un horario donde se presentara la Película");
                ltb_horarios_disponibles.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #endregion
    }
}