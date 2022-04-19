using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;


namespace prjFinalEricJose
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection Routes)
        {
            RouteTable.Routes.MapPageRoute("listaPersonas", "personas", "~/Page/UsersList.aspx");

            RouteTable.Routes.MapPageRoute("selecionTickets", "tickets/{id_pelicula}/{id_horario}/{id_sala}/{id_dia}/", "~/Page/SelectTicket.aspx");
            
            RouteTable.Routes.MapPageRoute("listaPeliculas", "peliculas/", "~/Page/MoviesList.aspx");

            RouteTable.Routes.MapPageRoute("FacturaFinal", "factura/{id_ticket}", "~/Page/FacturaTickets.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}