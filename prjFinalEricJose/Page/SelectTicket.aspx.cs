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
            for (int i = 1; i <= 50; i++)
            {
                Button btn = new Button();
                btn.CssClass = "seat me-1 ms-1 mt-2" + ConseguirClaseButaca(i);
                btn.Text = "A-" + i.ToString();
                btn.Click += (se, ev) => button_Click(se, ev, btn.Text);
                pnl_butacas.Controls.Add(btn);
            }
            //int id = Convert.ToInt32(ViewState["id_pelicula"]);
            //Mensaje(Convert.ToString(Session["id_pelicula"]));
        }

        private string ConseguirClaseButaca(int pa)
        {
            if (pa % 5 == 0)
            {
                return " ms-5";
            }
            else if ((pa - 1) % 5 == 0)
            {
                System.Diagnostics.Debug.WriteLine(pa, "Yo soy pa");
                return " me-5";
            }
            else
            {
                return "";
            }
        }

        public void button_Click(object sender, EventArgs e, string pa)
        {
            Mensaje(pa);
        }
    }
}