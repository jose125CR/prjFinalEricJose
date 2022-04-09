using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPelicula
    {
        private int id;

        public int id_Prop
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string nombre_Prop
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string sipnosis;

        public string sipnosis_Prop
        {
            get { return sipnosis; }
            set { sipnosis = value; }
        }

        private string img_url;

        public string img_url_Prop
        {
            get { return img_url; }
            set { img_url = value; }
        }

        private string year;

        public string year_Prop
        {
            get { return year; }
            set { year = value; }
        }

    }
}