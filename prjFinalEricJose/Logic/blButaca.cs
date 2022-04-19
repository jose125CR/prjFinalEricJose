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
    public class blButaca
    {
        public void RegistrarButacasHorarioSalaPelicula(List<clsHorario> horarios_pelicula, List<clsSalaPelicula> salas_pelicula, int id_pelicula, ref string pError)
        {
            foreach (clsSalaPelicula sp in salas_pelicula)
            {
                foreach (clsHorario hp in horarios_pelicula)
                {
                    clsConnection conexion = new clsConnection();
                    SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
                    SqlCommand cmd = new SqlCommand();

                    int vRespuesta;

                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pa_registrar_butacas_pelicula";

                        cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                        cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                        cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                        cmd.Parameters["@ppaId_horario"].Value = hp.id_horario_Prop;

                        cmd.Parameters.Add("@id_sala", SqlDbType.Int);
                        cmd.Parameters["@id_sala"].Value = sp.id_sala_cartelera_Prop;

                        cmd.Connection = conn;
                        conn.Open();

                        vRespuesta = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message, "RegistrarHorariosPorIdPelicula");
                        pError = "Error general en la funcion RegistrarButacasHorarioSalaPelicula. Detalles: " + ex.Message;
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

        public List<clsButaca> ConsultarButacasHorarioSalaPelicula(int id_pelicula, int id_horario, int id_sala, ref string pError)
        {
            List<clsButaca> lista_butacas_pelicula = new List<clsButaca>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_butacas_sala_horario_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario"].Value = id_horario;

                cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala"].Value = id_sala;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsButaca dt_butaca = new clsButaca();

                    if (!string.IsNullOrEmpty(dr["id_butaca"].ToString()))
                    {
                        dt_butaca.id_butaca_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        dt_butaca.id_pelicula_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_horario"].ToString()))
                    {
                        dt_butaca.id_horario_Prop = Convert.ToInt32(dr["id_horario"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_sala"].ToString()))
                    {
                        dt_butaca.id_sala_Prop = Convert.ToInt32(dr["id_sala"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_categoria_persona"].ToString()))
                    {
                        dt_butaca.id_categoria_persona_Prop = Convert.ToInt32(dr["id_categoria_persona"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["identificador"].ToString()))
                    {
                        dt_butaca.identificador_Prop = dr["identificador"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["estado"].ToString()))
                    {
                        dt_butaca.estado_Prop = dr["estado"].ToString();
                    }

                    lista_butacas_pelicula.Add(dt_butaca);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarButacasHorarioSalaPelicula. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_butacas_pelicula;
        }


        public List<clsButaca> ConsultarButacasHorarioSalaPeliculaSeleccionadas(int id_pelicula, int id_horario, int id_sala, ref string pError)
        {
            List<clsButaca> lista_butacas_pelicula = new List<clsButaca>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_butacas_sala_horario_pelicula_seleccionadas";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario"].Value = id_horario;

                cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala"].Value = id_sala;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsButaca dt_butaca = new clsButaca();

                    if (!string.IsNullOrEmpty(dr["id_butaca"].ToString()))
                    {
                        dt_butaca.id_butaca_Prop = Convert.ToInt32(dr["id_butaca"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        dt_butaca.id_pelicula_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_horario"].ToString()))
                    {
                        dt_butaca.id_horario_Prop = Convert.ToInt32(dr["id_horario"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_sala"].ToString()))
                    {
                        dt_butaca.id_sala_Prop = Convert.ToInt32(dr["id_sala"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_categoria_persona"].ToString()))
                    {
                        dt_butaca.id_categoria_persona_Prop = Convert.ToInt32(dr["id_categoria_persona"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["identificador"].ToString()))
                    {
                        dt_butaca.identificador_Prop = dr["identificador"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["estado"].ToString()))
                    {
                        dt_butaca.estado_Prop = dr["estado"].ToString();
                    }

                    lista_butacas_pelicula.Add(dt_butaca);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarButacasHorarioSalaPeliculaSeleccionadas. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_butacas_pelicula;
        }


        public clsButaca ConsultarUnaButaca(
            int id_pelicula, int id_horario, int id_sala,
            string identificador, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_unica_butaca";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario"].Value = id_horario;

                cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala"].Value = id_sala;

                cmd.Parameters.Add("@ppaIdentificador", SqlDbType.VarChar);
                cmd.Parameters["@ppaIdentificador"].Value = identificador;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsButaca dt_butaca = new clsButaca();

                    if (!string.IsNullOrEmpty(dr["id_butaca"].ToString()))
                    {
                        dt_butaca.id_butaca_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        dt_butaca.id_pelicula_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_horario"].ToString()))
                    {
                        dt_butaca.id_horario_Prop = Convert.ToInt32(dr["id_horario"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_sala"].ToString()))
                    {
                        dt_butaca.id_sala_Prop = Convert.ToInt32(dr["id_sala"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_categoria_persona"].ToString()))
                    {
                        dt_butaca.id_categoria_persona_Prop = Convert.ToInt32(dr["id_categoria_persona"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["identificador"].ToString()))
                    {
                        dt_butaca.identificador_Prop = dr["identificador"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["estado"].ToString()))
                    {
                        dt_butaca.estado_Prop = dr["estado"].ToString();
                    }

                    return dt_butaca;
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarButacasHorarioSalaPelicula. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return null;
        }

        public void ActualizarButaca(
            int id_pelicula, int id_horario, int id_sala, int id_categoria_persona, 
            string identificador, string estado, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;
            
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_actualizar_butacas_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Parameters.Add("@ppaId_horario", SqlDbType.Int);
                cmd.Parameters["@ppaId_horario"].Value = id_horario;

                cmd.Parameters.Add("@id_sala", SqlDbType.Int);
                cmd.Parameters["@id_sala"].Value = id_sala;

                cmd.Parameters.Add("@ppaId_categoria_persona", SqlDbType.Int);
                cmd.Parameters["@ppaId_categoria_persona"].Value = id_categoria_persona;

                cmd.Parameters.Add("@ppaIdentificador", SqlDbType.VarChar);
                cmd.Parameters["@ppaIdentificador"].Value = identificador;

                cmd.Parameters.Add("@ppaEstado", SqlDbType.VarChar);
                cmd.Parameters["@ppaEstado"].Value = estado;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarButacasHorarioSalaPelicula. Detalles: " + ex.Message;
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

        public float ConsultarPrecioButaca(int id_sala, int id_dia, int id_c_persona, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            float precio = 0;
            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_precio_butaca";

                cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                cmd.Parameters["@ppaId_sala"].Value = id_sala;

                cmd.Parameters.Add("@ppaId_dia", SqlDbType.Int);
                cmd.Parameters["@ppaId_dia"].Value = id_dia;

                cmd.Parameters.Add("@ppaId_categoria_persona", SqlDbType.Int);
                cmd.Parameters["@ppaId_categoria_persona"].Value = id_c_persona;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!string.IsNullOrEmpty(dr["precio_butaca"].ToString()))
                    {
                        precio = float.Parse(dr["precio_butaca"].ToString());
                    }
                    else
                    {
                        precio = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ConsultarPrecioButaca. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }
            return precio;
        }
    }
}