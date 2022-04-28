using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;
using System.Text.RegularExpressions;

namespace prjFinalEricJose.Page
{
    public partial class UsersList : System.Web.UI.Page
    {
        #region Eventos
        /// <summary>
        /// Evento que se ejecuta siempre que la pagina se cargue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario_ingresado"] = blHelpers.UsuarioDefecto();//Borrar
            
            if(Session["usuario_ingresado"] != null)
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
        /// Evento que se ejecuta al precionar el boton de guardar/actualizar una persona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_guardar_persona_Click(object sender, EventArgs e)
        {
            if (camposLlenos())
            {
                if (btn_guardar_persona.CommandName == "actualizar")
                {
                    ActualizarUsuario();
                }
                else
                {
                    RegistrarPersona();
                }
            }
        }
        /// <summary>
        /// Evento que se ejecuta al precionar el boton de eliminar en una fila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdUsuarios.Rows[e.RowIndex];
            string dni_to_delete = row.Cells[0].Text;

            EliminarPersona(dni_to_delete);
        }
        /// <summary>
        /// Evento que se ejecuta al precionar el boton de actualizar en una fila muestra el formulario, lo carga con los datos del usuario seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            blUsuario lg_persona = new blUsuario();
            GridViewRow row = grdUsuarios.Rows[e.RowIndex];
            string dni_to_edit = row.Cells[0].Text;
            string vError = null;

            List<clsUsuario> lista = lg_persona.CosultarUsuarios(ref vError);

            txt_dni.Enabled = false;
            formulario_persona.Visible = true;
            btn_abrir_panel_nuevo_usuario.Visible = false;
            lb_mensaje.Visible = false;
            btn_guardar_persona.CommandName = "actualizar";
            btn_guardar_persona.Text = "Actualizar Usuario";

