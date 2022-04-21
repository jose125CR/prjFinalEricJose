using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFinalEricJose.Data
{
    public class clsModulo
    {
        private int id_pagina;

        public int id_pagina_Prop
        {
            get { return id_pagina; }
            set { id_pagina = value; }
        }

        private string nombre_pagina;

        public string nombre_pagina_Prop
        {
            get { return nombre_pagina; }
            set { nombre_pagina = value; }
        }
    }
}