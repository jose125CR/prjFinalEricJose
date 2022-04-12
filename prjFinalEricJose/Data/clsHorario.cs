using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsHorario
    {
        private int id_horario;

        public int id_horario_Prop
        {
            get { return id_horario; }
            set { id_horario = value; }
        }

        private string horario;

        public string horario_Prop
        {
            get { return horario; }
            set { horario = value; }
        }
    }
}