            if (vError == null && lista.Any())
            {
                clsUsuario dt_persona = lista.Find(x => x.dni_persona_Prop == dni_to_edit);

                txt_dni.Text = dt_persona.dni_persona_Prop;
                ddl_roles.SelectedValue = dt_persona.id_rol_Prop.ToString();
                txt_nombre1.Text = dt_persona.nombre1_Prop;
                txt_nombre2.Text = dt_persona.nombre2_Prop;
                txt_apellido1.Text = dt_persona.apellido1_Prop;
                txt_apellido2.Text = dt_persona.apellido2_Prop;
                txt_correo.Text = dt_persona.correo_Prop;
                txt_fecha_nac.Text = dt_persona.fecha_nac_Prop.ToString("yyyy-MM-dd");
                txt_telefono.Text = dt_persona.telefono_Prop;
                txt_usuario.Text = dt_persona.usuario_Prop;
                txt_contrasena.Text = dt_persona.contrasena_Prop;
                txt_contrasena2.Text = dt_persona.contrasena_Prop;
            }
            else
            {
                lb_mensaje.CssClass = "red-text";
                lb_mensaje.Text = "Error al cargar los datos de editar";
            }
        }
        /// <summary>
        /// Se ejecuta al precionar el boton para agregar un nuevo usuario y muestra el panel del formulario para ser llenado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_abrir_panel_nuevo_usuario_Click(object sender, EventArgs e)
        {
            lb_mensaje.Visible = false;
            formulario_persona.Visible = true;
            btn_abrir_panel_nuevo_usuario.Visible = false;
        }
        /// <summary>
        /// Se ejecuta al precionar el boton de cancelar dentro de formulario y su funcion es ocultar y limpiar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelar_formulario_Click(object sender, EventArgs e)
        {
            formulario_persona.Visible = false;
            btn_abrir_panel_nuevo_usuario.Visible = true;
            LimpiarDatos();
        }
        #endregion


        #region Funciones
        private void ConsultarPermisosPagina()
        {
            blPermiso lg_permisos = new blPermiso();
            string vError = null;


            clsUsuario usuario_actual = (clsUsuario)Session["usuario_ingresado"];

            clsPermiso dt_permiso = lg_permisos.CosultarPemisosPorRolModulo(usuario_actual.id_rol_Prop, blHelpers.USUARIOS, ref vError);

            if (dt_permiso.consultar_Prop)
            {
                mostrarListaUsuarios();
                caragarListaRoles();
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

        private void PuedeEditar()
        {
            foreach(GridViewRow item in grdUsuarios.Rows)
            {
                ((ImageButton)item.FindControl("btn_editar")).Visible = true;
            }
        }

        private void PuedeEliminar()
        {
            foreach (GridViewRow item in grdUsuarios.Rows)
            {
                ((ImageButton)item.FindControl("btn_borrar")).Visible = true;
            }
        }

        private void PuedeAgregar()
        {
            btn_abrir_panel_nuevo_usuario.Visible = true;
        }

        /// <summary>
        /// Muestra un Alert con un mensaje
        /// </summary>
        /// <param name="pMensaje"></param>
        public void Mensaje(string pMensaje)
        {
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String csConsole = "console.log('" + pMensaje + "')";
                String cstext = "alert('" + pMensaje + "')";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                cs.RegisterStartupScript(cstype, "PopupScript", csConsole, true);
            }
        }
        /// <summary>
        /// Al ser llamado registra una persona con los datos en los texbox
        /// </summary>
        public void RegistrarPersona()
        {
            blUsuario lg_persona = new blUsuario();
            clsUsuario dt_persona = new clsUsuario();
            string vError = null;

            formulario_persona.Visible = false;
            btn_abrir_panel_nuevo_usuario.Visible = true;

            if (txt_contrasena.Text != txt_contrasena2.Text)
            {
                Mensaje("Las contraseñas no coinciden, por favor verifique");
            }
            else
            {
                dt_persona.dni_persona_Prop = txt_dni.Text;
                dt_persona.id_rol_Prop = Convert.ToInt32(ddl_roles.SelectedValue);
                dt_persona.nombre1_Prop = txt_nombre1.Text;
                dt_persona.nombre2_Prop = txt_nombre2.Text;
                dt_persona.apellido1_Prop = txt_apellido1.Text;
                dt_persona.apellido2_Prop = txt_apellido2.Text;
                dt_persona.correo_Prop = txt_correo.Text;
                dt_persona.fecha_nac_Prop = Convert.ToDateTime(txt_fecha_nac.Text);
                dt_persona.telefono_Prop = txt_telefono.Text;
                dt_persona.usuario_Prop = txt_usuario.Text;
                dt_persona.contrasena_Prop = txt_contrasena.Text;


                lg_persona.GuardarPersona(dt_persona, ref vError);

                if (vError == null)
                {
                    lb_mensaje.Visible = true;
                    lb_mensaje.CssClass = "green-text";
                    lb_mensaje.Text = "Persona registrada con exito";
                    mostrarListaUsuarios();
                    ConsultarPermisosPagina();
                }
                else
                {
                    lb_mensaje.Visible = true;
                    lb_mensaje.CssClass = "red-text";
                    lb_mensaje.Text = "Error al registrar la Persona";
                }
            }
        }
        /// <summary>
        /// Al se llamado elimina una persona de la tabla
        /// </summary>
        /// <param name="dni_to_delete"></param>
        public void EliminarPersona(String dni_to_delete)
        {
            blUsuario lg_persona = new blUsuario();
            string vError = null;

            formulario_persona.Visible = false;
            btn_abrir_panel_nuevo_usuario.Visible = true;

            lg_persona.EliminarPersona(dni_to_delete, ref vError);

            if (vError == null)
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "green-text";
                lb_mensaje.Text = "Persona eliminada con exito";
                mostrarListaUsuarios();
                ConsultarPermisosPagina();
            }
            else
            {
                lb_mensaje.Visible = true;
                lb_mensaje.CssClass = "red-text";
                lb_mensaje.Text = "Error al eliminar la Persona";
            }
        }
        /// <summary>
        /// Cada vez que se llama actualiza la tabla de la vista de usuarios 
        /// </summary>
        public void mostrarListaUsuarios()
        {
            blUsuario lg_persona = new blUsuario();

            string vError = null;

            List<clsUsuario> lista = lg_persona.CosultarUsuarios(ref vError);

            if (vError == null)
            {
                grdUsuarios.DataSource = lista;
                grdUsuarios.DataBind();
            }
        }
        /// <summary>
        /// Con esta funciona cargamos el dropdown de la lista de roles
        /// </summary>
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
        /// <summary>
        /// Con esta funcion actualizamos un usuario en la base de datos tomando los valores nuevamente de los texbox 
        /// </summary>
        private void ActualizarUsuario()
        {
            blUsuario lg_persona = new blUsuario();
            clsUsuario dt_persona = new clsUsuario();
            string vError = null;

            formulario_persona.Visible = false;
            btn_abrir_panel_nuevo_usuario.Visible = true;

            if (txt_contrasena.Text != txt_contrasena2.Text)
            {
                Mensaje("Las contraseñas no coinciden, por favor verifique");
            }
            else
            {
                dt_persona.dni_persona_Prop = txt_dni.Text;
                dt_persona.id_rol_Prop = Convert.ToInt32(ddl_roles.SelectedValue);
                dt_persona.nombre1_Prop = txt_nombre1.Text;
                dt_persona.nombre2_Prop = txt_nombre2.Text;
                dt_persona.apellido1_Prop = txt_apellido1.Text;
                dt_persona.apellido2_Prop = txt_apellido2.Text;
                dt_persona.correo_Prop = txt_correo.Text;
                dt_persona.fecha_nac_Prop = Convert.ToDateTime(txt_fecha_nac.Text);
                dt_persona.telefono_Prop = txt_telefono.Text;
                dt_persona.usuario_Prop = txt_usuario.Text;
                dt_persona.contrasena_Prop = txt_contrasena.Text;


                lg_persona.ActualizarPersona(dt_persona, ref vError);

                if (vError == null)
                {
                    lb_mensaje.Visible = true;
                    lb_mensaje.CssClass = "green-text";
                    lb_mensaje.Text = "Persona actualizada con exito";
                    mostrarListaUsuarios();
                    ConsultarPermisosPagina();
                }
                else
                {
                    lb_mensaje.Visible = true;
                    lb_mensaje.CssClass = "red-text";
                    lb_mensaje.Text = "Error al actualizar la Persona";
                }

                LimpiarDatos();
            }
        }

        private void LimpiarDatos()
        {
            txt_dni.Enabled = true;
            txt_dni.Text = null;
            ddl_roles.SelectedValue = null;
            txt_nombre1.Text = null;
            txt_nombre2.Text = null;
            txt_apellido1.Text = null;
            txt_apellido2.Text = null;
            txt_correo.Text = null;
            txt_fecha_nac.Text = null;
            txt_telefono.Text = null;
            txt_usuario.Text = null;
            txt_contrasena.Text = null;
            txt_contrasena2.Text = null;

            btn_guardar_persona.CommandName = null;
            btn_guardar_persona.Text = "Guardar Usuario";
        }

        private Boolean camposLlenos()
        {
            Regex regex = new Regex("^[0-9]*$");
            if (!regex.IsMatch(txt_dni.Text) || txt_dni.Text.Length != 9)
            {
                Mensaje("El DNI solo puede contener números y deben ser 9");
                return false;
            }
            if (string.IsNullOrEmpty(txt_nombre1.Text) || string.IsNullOrEmpty(txt_nombre1.Text) || string.IsNullOrEmpty(txt_nombre1.Text) || string.IsNullOrEmpty(txt_nombre1.Text))
            {
                Mensaje("Los campos de nombre y apellidos deben ir llenos");
                return false;
            }
            if (string.IsNullOrEmpty(txt_contrasena.Text) || string.IsNullOrEmpty(txt_contrasena2.Text))
            {
                Mensaje("La contraseña No puede estar vacia");
                return false;
            }
            if (string.IsNullOrEmpty(txt_usuario.Text))
            {
                Mensaje("Debe seleccionar un nombre de usuario");
                return false;
            }
            if (string.IsNullOrEmpty(txt_correo.Text))
            {
                Mensaje("Debe agregar un correo electronico valido");
                return false;
            }
            if (string.IsNullOrEmpty(txt_telefono.Text))
            {
                Mensaje("Debe agregar un numero telefónico");
                return false;
            }
            return true;
        }
        #endregion
    }
}