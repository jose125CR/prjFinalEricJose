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
    public class blFacturaFinal
    {
        public clsFacturaFinal CosultarFacturaFinal(int id_ticket, ref string pError)
        {
            clsFacturaFinal factura_final = new clsFacturaFinal();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_ticket_final";

                cmd.Parameters.Add("@ppaId_ticket", SqlDbType.Int);
                cmd.Parameters["@ppaId_ticket"].Value = id_ticket;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["id_ticket"].ToString()))
                    {
                        factura_final.id_ticket_Prop = Convert.ToInt32(dr["id_ticket"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["dia_hora_compra"].ToString()))
                    {
                        factura_final.dia_hora_compra_Prop = dr["dia_hora_compra"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_pelicula"].ToString()))
                    {
                        factura_final.nombre_pelicula_Prop = dr["nombre_pelicula"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["categoria_edad"].ToString()))
                    {
                        factura_final.categoria_edad_Prop = dr["categoria_edad"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["dni_persona"].ToString()))
                    {
                        factura_final.dni_persona_Prop = dr["dni_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_completo_persona"].ToString()))
                    {
                        factura_final.nombre_completo_persona_Prop = dr["nombre_completo_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contador_butacas_general"].ToString()))
                    {
                        factura_final.contador_butacas_general_Prop = dr["contador_butacas_general"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contador_butacas_ninos"].ToString()))
                    {
                        factura_final.contador_butacas_ninos_Prop = dr["contador_butacas_ninos"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["contador_butacas_adultos"].ToString()))
                    {
                        factura_final.contador_butacas_adultos_Prop = dr["contador_butacas_adultos"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["butacas_ordenadas"].ToString()))
                    {
                        factura_final.butacas_ordenadas_Prop = dr["butacas_ordenadas"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["sala"].ToString()))
                    {
                        factura_final.sala_Prop = dr["sala"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["hora_pelicula"].ToString()))
                    {
                        factura_final.hora_pelicula_Prop = dr["hora_pelicula"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["cantidad_total_butacas"].ToString()))
                    {
                        factura_final.cantidad_total_butacas_Prop = dr["cantidad_total_butacas"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["puntos_ganados"].ToString()))
                    {
                        factura_final.puntos_acumulados_Prop = dr["puntos_ganados"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["monto_total"].ToString()))
                    {
                        factura_final.monto_total_Prop = float.Parse(dr["monto_total"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarFacturaFinal. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return factura_final;
        }
    }
}