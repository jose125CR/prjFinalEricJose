using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjFinalEricJose.Logic;
using prjFinalEricJose.Data;
using iText.IO.Image;
using iText.Commons.Utils;

namespace prjFinalEricJose.Page
{
    public partial class CreacionPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_ticket = Convert.ToInt32(Page.RouteData.Values["id_ticket"]);
            CrearPdf(id_ticket);
        }

        private void CrearPdf(int id_ticket)
        {
            PdfWriter pdfWriter = new PdfWriter($"Factura-{id_ticket}-{GetTimestamp(DateTime.Now)}.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            string[] columnas = { "Nombre del campo", "Valor" };

            float[] tamanios = { 7, 7 };

            iText.Layout.Element.Table tabla = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(tamanios));

            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach(string columna in columnas)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
            }

            blFacturaFinal lg_factura_final = new blFacturaFinal();
            string vError = null;

            // Insertamos la imagen en el documento

            ImageData imageData = ImageDataFactory.Create(Path.Combine());

            iText.Layout.Element.Image img = new iText.Layout.Element.Image(imageData);
            // position in document
            img.SetFixedPosition(25, 500);
            ////img.SetFixedPosition(25, 100);
            img.SetHeight(95);
            img.SetWidth(95);

            //*Agrega imagen a documento.
            documento.Add(img);

            clsFacturaFinal dt_factura = lg_factura_final.CosultarFacturaFinal(id_ticket, ref vError);

            tabla.AddCell(new Cell().Add(new Paragraph("ID de la Factura")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.id_ticket_Prop.ToString())));
            tabla.AddCell(new Cell().Add(new Paragraph("Día y Hora de la Compra")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.dia_hora_compra_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Nombre de la Película")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.nombre_pelicula_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Categoría de la Película")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.categoria_edad_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Cédula de el Comprador")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.dni_persona_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Nombre Completo del Comprador")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.nombre_completo_persona_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Cantidad de Butacas Generales")));
            tabla.AddCell(new Cell().Add(new Paragraph(NumeroONinguna(dt_factura.contador_butacas_general_Prop))));
            tabla.AddCell(new Cell().Add(new Paragraph("Cantidad de Butacas Niños")));
            tabla.AddCell(new Cell().Add(new Paragraph(NumeroONinguna(dt_factura.contador_butacas_ninos_Prop))));
            tabla.AddCell(new Cell().Add(new Paragraph("Cantidad de Butacas Adultos Mayores")));
            tabla.AddCell(new Cell().Add(new Paragraph(NumeroONinguna(dt_factura.contador_butacas_adultos_Prop))));
            tabla.AddCell(new Cell().Add(new Paragraph("Lista de Butacas")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.butacas_ordenadas_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Sala de la Película")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.sala_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Hora de la Película")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.hora_pelicula_Prop)));
            tabla.AddCell(new Cell().Add(new Paragraph("Puntos acumulados en esta compra")));
            tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.puntos_acumulados_Prop)));

            if (dt_factura.monto_total_Prop == 0)
            {
                var num = dt_factura.sala_Prop.Split(' ');
                if (num[1] == "1" || num[1] == "4")
                {
                    tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Colones")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Promocion 2D")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Dólares")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Promocion 2D")));
                }
                else
                {

                    tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Colones")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Promocion IMAX")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Dólares")));
                    tabla.AddCell(new Cell().Add(new Paragraph("Promocion IMAX")));
                }
            }
            else
            {
                tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Colones")));
                tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.monto_total_Prop.ToString())));
                tabla.AddCell(new Cell().Add(new Paragraph("Monto Total en Dólares")));
                tabla.AddCell(new Cell().Add(new Paragraph(dt_factura.monto_total_Prop.ToString())));
            }

            documento.Add(tabla);
            documento.Close();
        }

        private string NumeroONinguna(string numero_butacas)
        {
            if (numero_butacas != null)
            {
                return numero_butacas;
            }
            return "Ninguna";
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}