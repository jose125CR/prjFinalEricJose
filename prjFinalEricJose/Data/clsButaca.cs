using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsButaca
    {
        private int id_butaca;

        public int id_butaca_Prop
        {
            get { return id_butaca; }
            set { id_butaca = value; }
        }

        private int id_pelicula;

        public int id_pelicula_Prop
        {
            get { return id_pelicula; }
            set { id_pelicula = value; }
        }

        private int id_horario;

        public int id_horario_Prop
        {
            get { return id_horario; }
            set { id_horario = value; }
        }

        private int id_sala;

        public int id_sala_Prop
        {
            get { return id_sala; }
            set { id_sala = value; }
        }

        private int id_categoria_persona;

        public int id_categoria_persona_Prop
        {
            get { return id_categoria_persona; }
            set { id_categoria_persona = value; }
        }

        private string identificador;

        public string identificador_Prop
        {
            get { return identificador; }
            set { identificador = value; }
        }

        private string estado;

        public string estado_Prop
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}