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
    public class blModulo
    {
        public List<clsModulo> CosultarModulos(ref string pError)
        {
            List<clsModulo> lista = new List<clsModulo>();

            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_modulos";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsModulo dt_modulo = new clsModulo();


                    if (!string.IsNullOrEmpty(dr["id_pagina"].ToString()))
                    {
                        dt_modulo.id_pagina_Prop = Convert.ToInt32(dr["id_pagina"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_pagina"].ToString()))
                    {
                        dt_modulo.nombre_pagina_Prop = dr["nombre_pagina"].ToString();
                    }

                    lista.Add(dt_modulo);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarModulos. Detalles: " + ex.Message;
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