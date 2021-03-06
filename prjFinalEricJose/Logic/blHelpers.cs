using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;
using System.Net;
using System.Web.Script.Serialization;

/*Librerias Para la conversión de moneda*/
using System.IO;
using Newtonsoft.Json.Linq;

namespace prjFinalEricJose.Logic
{
    public class blHelpers
    {
        /******************MODULOS************************************************************************************/
        public static readonly int USUARIOS = 1;
        public static readonly int PELICULAS = 2;
        public static readonly int PRECIOS = 3;
        public static readonly int PERMISOS = 4;
        public static readonly int FACTURADO = 5;


        /******************PERMISOS************************************************************************************/
        public static readonly int CONSULTAR = 1;
        public static readonly int REGISTRAR = 2;
        public static readonly int MODIFICAR = 3;
        public static readonly int ELIMINAR = 4;



        private static readonly String BASE_URI = "https://free.currconv.com";
        private static readonly String API_VERSION = "v7";
        //private static readonly String API_KEY = "97e0aba6803c65e407b8"; //Cuenta Jose
        private static readonly String API_KEY = "bd2cf09fb67c7be336ac"; //Cuenta Eric
        /********************************************************************/

        public static float TipoCambio()
        {
            float tipo_cambio_string = 0;

            string url = $"{BASE_URI}/api/{API_VERSION}/convert?q=USD_CRC&compact=ultra&apiKey={API_KEY}";
            try
            {
                var jsonString = GetResponse(url);
                var json_object = JObject.Parse(jsonString);

                tipo_cambio_string = (float)json_object["USD_CRC"].ToObject<float>();
            }
            catch
            {

            }

            return tipo_cambio_string;
        }

        private static string GetResponse(string url)
        {
            string jsonString = "";
            
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }catch
            {
                
            }

            return jsonString;
        }

        public static decimal ConseguirValorDolares(float colones)
        {
            float resultado = colones / TipoCambio();
            decimal resultado_decimal = 0;

            try
            {
                resultado_decimal = Convert.ToDecimal(resultado);
            }
            catch
            {

            }

            return Math.Round(resultado_decimal, 2);
        }
    }
}