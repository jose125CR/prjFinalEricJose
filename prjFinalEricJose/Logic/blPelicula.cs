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
                        dt_pelicula.salas_Prop = lg_sala_pelicula.CosultarSalassPorIdPelicula(id_pelicula, ref pError);
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
    }
}