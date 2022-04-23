using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsSemanaPromicion
    {
        private string nombre_sala;

        public string nombre_sala_prop
        {
            get { return nombre_sala; }
            set { nombre_sala = value; }
        }

        private float dia_domingo;

        public float dia_domingo_prop
        {
            get { return dia_domingo; }
            set { dia_domingo = value; }
        }

        private float dia_lunes;

        public float dia_lunes_prop
        {
            get { return dia_lunes; }
            set { dia_lunes = value; }
        }

        private float dia_martes;

        public float dia_martes_prop
        {
            get { return dia_martes; }
            set { dia_martes = value; }
        }

        private float dia_miercoles;

        public float dia_miercoles_prop
        {
            get { return dia_miercoles; }
            set { dia_miercoles = value; }
        }

        private float dia_jueves;

        public float dia_jueves_prop
        {
            get { return dia_jueves; }
            set { dia_jueves = value; }
        }

        private float dia_viernes;

        public float dia_viernes_prop
        {
            get { return dia_viernes; }
            set { dia_viernes = value; }
        }

        private float dia_sabado;

        public float dia_sabado_prop
        {
            get { return dia_sabado; }
            set { dia_sabado = value; }
        }
    }
}