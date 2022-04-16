using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPreciosEntradasSalaDia
    {
        private int id_categoria_persona;

        public int id_categoria_persona_Prop
        {
            get { return id_categoria_persona; }
            set { id_categoria_persona = value; }
        }

        private float precio_total_categoria;

        public float precio_total_categoria_prop
        {
            get { return precio_total_categoria; }
            set { precio_total_categoria = value; }
        }

        private string nombre_categoria;

        public string nombre_categoria_prop
        {
            get { return nombre_categoria; }
            set { nombre_categoria = value; }
        }

        private int cantidad_butacas;

        public int cantidad_butacas_Prop
        {
            get { return cantidad_butacas; }
            set { cantidad_butacas = value; }
        }

        private float precio_por_entrada;

        public float precio_por_entrada_prop
        {
            get { return precio_por_entrada; }
            set { precio_por_entrada = value; }
        }
    }
}