using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPerfil
    {

        private string nombre_completo;

        public string nombre_completo_Prop
        {
            get { return nombre_completo; }
            set { nombre_completo = value; }
        }

        private string rol;

        public string rol_Prop
        {
            get { return rol; }
            set { rol = value; }
        }

        private string correo;

        public string correo_Prop
        {
            get { return correo; }
            set { correo = value; }
        }

        private string fecha_nac;

        public string fecha_nac_Prop
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }

        private string telefono;

        public string telefono_Prop
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string fecha_registro;

        public string fecha_registro_Prop
        {
            get { return fecha_registro; }
            set { fecha_registro = value; }
        }

        private string puntos;

        public string puntos_Prop
        {
            get { return puntos; }
            set { puntos = value; }
        }


        private string canjes;

        public string canjes_Prop
        {
            get { return canjes; }
            set { canjes = value; }
        }

        private string puntos_necesarios;

        public string puntos_necesarios_Prop
        {
            get { return puntos_necesarios; }
            set { puntos_necesarios = value; }
        }


        private string canjes_necesarios;

        public string canjes_necesarios_Prop
        {
            get { return canjes_necesarios; }
            set { canjes_necesarios = value; }
        }
    }
}