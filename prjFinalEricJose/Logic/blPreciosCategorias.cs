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
    public class blPreciosCategorias
    {
        public List<clsPreciosCategorias> CosultarPreciosCategorias(ref string pError)
        {
            List<clsPreciosCategorias> lista_precios = new List<clsPreciosCategorias>();

            for (int tipo_sala = 1; tipo_sala <= 3; tipo_sala ++)
            {
                clsConnection conexion = new clsConnection();

                SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

                SqlCommand cmd = new SqlCommand();

                try
                {
                    SqlDataReader dr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pa_consultar_precios_categoria_persona";

                    cmd.Parameters.Add("@id_tipo_sala", SqlDbType.Int);
                    cmd.Parameters["@id_tipo_sala"].Value = tipo_sala;

                    cmd.Connection = conn;

                    conn.Open();

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clsPreciosCategorias precio_categoria = new clsPreciosCategorias();

                        precio_categoria.nombre_sala_prop = NombreTipoSala(tipo_sala);

                        if (!string.IsNullOrEmpty(dr["precio_general"].ToString()))
                        {
                            precio_categoria.precio_general_prop = float.Parse(dr["precio_general"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["precio_nino"].ToString()))
                        {
                            precio_categoria.precio_nino_prop = float.Parse(dr["precio_nino"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["precio_adulto"].ToString()))
                        {
                            precio_categoria.precio_adulto_prop = float.Parse(dr["precio_adulto"].ToString());
                        }

                        lista_precios.Add(precio_categoria);
                    }
                }
                catch (Exception ex)
                {
                    pError = "Error general en la funcion CosultarPreciosCategorias. Detalles: " + ex.Message;
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

            return lista_precios;
        }

        private string NombreTipoSala(int id_tipo_sala)
        {
            if (id_tipo_sala == 2)
            {
                return "3D";
            }
            else if (id_tipo_sala == 3)
            {
                return "IMAX";
            }
            else
            {
                return "2D";
            }
        }

        public void ActualizarPreciosCategorias(List<clsPreciosCategorias> lista_categorias, ref string pError)
        {
            for (int tipo_sala = 1; tipo_sala <= 3; tipo_sala++)
            {
                clsConnection conexion = new clsConnection();
                SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
                SqlCommand cmd = new SqlCommand();

                int vRespuesta;

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pa_actualizar_precios_categoria_persona";

                    cmd.Parameters.Add("@id_tipo_sala", SqlDbType.Int);
                    cmd.Parameters["@id_tipo_sala"].Value = tipo_sala;

                    cmd.Parameters.Add("@general", SqlDbType.Float);
                    cmd.Parameters["@general"].Value = lista_categorias[tipo_sala - 1].precio_general_prop;

                    cmd.Parameters.Add("@ninos", SqlDbType.Float);
                    cmd.Parameters["@ninos"].Value = lista_categorias[tipo_sala - 1].precio_nino_prop;

                    cmd.Parameters.Add("@adultos", SqlDbType.Float);
                    cmd.Parameters["@adultos"].Value = lista_categorias[tipo_sala - 1].precio_adulto_prop;

                    cmd.Connection = conn;
                    conn.Open();
                    vRespuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    pError = "Error general en la funcion ActualizarPreciosCategorias. Detalles: " + ex.Message;
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