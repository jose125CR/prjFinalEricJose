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
    public class blPreciosEntradasSalaDia
    {
        public List<clsPreciosEntradasSalaDia> CosultarPreciosPorSalaDiaHorario(int id_pelicula, int id_horarios, 
            int id_sala, int id_dia,ref string pError)
        {
            List<clsPreciosEntradasSalaDia> lista_precios_sala_dia = new List<clsPreciosEntradasSalaDia>();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_precios_promociones_sala_dia";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario"].Value = id_horarios;

                cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala"].Value = id_sala;

                cmd.Parameters.Add("@ppaId_dia", SqlDbType.Int);
                cmd.Parameters["@ppaId_dia"].Value = id_dia;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsPreciosEntradasSalaDia dt_precio_dia = new clsPreciosEntradasSalaDia();

                    if (!string.IsNullOrEmpty(dr["id_categoria_persona"].ToString()))
                    {
                        dt_precio_dia.id_categoria_persona_Prop = Convert.ToInt32(dr["id_categoria_persona"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["precio_total_categoria"].ToString()))
                    {
                        dt_precio_dia.precio_total_categoria_prop = float.Parse(dr["precio_total_categoria"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_categoria"].ToString()))
                    {
                        dt_precio_dia.nombre_categoria_prop = dr["nombre_categoria"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["cantidad_butacas"].ToString()))
                    {
                        dt_precio_dia.cantidad_butacas_Prop = Convert.ToInt32(dr["cantidad_butacas"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["precio_por_entrada"].ToString()))
                    {
                        dt_precio_dia.precio_por_entrada_prop = float.Parse(dr["precio_por_entrada"].ToString());
                    }

                    lista_precios_sala_dia.Add(dt_precio_dia);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarPreciosPorSalaDiaHorario. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_precios_sala_dia;
        }
    }
}