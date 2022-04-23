using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsListaTicket
    {
        private int id_ticket;

        public int id_ticket_Prop
        {
            get { return id_ticket; }
            set { id_ticket = value; }
        }

        private string dni_persona;

        public string dni_persona_Prop
        {
            get { return dni_persona; }
            set { dni_persona = value; }
        }

        private string nombre_apellido;

        public string nombre_apellido_Prop
        {
            get { return nombre_apellido; }
            set { nombre_apellido = value; }
        }

        private string hora_compra;

        public string hora_compra_Prop
        {
            get { return hora_compra; }
            set { hora_compra = value; }
        }
    }
}