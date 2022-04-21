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
    public class blDiaSemana
    {
        public List<clsDiaSemana> CosultarListaDiasSemana(ref string pError)
        {
            List<clsDiaSemana> lista_dias_semana = new List<clsDiaSemana>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_dias_semana";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsDiaSemana dt_dia_semana = new clsDiaSemana();

                    if (!string.IsNullOrEmpty(dr["id_dia"].ToString()))
                    {
                        dt_dia_semana.id_dia_Prop = Convert.ToInt32(dr["id_dia"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_dia"].ToString()))
                    {
                        dt_dia_semana.nombre_dia_Prop = dr["nombre_dia"].ToString();
                    }

                    lista_dias_semana.Add(dt_dia_semana);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaDiasSemana. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_dias_semana;
        }
    }
}