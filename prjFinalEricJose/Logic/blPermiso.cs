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
    public class blPermiso
    {
        public static Boolean CosultarPermisoPagina(int id_pagina, int id_permiso, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string dni = "115960067";

            Boolean tiene_permiso = false;

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_permiso_pagina";

                cmd.Parameters.Add("@ppaDni_persona", SqlDbType.VarChar);
                cmd.Parameters["@ppaDni_persona"].Value = dni;

                cmd.Parameters.Add("@ppaId_pagina", SqlDbType.Int);
                cmd.Parameters["@ppaId_pagina"].Value = id_pagina;

                cmd.Parameters.Add("@ppaId_permiso", SqlDbType.Int);
                cmd.Parameters["@ppaId_permiso"].Value = id_permiso;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["id_permiso_pagina"].ToString()))
                    {
                        tiene_permiso = true;
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarPermisoPagina. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return tiene_permiso;
        }

        public clsPermiso CosultarPemisosPorRolModulo(int id_rol, int id_modulo, ref string pError)
        {
            clsPermiso dt_permiso = new clsPermiso();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_permisos_rol_pagina";

                cmd.Parameters.Add("@id_rol", SqlDbType.Int);
                cmd.Parameters["@id_rol"].Value = id_rol;

                cmd.Parameters.Add("@id_pagina", SqlDbType.Int);
                cmd.Parameters["@id_pagina"].Value = id_modulo;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["puede_consultar"].ToString()))
                    {
                        dt_permiso.consultar_Prop = Convert.ToBoolean(dr["puede_consultar"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["puede_registar"].ToString()))
                    {
                        dt_permiso.registrar_Prop = Convert.ToBoolean(dr["puede_registar"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["puede_modificar"].ToString()))
                    {
                        dt_permiso.editar_Prop = Convert.ToBoolean(dr["puede_modificar"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["puede_eliminar"].ToString()))
                    {
                        dt_permiso.eliminar_Prop = Convert.ToBoolean(dr["puede_eliminar"].ToString());
                    }
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

            return dt_permiso;
        }

        public void ActualizarPermisosPorRolModulo(
            int id_rol, int id_modulo, clsPermiso dt_permiso, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_actualizar_permiso_rol_pagina";

                cmd.Parameters.Add("@id_rol", SqlDbType.Int);
                cmd.Parameters["@id_rol"].Value = id_rol;

                cmd.Parameters.Add("@id_pagina", SqlDbType.Int);
                cmd.Parameters["@id_pagina"].Value = id_modulo;

                cmd.Parameters.Add("@puede_consultar", SqlDbType.Bit);
                cmd.Parameters["@puede_consultar"].Value = dt_permiso.consultar_Prop;

                cmd.Parameters.Add("@puede_registrar", SqlDbType.Bit);
                cmd.Parameters["@puede_registrar"].Value = dt_permiso.registrar_Prop;

                cmd.Parameters.Add("@puede_modificar", SqlDbType.Bit);
                cmd.Parameters["@puede_modificar"].Value = dt_permiso.editar_Prop;

                cmd.Parameters.Add("@puede_eliminar", SqlDbType.Bit);
                cmd.Parameters["@puede_eliminar"].Value = dt_permiso.eliminar_Prop;

                cmd.Connection = conn;
                conn.Open();

                vRespuesta = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion ActualizarPermisosPorRolModulo. Detalles: " + ex.Message;
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

        public Boolean CosultarPermisoDropAdministracion(int id_rol, ref string pError)
        {
            clsConnection conexion = new clsConnection();

            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            Boolean tiene_permiso = false;

            try
            {
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_permiso_administracion";

                cmd.Parameters.Add("@id_rol", SqlDbType.Int);
                cmd.Parameters["@id_rol"].Value = id_rol;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (!string.IsNullOrEmpty(dr["tiene_permiso"].ToString()))
                    {
                        tiene_permiso = Convert.ToBoolean(dr["tiene_permiso"].ToString()); ;
                    }
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarPermisoDropAdministracion. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return tiene_permiso;
        }

    }
}