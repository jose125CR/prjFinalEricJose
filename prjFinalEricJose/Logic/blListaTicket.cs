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
    public class blListaTicket
    {
        public List<clsListaTicket> CosultarListaTickets(ref string pError)
        {
            List<clsListaTicket> lista_ticket = new List<clsListaTicket>();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_tickets";

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsListaTicket ticket = new clsListaTicket(); 

                    if (!string.IsNullOrEmpty(dr["id_ticket"].ToString()))
                    {
                        ticket.id_ticket_Prop = Convert.ToInt32(dr["id_ticket"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["dni_persona"].ToString()))
                    {
                        ticket.dni_persona_Prop = dr["dni_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_apellido"].ToString()))
                    {
                        ticket.nombre_apellido_Prop = dr["nombre_apellido"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["hora_compra"].ToString()))
                    {
                        ticket.hora_compra_Prop = dr["hora_compra"].ToString();
                    }

                    lista_ticket.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaTickets. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_ticket;
        }

        public List<clsListaTicket> CosultarListaTicketsPorDni(string dni, ref string pError)
        {
            List<clsListaTicket> lista_ticket = new List<clsListaTicket>();
            clsConnection conexion = new clsConnection();
            SqlConnection conn = new SqlConnection(conexion.ObtenerCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataReader dr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pa_consultar_factura_dni";

                cmd.Parameters.Add("@dni_persona", SqlDbType.VarChar);
                cmd.Parameters["@dni_persona"].Value = dni;

                cmd.Connection = conn;

                conn.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clsListaTicket ticket = new clsListaTicket();

                    if (!string.IsNullOrEmpty(dr["id_ticket"].ToString()))
                    {
                        ticket.id_ticket_Prop = Convert.ToInt32(dr["id_ticket"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["dni_persona"].ToString()))
                    {
                        ticket.dni_persona_Prop = dr["dni_persona"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["nombre_apellido"].ToString()))
                    {
                        ticket.nombre_apellido_Prop = dr["nombre_apellido"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["hora_compra"].ToString()))
                    {
                        ticket.hora_compra_Prop = dr["hora_compra"].ToString();
                    }

                    lista_ticket.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                pError = "Error general en la funcion CosultarListaTicketsPorDni. Detalles: " + ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
                conn = null;
            }

            return lista_ticket;
        }


    }
}