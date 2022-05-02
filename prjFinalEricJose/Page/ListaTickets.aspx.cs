using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;


namespace prjFinalEricJose.Page
{
    public partial class ListaTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultarListaTicket();
            }
        }

        private void ConsultarListaTicket()
        {
            blListaTicket lg_lista_ticket = new blListaTicket();

            string vError = null;

            List<clsListaTicket> lista_tickets = lg_lista_ticket.CosultarListaTickets(ref vError);

            if (vError == null)
            {
                grd_tickets.DataSource = lista_tickets;
                grd_tickets.DataBind();
            }

        }

        protected void btn_buscar_ticket_Click(object sender, EventArgs e)
        {
            blListaTicket lg_lista_ticket = new blListaTicket();

            string vError = null;

            List<clsListaTicket> lista_tickets = lg_lista_ticket.CosultarListaTicketsPorDni(txt_buscar_ticket.Text, ref vError);

            if (vError == null)
            {
                grd_tickets.DataSource = lista_tickets;
                grd_tickets.DataBind();
            }
        }
    }
}