using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace prjFinalEricJose.Connection
{
    public class clsConnection
    {
        public string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["connDB"].ConnectionString.ToString();
        }
    }
}