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
    public class blPerfil
    {
        public clsPerfil CosultarUsuarioPerfil(string dni_persona, ref string pError)
        {
            clsPerfil perfil_usuario = new clsPerfil();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_perfil";

                cmd.Parameters.Add("@dni_persona", SqlDbType.VarChar);
                cmd.Parameters["@dni_persona"].Value = dni_persona;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["nombre_completo"].ToString()))
                    {
                        perfil_usuario.nombre_completo_Prop = dr["nombre_completo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["rol"].ToString()))
                    {
                        perfil_usuario.rol_Prop = dr["rol"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["correo"].ToString()))
                    {
                        perfil_usuario.correo_Prop = dr["correo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_nac"].ToString()))
                    {
                        perfil_usuario.fecha_nac_Prop = dr["fecha_nac"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["telefono"].ToString()))
                    {
                        perfil_usuario.telefono_Prop = dr["telefono"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_registro"].ToString()))
                    {
                        perfil_usuario.fecha_registro_Prop = dr["fecha_registro"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["puntos"].ToString()))
                    {
                        perfil_usuario.puntos_Prop = dr["puntos"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["canjeos"].ToString()))
                    {
                        perfil_usuario.canjes_Prop = dr["canjeos"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["puntos_necesarios"].ToString()))
                    {
                        perfil_usuario.puntos_necesarios_Prop = dr["puntos_necesarios"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["canjes_necesarios"].ToString()))
                    {
                        perfil_usuario.canjes_necesarios_Prop = dr["canjes_necesarios"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarUsuarioPerfil. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return perfil_usuario;
        }
    }
}