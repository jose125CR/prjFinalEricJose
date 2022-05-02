using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPreciosCategorias
    {
        private string nombre_sala;

        public string nombre_sala_prop
        {
            get { return nombre_sala; }
            set { nombre_sala = value; }
        }

        private float precio_general;

        public float precio_general_prop
        {
            get { return precio_general; }
            set { precio_general = value; }
        }

        private float precio_nino;

        public float precio_nino_prop
        {
            get { return precio_nino; }
            set { precio_nino = value; }
        }

        private float precio_adulto;

        public float precio_adulto_prop
        {
            get { return precio_adulto; }
            set { precio_adulto = value; }
        }
    }
}