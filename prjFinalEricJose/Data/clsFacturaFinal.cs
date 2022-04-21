using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsFacturaFinal
    {
        private int id_ticket;

        public int id_ticket_Prop
        {
            get { return id_ticket; }
            set { id_ticket = value; }
        }

        private string dia_hora_compra;

        public string dia_hora_compra_Prop
        {
            get { return dia_hora_compra; }
            set { dia_hora_compra = value; }
        }

        private string nombre_pelicula;

        public string nombre_pelicula_Prop
        {
            get { return nombre_pelicula; }
            set { nombre_pelicula = value; }
        }

        private string categoria_edad;

        public string categoria_edad_Prop
        {
            get { return categoria_edad; }
            set { categoria_edad = value; }
        }

        private string dni_persona;

        public string dni_persona_Prop
        {
            get { return dni_persona; }
            set { dni_persona = value; }
        }

        private string nombre_completo_persona;

        public string nombre_completo_persona_Prop
        {
            get { return nombre_completo_persona; }
            set { nombre_completo_persona = value; }
        }

        private string contador_butacas_general;

        public string contador_butacas_general_Prop
        {
            get { return contador_butacas_general; }
            set { contador_butacas_general = value; }
        }

        private string contador_butacas_ninos;

        public string contador_butacas_ninos_Prop
        {
            get { return contador_butacas_ninos; }
            set { contador_butacas_ninos = value; }
        }

        private string contador_butacas_adultos;

        public string contador_butacas_adultos_Prop
        {
            get { return contador_butacas_adultos; }
            set { contador_butacas_adultos = value; }
        }

        private string butacas_ordenadas;

        public string butacas_ordenadas_Prop
        {
            get { return butacas_ordenadas; }
            set { butacas_ordenadas = value; }
        }

        private string sala;

        public string sala_Prop
        {
            get { return sala; }
            set { sala = value; }
        }

        private string hora_pelicula;

        public string hora_pelicula_Prop
        {
            get { return hora_pelicula; }
            set { hora_pelicula = value; }
        }

        private string cantidad_total_butacas;

        public string cantidad_total_butacas_Prop
        {
            get { return cantidad_total_butacas; }
            set { cantidad_total_butacas = value; }
        }

        private float monto_total;

        public float monto_total_Prop
        {
            get { return monto_total; }
            set { monto_total = value; }
        }
    }
}