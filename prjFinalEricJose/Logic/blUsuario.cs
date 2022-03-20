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
                cmd.CommandText = "spConsultarUsuarios";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                //System.Diagnostics.Debug.WriteLine(conexion.ObtenerCadenaConexion(), "Qry");
                //System.Diagnostics.Debug.WriteLine(dr.Read(), "Registro");
                while (dr.Read())
                {
                    //System.Diagnostics.Debug.WriteLine("Hola5");
                    clsUsuario vUsuario = new clsUsuario();

                    if (!string.IsNullOrEmpty(dr["dni"].ToString()))
                    {
                        vUsuario.dni_Prop = Convert.ToInt32(dr["dni"].ToString());
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
                    if (!string.IsNullOrEmpty(dr["usuario"].ToString()))
                    {
                        vUsuario.usuario_Prop = dr["usuario"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contrasena"].ToString()))
                    {
                        vUsuario.contrasena_Prop = dr["contrasena"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["role"].ToString()))
                    {
                        vUsuario.role_Prop = dr["role"].ToString();
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
    }
}