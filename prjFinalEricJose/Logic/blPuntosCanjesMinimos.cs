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
    public class blPuntosCanjesMinimos
    {
        public clsPuntosCanjesMinimos CosultarPuntosCangesMinimos(ref string pError)
        {
            clsPuntosCanjesMinimos puntos_canjes = new clsPuntosCanjesMinimos();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_puntos_canges_minimos";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["puntos_minimos"].ToString()))
                    {
                        puntos_canjes.puntos_necesarios_Prop = Convert.ToInt32(dr["puntos_minimos"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["canjes_minimos"].ToString()))
                    {
                        puntos_canjes.canjes_necesarios_Prop = Convert.ToInt32(dr["canjes_minimos"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarPeliculas. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return puntos_canjes;
        }

        public void ActualizarPuntosCanjesMinimos(clsPuntosCanjesMinimos dt_puntos_canjes, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_actualizar_puntos_canges_minimos";

                cmd.Parameters.Add("@puntos", SqlDbType.Int);
                cmd.Parameters["@puntos"].Value = dt_puntos_canjes.puntos_necesarios_Prop;

                cmd.Parameters.Add("@canjes", SqlDbType.Int);
                cmd.Parameters["@canjes"].Value = dt_puntos_canjes.canjes_necesarios_Prop;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ActualizarPuntosCanjesMinimos. Detalles: " + ex.Message;
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