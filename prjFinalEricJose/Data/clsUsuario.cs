using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsUsuario
    {
        private String dni_persona;

        public String dni_persona_Prop
        {
            get { return dni_persona; }
            set { dni_persona = value; }
        }

        private int id_rol;

        public int id_rol_Prop
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        private string rol;

        public string rol_Prop
        {
            get { return rol; }
            set { rol = value; }
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

        private string correo;

        public string correo_Prop
        {
            get { return correo; }
            set { correo = value; }
        }

        private DateTime fecha_nac;

        public DateTime fecha_nac_Prop
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

        private Boolean preferencial;

        public Boolean preferencial_Prop
        {
            get { return preferencial; }
            set { preferencial = value; }
        }
    }
}