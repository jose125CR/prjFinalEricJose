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
    public class blCategoriaEdad
    {
        public List<clsCategoriaEdad> CosultarListaCategoriaEdades(ref string pError)
        {
            List<clsCategoriaEdad> lista_categoria_edades = new List<clsCategoriaEdad>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_categorias_edades";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsCategoriaEdad dt_categoria_edad = new clsCategoriaEdad();

                    if (!string.IsNullOrEmpty(dr["id_categoria_edad_pelicula"].ToString()))
                    {
                        dt_categoria_edad.id_categoria_edad_pelicula_Prop = Convert.ToInt32(dr["id_categoria_edad_pelicula"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["categoria_edad"].ToString()))
                    {
                        dt_categoria_edad.categoria_edad_prop = dr["categoria_edad"].ToString();
                    }

                    lista_categoria_edades.Add(dt_categoria_edad);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaCategoriaEdades. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_categoria_edades;
        }

    }
}