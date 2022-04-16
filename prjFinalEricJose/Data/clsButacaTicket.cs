using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsButacaTicket
    {
        private int id_ticket;

        public int id_ticket_Prop
        {
            get { return id_ticket; }
            set { id_ticket = value; }
        }

        private int id_butaca;

        public int id_butaca_Prop
        {
            get { return id_butaca; }
            set { id_butaca = value; }
        }


        private float monto_vendido;

        public float monto_vendido_Prop
        {
            get { return monto_vendido; }
            set { monto_vendido = value; }
        }
    }
}