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
    public class blPelicula
    {
        public List<clsPelicula> CosultarPeliculas(ref string pError)
        {
            blHorario lg_horario = new blHorario();
            blSalaPelicula lg_sala_pelicula = new blSalaPelicula();
            blDiaSemana lg_dia_pelicula = new blDiaSemana();

            List<clsPelicula> lista_peliculas = new List<clsPelicula>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_peliculas";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                List<clsDiaSemana> dt_dias_semana = lg_dia_pelicula.CosultarListaDiasSemana(ref pError);
                while (dr.Read())
                {
                    clsPelicula dt_pelicula = new clsPelicula();

                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        dt_pelicula.id_pelicula_Prop = Convert.ToInt32(dr["id_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_categoria_edad_pelicula"].ToString()))
                    {
                        dt_pelicula.id_categoria_edad_pelicula_Prop = Convert.ToInt32(dr["id_categoria_edad_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_pelicula"].ToString()))
                    {
                        dt_pelicula.nombre_pelicula_Prop = dr["nombre_pelicula"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["direccion_img"].ToString()))
                    {
                        dt_pelicula.direccion_img_prop = dr["direccion_img"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["sinopsis"].ToString()))
                    {
                        dt_pelicula.sinopsis_Prop = dr["sinopsis"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["estado"].ToString()))
                    {
                        dt_pelicula.estado_Prop = dr["estado"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["fecha_estreno"].ToString()))
                    {
                        dt_pelicula.fecha_estreno_Prop = Convert.ToDateTime(dr["fecha_estreno"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        int id_pelicula = Convert.ToInt32(dr["id_pelicula"].ToString());
                        dt_pelicula.horarios_Prop = lg_horario.CosultarHorariosPorIdPelicula(id_pelicula, ref pError);
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        int id_pelicula = Convert.ToInt32(dr["id_pelicula"].ToString());
                        dt_pelicula.salas_Prop = lg_sala_pelicula.CosultarSalasPorIdPelicula(id_pelicula, ref pError);
                    }
                    if (!string.IsNullOrEmpty(dr["id_pelicula"].ToString()))
                    {
                        dt_pelicula.dias_Prop = dt_dias_semana;
                    }

                    lista_peliculas.Add(dt_pelicula);
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

            return lista_peliculas;
        }

        public int ConseguirNuevoIdPelicula(ref string pError)
        {
            int new_id = 0;

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_conseguir_nuevo_id_pelicula";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    if (!string.IsNullOrEmpty(dr["nuevo_id_pelicula"].ToString()))
                    {
                        new_id = Convert.ToInt32(dr["nuevo_id_pelicula"].ToString());
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

            return new_id;
        }

        public void GuardarPelicula(clsPelicula dt_pelicula, ref string pError)
        {
            blHorario lg_horario_pelicula = new blHorario();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;
            int new_id = -1;

            try
            {
                new_id = ConseguirNuevoIdPelicula(ref pError);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_registrar_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = new_id;

                cmd.Parameters.Add("@ppaId_categoria_edad_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_categoria_edad_pelicula"].Value = dt_pelicula.id_categoria_edad_pelicula_Prop;

                cmd.Parameters.Add("@ppaNombre", SqlDbType.VarChar);
                cmd.Parameters["@ppaNombre"].Value = dt_pelicula.nombre_pelicula_Prop;

                cmd.Parameters.Add("@ppaDireccion_img", SqlDbType.VarChar);
                cmd.Parameters["@ppaDireccion_img"].Value = dt_pelicula.direccion_img_prop;

                cmd.Parameters.Add("@ppaSipnosis", SqlDbType.VarChar);
                cmd.Parameters["@ppaSipnosis"].Value = dt_pelicula.sinopsis_Prop;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion GuardarPelicula. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
                if (new_id != -1)
                {
                    lg_horario_pelicula.RegistrarHorariosPorIdPelicula(dt_pelicula.horarios_Prop, dt_pelicula.salas_Prop, new_id, ref pError);
                }
            }
        }

        public void ActualizarPelicula(clsPelicula dt_pelicula, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_actualizar_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = dt_pelicula.id_pelicula_Prop;

                cmd.Parameters.Add("@ppaId_categoria_edad_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_categoria_edad_pelicula"].Value = dt_pelicula.id_categoria_edad_pelicula_Prop;

                cmd.Parameters.Add("@ppaNombre", SqlDbType.VarChar);
                cmd.Parameters["@ppaNombre"].Value = dt_pelicula.nombre_pelicula_Prop;

                cmd.Parameters.Add("@ppaSipnosis", SqlDbType.VarChar);
                cmd.Parameters["@ppaSipnosis"].Value = dt_pelicula.sinopsis_Prop;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ActualizarPelicula. Detalles: " + ex.Message;
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

        public void EliminarPelicula(int id_pelicula, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_deshabilitar_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion EliminarPelicula. Detalles: " + ex.Message;
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