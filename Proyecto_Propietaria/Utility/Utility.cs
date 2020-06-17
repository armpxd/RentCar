using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;
using Proyecto_Propietaria.Model;
using System.Windows.Forms;

namespace Proyecto_Propietaria.Utilitys
{
    public static class Utility
    {
        public static string Encrypt(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncrypt(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static void ReportIndividual(Rent_Devolution renta2)
        {

            var file = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"Reports\ReporteDeRenta.cshtml");
            var html = Engine.Razor.RunCompile(file, Guid.NewGuid().ToString(), null, renta2, null);

            var htmlToPDf = new NReco.PdfGenerator.HtmlToPdfConverter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = renta2.Client.Name.TrimEnd();
            //saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.ShowDialog();

            htmlToPDf.GeneratePdf(html, null, saveFileDialog.FileName +".pdf");

        }

        public static void ReportGrupal(IEnumerable<Rent_Devolution> rents)
        {

            var file = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"Reports\ReportePorFecha.cshtml");
            var html = Engine.Razor.RunCompile(file, Guid.NewGuid().ToString(), null, rents, null);

            var htmlToPDf = new NReco.PdfGenerator.HtmlToPdfConverter();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Reporte clientes";
            saveFileDialog.ShowDialog();
            htmlToPDf.GeneratePdf(html, null, AppDomain.CurrentDomain.BaseDirectory + @"Reports\" + @"Reporte clientes.pdf");

        }
    }
}
