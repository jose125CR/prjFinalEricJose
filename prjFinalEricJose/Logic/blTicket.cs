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
    public class blTicket
    {
        public int ConseguirNuevoIdTicket(ref string pError)
        {
            int new_id = 0;

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_conseguir_nuevo_id_ticket";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!string.IsNullOrEmpty(dr["nuevo_id_ticket"].ToString()))
                    {
                        new_id = Convert.ToInt32(dr["nuevo_id_ticket"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConseguirNuevoIdTicket. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return new_id;
        }

        public void Guardarticket(clsTicket dt_ticket, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_registrar_ticket";

                cmd.Parameters.Add("@ppaId_ticket", SqlDbType.Int);
                cmd.Parameters["@ppaId_ticket"].Value = dt_ticket.id_ticket_Prop;

                cmd.Parameters.Add("@ppaDni_persona", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni_persona"].Value = dt_ticket.dni_persona_prop;

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = dt_ticket.id_pelicula_Prop;

                cmd.Parameters.Add("@ppaId_sala_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala_pelicula"].Value = dt_ticket.id_sala_pelicula_prop;

                cmd.Parameters.Add("@ppaId_horario_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario_pelicula"].Value = dt_ticket.id_horario_pelicula_prop;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion Guardarticket. Detalles: " + ex.Message;
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

        public int ReclamarPromo2D(string dni_usuario, int id_pelicula, int id_sala, int id_horario, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            int num = -502;

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_reclamar_canjeo_2d";

                cmd.Parameters.Add("@ppaDni_persona", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni_persona"].Value = dni_usuario;

                cmd.Parameters.Add("@id_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@id_sala_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_sala_pelicula"].Value = id_sala;

                cmd.Parameters.Add("@id_horario_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_horario_pelicula"].Value = id_horario;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!string.IsNullOrEmpty(dr["numero_regresar"].ToString()))
                    {
                        num = Convert.ToInt32(dr["numero_regresar"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ReclamarPromo2D. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return num;
        }

        public int ReclamarPromoIMAX(string dni_usuario, int id_pelicula, int id_sala, int id_horario, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            int num = -502;

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_reclamar_canjeo_imax";

                cmd.Parameters.Add("@ppaDni_persona", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni_persona"].Value = dni_usuario;

                cmd.Parameters.Add("@id_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@id_sala_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_sala_pelicula"].Value = id_sala;

                cmd.Parameters.Add("@id_horario_pelicula", SqlDbType.Int);
                cmd.Parameters["@id_horario_pelicula"].Value = id_horario;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!string.IsNullOrEmpty(dr["numero_regresar"].ToString()))
                    {
                        num = Convert.ToInt32(dr["numero_regresar"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ReclamarPromoIMAX. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return num;
        }

    }
}