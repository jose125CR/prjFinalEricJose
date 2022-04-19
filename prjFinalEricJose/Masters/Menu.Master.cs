using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Libreria para definir las rutas*/

namespace prjFinalEricJose.Masters
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["loggueado"])) 
            {
                header_master.Visible = true;
            }

            //RegisterRoutes(RouteTable.Routes);
        }

        //private void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.MapPageRoute("users", "Page/users", "~/Page/UsersList.aspx");
        //}
    }
}