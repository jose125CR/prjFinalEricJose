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
    public class blHorario
    {
        public List<clsHorario> CosultarListaHorarios(ref string pError)
        {
            List<clsHorario> lista_horarios = new List<clsHorario>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_lista_horarios";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsHorario dt_horario = new clsHorario();

                    if (!string.IsNullOrEmpty(dr["id_horario"].ToString()))
                    {
                        dt_horario.id_horario_Prop = Convert.ToInt32(dr["id_horario"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["horario"].ToString()))
                    {
                        TimeSpan time = TimeSpan.Parse(dr["horario"].ToString());
                        dt_horario.horario_Prop = time.ToString(@"hh\:mm");
                    }

                    lista_horarios.Add(dt_horario);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaHorarios. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_horarios;
        }

        public List<clsHorario> CosultarHorariosPorIdPelicula(int id_cartelera, ref string pError)
        {
            List<clsHorario> lista_horarios = new List<clsHorario>();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_horarios_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_cartelera;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsHorario dt_horario = new clsHorario();

                    if (!string.IsNullOrEmpty(dr["id_horario_pelicula"].ToString()))
                    {
                        dt_horario.id_horario_Prop = Convert.ToInt32(dr["id_horario_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["horario"].ToString()))
                    {
                        TimeSpan time = TimeSpan.Parse(dr["horario"].ToString());
                        dt_horario.horario_Prop = time.ToString(@"hh\:mm");
                    }

                    lista_horarios.Add(dt_horario);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarHorariosPorIdPelicula. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_horarios;
        }
    }
}