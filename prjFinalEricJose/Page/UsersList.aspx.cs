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
    public partial class UsersList : System.Web.UI.Page
    {
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
        public void RegistrarPersona()
        {
            blUsuario lg_persona = new blUsuario();
            clsUsuario dt_persona = new clsUsuario();
            string vError = null;

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
                    Mensaje("Persona registrada con exito");
                    mostrarListaUsuarios();
                }
                else
                {
                    Mensaje("Error al registrar la Persona");
                }
            }
        }

        public void ElimiarPersona(String dni_to_delete)
        {
            blUsuario lg_persona = new blUsuario();
            string vError = null;


            lg_persona.EliminarPersona(dni_to_delete, ref vError);

            if (vError == null)
            {
                Mensaje("Persona eliminada con exito");
                mostrarListaUsuarios();
            }
            else
            {
                Mensaje("Error al eliminar la Persona");
            }
        }

        public void mostrarListaUsuarios()
        {
            blUsuario lg_persona = new blUsuario();
            //clsUsuario vUsario = new clsUsuario();
            string vError = null;

            List<clsUsuario> lista = new List<clsUsuario>();

            lista = lg_persona.CosultarUsuarios(ref vError);

            if (vError == null)
            {
                grdUsuarios.DataSource = lista;
                grdUsuarios.DataBind();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mostrarListaUsuarios();
                caragarListaRoles();
                //formulario_persona.Visible = false;
            }
        }

        protected void btn_guardar_persona_Click(object sender, EventArgs e)
        {
            RegistrarPersona();
        }

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdUsuarios.Rows[e.RowIndex];
            string dni_to_delete = row.Cells[0].Text;

            ElimiarPersona(dni_to_delete);
        }

        protected void grdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            blUsuario lg_persona = new blUsuario();
            GridViewRow row = grdUsuarios.Rows[e.RowIndex];
            string dni_to_edit = row.Cells[0].Text;
            string vError = null;

            List<clsUsuario> lista = lg_persona.CosultarUsuarios(ref vError);

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
                txt_fecha_nac.Text = dt_persona.fecha_nac_Prop.ToString();
                txt_telefono.Text = dt_persona.telefono_Prop;
                txt_usuario.Text = dt_persona.usuario_Prop;
                txt_contrasena.Text = dt_persona.contrasena_Prop;
            }
            else
            {
                Mensaje("Error al cargar los datos de editar");
            }
        }
    }
}