using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFinalEricJose.Page
{
    public partial class SelectTicket : System.Web.UI.Page
    {
        public void Mensaje(string pMensaje)
        {
            //HttpUtility.ParseQueryString(myU)
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('" + pMensaje + "')";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Button btn = new Button();
                    btn.CssClass = "seat me-1 ms-1";
                    btn.Text = "A-" + i.ToString();
                    btn.Click += (se, ev) => button_Click(se, ev, 10);
                    pnl_butacas.Controls.Add(btn);
                }
            }
            //int id = Convert.ToInt32(ViewState["id_pelicula"]);
            //Mensaje(Convert.ToString(Session["id_pelicula"]));
        }

        public void button_Click(object sender, EventArgs e, int pa)
        {
            Mensaje(pa.ToString());
        }
    }
}