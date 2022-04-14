using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsSalaPelicula
    {
        private int id_sala_cartelera;

        public int id_sala_cartelera_Prop
        {
            get { return id_sala_cartelera; }
            set { id_sala_cartelera = value; }
        }

        private string nombre_tipo_sala;

        public string nombre_tipo_sala_Prop
        {
            get { return nombre_tipo_sala; }
            set { nombre_tipo_sala = value; }
        }

    }
}