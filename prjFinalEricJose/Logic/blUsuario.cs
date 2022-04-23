using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjFinalEricJose.Data;
using prjFinalEricJose.Connection;
using System.Data;
using System.Data.SqlClient;

namespace prjFinalEricJose.Logic
{
    public class blUsuario
    {
        public List<clsUsuario> CosultarUsuarios(ref string pError)
        {
            List<clsUsuario> lista = new List<clsUsuario>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_personas";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                //System.Diagnostics.Debug.WriteLine(conexion.ObtenerCadenaConexion(), "Qry");
                //System.Diagnostics.Debug.WriteLine(dr.Read(), "Registro");
                while (dr.Read())
                {
                    //System.Diagnostics.Debug.WriteLine("Hola5");
                    clsUsuario vUsuario = new clsUsuario();

                    if (!string.IsNullOrEmpty(dr["dni_persona"].ToString()))
                    {
                        vUsuario.dni_persona_Prop = dr["dni_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["id_rol"].ToString()))
                    {
                        vUsuario.id_rol_Prop = Convert.ToInt32(dr["id_rol"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre1"].ToString()))
                    {
                        vUsuario.nombre1_Prop = dr["nombre1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre2"].ToString()))
                    {
                        vUsuario.nombre2_Prop = dr["nombre2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["apellido1"].ToString()))
                    {
                        vUsuario.apellido1_Prop = dr["apellido1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["apellido2"].ToString()))
                    {
                        vUsuario.apellido2_Prop= dr["apellido2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["correo"].ToString()))
                    {
                        vUsuario.correo_Prop = dr["correo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_nac"].ToString()))
                    {
                        vUsuario.fecha_nac_Prop = Convert.ToDateTime(dr["fecha_nac"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["telefono"].ToString()))
                    {
                        vUsuario.telefono_Prop = dr["telefono"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["usuario"].ToString()))
                    {
                        vUsuario.usuario_Prop = dr["usuario"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contrasena"].ToString()))
                    {
                        vUsuario.contrasena_Prop = dr["contrasena"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["puntos"].ToString()))
                    {
                        vUsuario.puntos_Prop = Convert.ToInt32(dr["puntos"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["canjeos"].ToString()))
                    {
                        vUsuario.canjeos_Prop = Convert.ToInt32(dr["canjeos"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_creacion"].ToString()))
                    {
                        vUsuario.fecha_creacion_Prop = Convert.ToDateTime(dr["fecha_creacion"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["preferencial"].ToString()))
                    {
                        vUsuario.preferencial_Prop = Convert.ToBoolean(dr["preferencial"].ToString());
                    }
                    lista.Add(vUsuario);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarMaterias. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista;
        }

        public void GuardarPersona(clsUsuario dt_persona, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_registrar_persona";

                cmd.Parameters.Add("@ppaDni_persona_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni_persona_Prop"].Value = dt_persona.dni_persona_Prop;

                cmd.Parameters.Add("@ppaId_rol_Prop", SqlDbType.Int);
                cmd.Parameters["@ppaId_rol_Prop"].Value = dt_persona.id_rol_Prop;

                cmd.Parameters.Add("@ppaNombre1_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaNombre1_Prop"].Value = dt_persona.nombre1_Prop;

                cmd.Parameters.Add("@ppaNombre2_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaNombre2_Prop"].Value = dt_persona.nombre2_Prop;

                cmd.Parameters.Add("@ppaApellido1_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaApellido1_Prop"].Value = dt_persona.apellido1_Prop;

                cmd.Parameters.Add("@ppaApellido2_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaApellido2_Prop"].Value = dt_persona.apellido2_Prop;

                cmd.Parameters.Add("@ppaCorreo_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaCorreo_Prop"].Value = dt_persona.correo_Prop;

                cmd.Parameters.Add("@ppaFecha_nac_Prop", SqlDbType.DateTime);
                cmd.Parameters["@ppaFecha_nac_Prop"].Value = dt_persona.fecha_nac_Prop;

                cmd.Parameters.Add("@ppaTelefono_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaTelefono_Prop"].Value = dt_persona.telefono_Prop;

                cmd.Parameters.Add("@ppaUsuario_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaUsuario_Prop"].Value = dt_persona.usuario_Prop;

                cmd.Parameters.Add("@ppaContrasena_Prop", SqlDbType.VarChar);
                cmd.Parameters["@ppaContrasena_Prop"].Value = dt_persona.contrasena_Prop;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion guardarPersona. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
        }

        public void EliminarPersona(String dni_to_delete, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminar_persona";

                cmd.Parameters.Add("@ppaDni", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni"].Value = dni_to_delete;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion EliminarPersona. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
        }

        public clsUsuario CosultarLogin(string usuario, string contrasena, ref string pError)
        {
            clsUsuario dt_persona = new clsUsuario();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_ingreso";

                cmd.Parameters.Add("@ppaUsuario", SqlDbType.VarChar);
                cmd.Parameters["@ppaUsuario"].Value = usuario;

                cmd.Parameters.Add("@ppaContrasena", SqlDbType.VarChar);
                cmd.Parameters["@ppaContrasena"].Value = contrasena;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                if (!dr.HasRows) return null;

                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["dni_persona"].ToString()))
                    {
                        dt_persona.dni_persona_Prop = dr["dni_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["id_rol"].ToString()))
                    {
                        dt_persona.id_rol_Prop = Convert.ToInt32(dr["id_rol"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre1"].ToString()))
                    {
                        dt_persona.nombre1_Prop = dr["nombre1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre2"].ToString()))
                    {
                        dt_persona.nombre2_Prop = dr["nombre2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["apellido1"].ToString()))
                    {
                        dt_persona.apellido1_Prop = dr["apellido1"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["apellido2"].ToString()))
                    {
                        dt_persona.apellido2_Prop = dr["apellido2"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["correo"].ToString()))
                    {
                        dt_persona.correo_Prop = dr["correo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_nac"].ToString()))
                    {
                        dt_persona.fecha_nac_Prop = Convert.ToDateTime(dr["fecha_nac"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["telefono"].ToString()))
                    {
                        dt_persona.telefono_Prop = dr["telefono"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["usuario"].ToString()))
                    {
                        dt_persona.usuario_Prop = dr["usuario"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contrasena"].ToString()))
                    {
                        dt_persona.contrasena_Prop = dr["contrasena"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["puntos"].ToString()))
                    {
                        dt_persona.puntos_Prop = Convert.ToInt32(dr["puntos"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["canjeos"].ToString()))
                    {
                        dt_persona.canjeos_Prop = Convert.ToInt32(dr["canjeos"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_creacion"].ToString()))
                    {
                        dt_persona.fecha_creacion_Prop = Convert.ToDateTime(dr["fecha_creacion"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["preferencial"].ToString()))
                    {
                        dt_persona.preferencial_Prop = Convert.ToBoolean(dr["preferencial"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarMaterias. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return dt_persona;
        }


        public void SumarPuntos(string dni_persona, int cantidad_butacas, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_sumar_puntos";

                cmd.Parameters.Add("@dni_persona", SqlDbType.VarChar);
                cmd.Parameters["@dni_persona"].Value = dni_persona;

                cmd.Parameters.Add("@cantidad_butacas", SqlDbType.Int);
                cmd.Parameters["@cantidad_butacas"].Value = cantidad_butacas;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion SumarPuntos. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
        }

    }
}