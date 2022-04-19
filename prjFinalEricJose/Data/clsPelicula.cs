using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPelicula
    {
        private int id_pelicula;

        public int id_pelicula_Prop
        {
            get { return id_pelicula; }
            set { id_pelicula = value; }
        }

        private int id_categoria_edad_pelicula;

        public int id_categoria_edad_pelicula_Prop
        {
            get { return id_categoria_edad_pelicula; }
            set { id_categoria_edad_pelicula = value; }
        }

        private string nombre_pelicula;

        public string nombre_pelicula_Prop
        {
            get { return nombre_pelicula; }
            set { nombre_pelicula = value; }
        }

        private string direccion_img;

        public string direccion_img_prop
        {
            get { return direccion_img; }
            set { direccion_img = value; }
        }

        private string sinopsis;

        public string sinopsis_Prop
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

        private string estado;

        public string estado_Prop
        {
            get { return estado; }
            set { estado = value; }
        }

        private List<clsHorario> horarios;

        public List<clsHorario> horarios_Prop
        {
            get { return horarios; }
            set { horarios = value; }
        }

        private List<clsSalaPelicula> salas;

        public List<clsSalaPelicula> salas_Prop
        {
            get { return salas; }
            set { salas = value; }
        }

        private List<clsDiaSemana> dias;

        public List<clsDiaSemana> dias_Prop
        {
            get { return dias; }
            set { dias = value; }
        }

        private DateTime fecha_estreno;

        public DateTime fecha_estreno_Prop
        {
            get { return fecha_estreno; }
            set { fecha_estreno = value; }
        }
    }
}