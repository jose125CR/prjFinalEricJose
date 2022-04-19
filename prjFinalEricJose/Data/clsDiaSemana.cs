using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsDiaSemana
    {
        private int id_dia;

        public int id_dia_Prop
        {
            get { return id_dia; }
            set { id_dia = value; }
        }

        private string nombre_dia;

        public string nombre_dia_Prop
        {
            get { return nombre_dia; }
            set { nombre_dia = value; }
        }
    }
}