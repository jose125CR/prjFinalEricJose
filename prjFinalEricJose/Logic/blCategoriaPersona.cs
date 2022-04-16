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
    public class blCategoriaPersona
    {
        public List<clsCategoriaPersona> CosultarListaCategoriaPersonas(ref string pError)
        {
            List<clsCategoriaPersona> lista_categoria_personas = new List<clsCategoriaPersona>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_categorias_personas";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsCategoriaPersona dt_categoria_persona = new clsCategoriaPersona();

                    if (!string.IsNullOrEmpty(dr["id_categoria_persona"].ToString()))
                    {
                        dt_categoria_persona.id_categoria_persona_Prop = Convert.ToInt32(dr["id_categoria_persona"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_categoria"].ToString()))
                    {
                        dt_categoria_persona.nombre_categoria_prop = dr["nombre_categoria"].ToString();
                    }

                    lista_categoria_personas.Add(dt_categoria_persona);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaCategoriaPersonas. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_categoria_personas;
        }
    }
}