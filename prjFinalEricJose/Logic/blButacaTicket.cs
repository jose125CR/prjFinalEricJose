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
    public class blButacaTicket
    {

        public void GuardarButacaTicket(int id_ticket, int id_butaca, float monto_vendido, ref string pError)
        {
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());
            SqlCommand cmd = new SqlCommand();

            int vRespuesta;

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_registrar_butaca_ticket";

                cmd.Parameters.Add("@ppaId_ticket", SqlDbType.Int);
                cmd.Parameters["@ppaId_ticket"].Value = id_ticket;

                cmd.Parameters.Add("@ppaId_butaca", SqlDbType.Int);
                cmd.Parameters["@ppaId_butaca"].Value = id_butaca;

                cmd.Parameters.Add("@ppaMonto_vendido", SqlDbType.Float);
                cmd.Parameters["@ppaMonto_vendido"].Value = monto_vendido;

                cmd.Connection = conn;
                conn.Open();
                vRespuesta = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion GuardarButacaTicket. Detalles: " + ex.Message;
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