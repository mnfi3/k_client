using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kiosk
{
    /// <summary>
    /// Interaction logic for PrintReceipt.xaml
    /// </summary>
    public partial class PrintReceipt : Window
    {
        public PrintReceipt()
        {
            InitializeComponent();

            //rpt.LocalReport.EnableExternalImages = true;
            //string _path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            //string ContentStart = _path + @"/Kiosk/asset/receipt.rdlc";

            ////MessageBox.Show(ContentStart);

            ////rpt.LocalReport.ReportPath = ContentStart;
            //rpt.LocalReport.ReportPath = @"/Kiosk/receipt.rdlc"; ;
            ////rpt.LocalReport.ReportEmbeddedResource = "Kiosk.asset.receipt.rdlc";
            ReportParameter[] para = new ReportParameter[] {
                new ReportParameter("order_num", "123"),
                new ReportParameter("restaurant", G.restaurant.name),
                new ReportParameter("price", G.cart.cost.ToString()),
                new ReportParameter("d_price", G.cart.d_cost.ToString())
            };

            //rpt.LocalReport.SetParameters(para);
            //rpt.SetDisplayMode(DisplayMode.PrintLayout);
            //rpt.Refresh();

            //this.rpt.RefreshReport();






            Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;


//This is optional if you have parameter then you can add parameters as much as you want

            //ReportDataSource rdsAct = new ReportDataSource("RptActDataSet_usp_GroupAccntDetails", dsActPlan.Tables[0]);
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.Refresh();
            viewer.LocalReport.ReportPath = "receipt.rdlc"; //This is your rdlc name.
           // viewer.LocalReport.SetParameters(para);
            //viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            // byte[] bytes = viewer.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.          
            // System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            System.IO.File.WriteAllBytes("hello.pdf", bytes);
        }

        
    }
}
