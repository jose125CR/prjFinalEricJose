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
    public class blSemanaPromocion
    {
        public List<clsSemanaPromicion> CosultarPromociones(ref string pError)
        {
            List<clsSemanaPromicion> lista_promociones = new List<clsSemanaPromicion>();

            for(int tipo_sala = 1; tipo_sala <= 3; tipo_sala ++)
            {
                clsConnection conexion = new clsConnection();

                SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

                SqlCommand cmd = new SqlCommand();

                try
                {
                    SqlDataReader dr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pa_consultar_promociones_dia";

                    cmd.Parameters.Add("@id_tipo_sala", SqlDbType.Int);
                    cmd.Parameters["@id_tipo_sala"].Value = tipo_sala;

                    cmd.Connection = conn;

                    conn.Open();

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clsSemanaPromicion semana_promocion = new clsSemanaPromicion();

                        semana_promocion.nombre_sala_prop = NombreTipoSala(tipo_sala);

                        if (!string.IsNullOrEmpty(dr["dia_domingo"].ToString()))
                        {
                            semana_promocion.dia_domingo_prop = float.Parse(dr["dia_domingo"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_lunes"].ToString()))
                        {
                            semana_promocion.dia_lunes_prop = float.Parse(dr["dia_lunes"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_martes"].ToString()))
                        {
                            semana_promocion.dia_martes_prop = float.Parse(dr["dia_martes"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_miercoles"].ToString()))
                        {
                            semana_promocion.dia_miercoles_prop = float.Parse(dr["dia_miercoles"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_jueves"].ToString()))
                        {
                            semana_promocion.dia_jueves_prop = float.Parse(dr["dia_jueves"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_viernes"].ToString()))
                        {
                            semana_promocion.dia_viernes_prop = float.Parse(dr["dia_viernes"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dr["dia_sabado"].ToString()))
                        {
                            semana_promocion.dia_sabado_prop = float.Parse(dr["dia_sabado"].ToString());
                        }

                        lista_promociones.Add(semana_promocion);
                    }
                }
                catch (Exception ex)
                {
                    pError = "Error general en la funcion CosultarUsuarioPerfil. Detalles: " + ex.Message;
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

            return lista_promociones;
        }

        private string NombreTipoSala(int id_tipo_sala)
        {
            if(id_tipo_sala == 2)
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

        public void ActualizarPromociones(List<clsSemanaPromicion> lista_promociones, ref string pError)
        {
            for (int tipo_sala = 1; tipo_sala <= 3; tipo_sala ++)
            {
                clsConnection conexion = new clsConnection();
                SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
                SqlCommand cmd = new SqlCommand();

                int vRespuesta;

                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pa_actualizar_promociones_dia";

                    cmd.Parameters.Add("@id_tipo_sala", SqlDbType.Int);
                    cmd.Parameters["@id_tipo_sala"].Value = tipo_sala;

                    cmd.Parameters.Add("@domingo", SqlDbType.Float);
                    cmd.Parameters["@domingo"].Value = lista_promociones[tipo_sala - 1].dia_domingo_prop;

                    cmd.Parameters.Add("@lunes", SqlDbType.Float);
                    cmd.Parameters["@lunes"].Value = lista_promociones[tipo_sala - 1].dia_lunes_prop;

                    cmd.Parameters.Add("@martes", SqlDbType.Float);
                    cmd.Parameters["@martes"].Value = lista_promociones[tipo_sala - 1].dia_martes_prop;

                    cmd.Parameters.Add("@miercoles", SqlDbType.Float);
                    cmd.Parameters["@miercoles"].Value = lista_promociones[tipo_sala - 1].dia_miercoles_prop;

                    cmd.Parameters.Add("@jueves", SqlDbType.Float);
                    cmd.Parameters["@jueves"].Value = lista_promociones[tipo_sala - 1].dia_jueves_prop;

                    cmd.Parameters.Add("@viernes", SqlDbType.Float);
                    cmd.Parameters["@viernes"].Value = lista_promociones[tipo_sala - 1].dia_viernes_prop;

                    cmd.Parameters.Add("@sabado", SqlDbType.Float);
                    cmd.Parameters["@sabado"].Value = lista_promociones[tipo_sala - 1].dia_sabado_prop;

                    cmd.Connection = conn;
                    conn.Open();
                    vRespuesta = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    pError = "Error general en la funcion ActualizarPromociones. Detalles: " + ex.Message;
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