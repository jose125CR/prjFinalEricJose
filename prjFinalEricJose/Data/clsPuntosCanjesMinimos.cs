using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPuntosCanjesMinimos
    {
        private int puntos_necesarios;

        public int puntos_necesarios_Prop
        {
            get { return puntos_necesarios; }
            set { puntos_necesarios = value; }
        }


        private int canjes_necesarios;

        public int canjes_necesarios_Prop
        {
            get { return canjes_necesarios; }
            set { canjes_necesarios = value; }
        }
    }
}