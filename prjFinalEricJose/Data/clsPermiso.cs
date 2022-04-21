using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsPermiso
    {
        private Boolean consultar;

        public Boolean consultar_Prop
        {
            get { return consultar; }
            set { consultar = value; }
        }

        private Boolean registrar;

        public Boolean registrar_Prop
        {
            get { return registrar; }
            set { registrar = value; }
        }

        private Boolean editar;

        public Boolean editar_Prop
        {
            get { return editar; }
            set { editar = value; }
        }

        private Boolean eliminar;

        public Boolean eliminar_Prop
        {
            get { return eliminar; }
            set { eliminar = value; }
        }
    }
}