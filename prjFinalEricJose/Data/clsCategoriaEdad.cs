using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsCategoriaEdad
    {
        private int id_categoria_edad_pelicula;

        public int id_categoria_edad_pelicula_Prop
        {
            get { return id_categoria_edad_pelicula; }
            set { id_categoria_edad_pelicula = value; }
        }

        private string categoria_edad;

        public string categoria_edad_prop
        {
            get { return categoria_edad; }
            set { categoria_edad = value; }
        }
    }
}