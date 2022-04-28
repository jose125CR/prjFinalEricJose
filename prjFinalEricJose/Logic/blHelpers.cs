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
        public static readonly int PROMOCIONES = 3;
        public static readonly int PERMISOS = 4;
        public static readonly int PRECIOS = 5;
        public static readonly int FACTURADO = 6;


        /******************PERMISOS************************************************************************************/
        public static readonly int CONSULTAR = 1;
        public static readonly int REGISTRAR = 2;
        public static readonly int MODIFICAR = 3;
        public static readonly int ELIMINAR = 4;



        private static readonly String BASE_URI = "https://free.currconv.com";
        private static readonly String API_VERSION = "v7";
        private static readonly String API_KEY = "97e0aba6803c65e407b8"; //Cuenta Jose
        //private static readonly String API_KEY = "bd2cf09fb67c7be336ac"; //Cuenta Eric
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
            catch(Exception e)
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
            }catch(Exception e)
            {

            }

            return Math.Round(resultado_decimal, 2);
        }

        public static clsUsuario UsuarioDefecto()
        {
            clsUsuario defecto = new clsUsuario();

            defecto.dni_persona_Prop = "602800141";
            defecto.id_rol_Prop = 1;
            defecto.nombre1_Prop = "Eric";
            defecto.nombre2_Prop = "Gerardo";
            defecto.apellido1_Prop = "Bonilla";
            defecto.apellido2_Prop = "Vargas";
            defecto.correo_Prop = "ebonillavargas@gmail.com";
            defecto.fecha_nac_Prop = DateTime.Now;
            defecto.telefono_Prop = "88887778";
            defecto.usuario_Prop = "ebonillav";
            defecto.contrasena_Prop = "1234";
            defecto.puntos_Prop = 2;
            defecto.canjeos_Prop = 0;
            defecto.fecha_creacion_Prop = DateTime.Now;

            return defecto;
        }
    }
}