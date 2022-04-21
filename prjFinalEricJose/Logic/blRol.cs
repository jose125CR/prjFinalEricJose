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
    public class blRol
    {
        public List<clsRol> CosultarRoles(ref string pError)
        {
            List<clsRol> lista = new List<clsRol>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_roles";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsRol dt_rol = new clsRol();


                    if (!string.IsNullOrEmpty(dr["id_rol"].ToString()))
                    {
                        dt_rol.id_rol_Prop = Convert.ToInt32(dr["id_rol"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["rol"].ToString()))
                    {
                        dt_rol.rol_Prop = dr["rol"].ToString();
                    }
                    
                    lista.Add(dt_rol);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion pa_consultar_roles. Detalles: " + ex.Message;
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

        public void GuardarRol(String nombre_rol, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_registar_rol";

                cmd.Parameters.Add("@nombre_rol", SqlDbType.VarChar);
                cmd.Parameters["@nombre_rol"].Value = nombre_rol;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion GuardarRol. Detalles: " + ex.Message;
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

        public void EliminarRol(int id_rol_to_delete, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_eliminar_rol";

                cmd.Parameters.Add("@id_rol", SqlDbType.Int);
                cmd.Parameters["@id_rol"].Value = id_rol_to_delete;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion EliminarRol. Detalles: " + ex.Message;
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