using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsTicket
    {

        private int id_ticket;

        public int id_ticket_Prop
        {
            get { return id_ticket; }
            set { id_ticket = value; }
        }

        private string dni_persona;

        public string dni_persona_prop
        {
            get { return dni_persona; }
            set { dni_persona = value; }
        }

        private int id_pelicula;

        public int id_pelicula_Prop
        {
            get { return id_pelicula; }
            set { id_pelicula = value; }
        }

        private int id_sala_pelicula;

        public int id_sala_pelicula_prop
        {
            get { return id_sala_pelicula; }
            set { id_sala_pelicula = value; }
        }

        private int id_horario_pelicula;

        public int id_horario_pelicula_prop
        {
            get { return id_horario_pelicula; }
            set { id_horario_pelicula = value; }
        }

        private DateTime hora_compra;

        public DateTime hora_compra_Prop
        {
            get { return hora_compra; }
            set { hora_compra = value; }
        }
    }
}