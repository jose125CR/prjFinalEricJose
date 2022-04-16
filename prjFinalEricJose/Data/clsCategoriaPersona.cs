using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsCategoriaPersona
    {
        private int id_categoria_persona;

        public int id_categoria_persona_Prop
        {
            get { return id_categoria_persona; }
            set { id_categoria_persona = value; }
        }

        private string nombre_categoria;

        public string nombre_categoria_prop
        {
            get { return nombre_categoria; }
            set { nombre_categoria = value; }
        }
    }
}