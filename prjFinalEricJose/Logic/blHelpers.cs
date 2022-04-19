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
        private static readonly String BASE_URI = "https://free.currconv.com";
        private static readonly String API_VERSION = "v7";
        private static readonly String API_KEY = "97e0aba6803c65e407b8";
        /********************************************************************/

        public static float TipoCambio()
        {
            string url = $"{BASE_URI}/api/{API_VERSION}/convert?q=USD_CRC&compact=ultra&apiKey={API_KEY}";
            var jsonString = GetResponse(url);
            var json_object = JObject.Parse(jsonString);

            float tipo_cambio_string = (float)json_object["USD_CRC"].ToObject<float>();

            return tipo_cambio_string;
        }

        private static string GetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return jsonString;
        }

        public static decimal ConseguirValorDolares(float colones)
        {
            float resultado = colones / TipoCambio();

            decimal resultado_decimal = Convert.ToDecimal(resultado);

            return Math.Round(resultado_decimal, 2);
        }
    }
}