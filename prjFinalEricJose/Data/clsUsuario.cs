using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsUsuario
    {
        private int dni;

        public int dni_Prop
        {
            get { return dni; }
            set { dni = value; }
        }

        private string nombre1;

        public string nombre1_Prop
        {
            get { return nombre1; }
            set { nombre1 = value; }
        }

        private string nombre2;

        public string nombre2_Prop
        {
            get { return nombre2; }
            set { nombre2 = value; }
        }

        private string apellido1;

        public string apellido1_Prop
        {
            get { return apellido1; }
            set { apellido1 = value; }
        }

        private string apellido2;

        public string apellido2_Prop
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }

        private string usuario;

        public string usuario_Prop
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string contrasena;

        public string contrasena_Prop
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        private string role;

        public string role_Prop
        {
            get { return role; }
            set { role = value; }
        }

        private int puntos;

        public int puntos_Prop
        {
            get { return puntos; }
            set { puntos = value; }
        }

        private int canjeos;

        public int canjeos_Prop
        {
            get { return canjeos; }
            set { canjeos = value; }
        }

        private DateTime fecha_creacion;

        public DateTime fecha_creacion_Prop
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }
    }
}