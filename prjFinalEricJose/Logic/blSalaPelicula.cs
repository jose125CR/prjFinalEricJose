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
    public class blSalaPelicula
    {
        public List<clsSalaPelicula> CosultarSalasPorIdPelicula(int id_pelicula, ref string pError)
        {
            List<clsSalaPelicula> lista_Salas_pelicula = new List<clsSalaPelicula>();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_salas_pelicula";

                cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsSalaPelicula dt_sala_pelicula = new clsSalaPelicula();

                    if (!string.IsNullOrEmpty(dr["id_sala_pelicula"].ToString()))
                    {
                        dt_sala_pelicula.id_sala_cartelera_Prop = Convert.ToInt32(dr["id_sala_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_tipo_sala"].ToString()))
                    {
                        dt_sala_pelicula.nombre_tipo_sala_Prop = dr["nombre_tipo_sala"].ToString();
                    }

                    lista_Salas_pelicula.Add(dt_sala_pelicula);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarSalassPorIdCartelera. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_Salas_pelicula;
        }

        public void RegistrarSalasPorIdPelicula(List<clsSalaPelicula> salas_pelicula, int id_pelicula, ref string pError)
        {
            foreach (clsSalaPelicula sp in salas_pelicula)
            {
                clsConnection conexion = new clsConnection();
                SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
                SqlCommand cmd = new SqlCommand();

                int vRespuesta;

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pa_registrar_salas_pelicula";

                    cmd.Parameters.Add("@ppaId_pelicula", SqlDbType.Int);
                    cmd.Parameters["@ppaId_pelicula"].Value = id_pelicula;

                    cmd.Parameters.Add("@ppaId_sala", SqlDbType.Int);
                    cmd.Parameters["@ppaId_sala"].Value = sp.id_sala_cartelera_Prop;

                    cmd.Connection = conn;
                    conn.Open();

                    vRespuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, "RegistrarSalassPorIdPelicula");
                    pError = "Error general en la funcion RegistrarSalassPorIdPelicula. Detalles: " + ex.Message;
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
}