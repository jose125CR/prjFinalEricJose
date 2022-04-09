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
            List<clsPelicula> lista = new List<clsPelicula>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spConsultarPeliculas";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsPelicula vPelicula = new clsPelicula();

                    if (!string.IsNullOrEmpty(dr["id"].ToString()))
                    {
                        vPelicula.id_Prop = Convert.ToInt32(dr["id"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre"].ToString()))
                    {
                        vPelicula.nombre_Prop = dr["nombre"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["sipnosis"].ToString()))
                    {
                        vPelicula.sipnosis_Prop = dr["sipnosis"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["img_url"].ToString()))
                    {
                        vPelicula.img_url_Prop = dr["img_url"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["year"].ToString()))
                    {
                        vPelicula.year_Prop = dr["year"].ToString();
                    }

                    lista.Add(vPelicula);
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

            return lista;
        }
    }
}