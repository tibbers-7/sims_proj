using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;
using System.Data;

namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for datePick.xaml
    /// </summary>
    public partial class datePick : Window
    {
        public datePick()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var document = new PdfDocument();
            var page = document.Pages.Add();
            var graphics = page.Graphics;

            RectangleF bounds = new RectangleF(0, 0, document.Pages[0].GetClientSize().Width, 50);

            graphics.DrawString("Klinika Zdravo,Futoski put 16", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new System.Drawing.PointF(10, 0));
            graphics.DrawString("Tel: 021/731/6421", new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new System.Drawing.PointF(10, 10));
            graphics.DrawString("Izvestaj o zauzetosti prostorija", new PdfStandardFont(PdfFontFamily.Helvetica, 25), PdfBrushes.Black, new System.Drawing.PointF(100, 40));

            string date = datePicker.SelectedDate.ToString().Split(" ")[0];

            graphics.DrawString(date, new PdfStandardFont(PdfFontFamily.Helvetica, 25), PdfBrushes.Black, new System.Drawing.PointF(200, 70));
           
            var table = new DataTable();
            table.Columns.Add("Room ID");
            table.Columns.Add("Name");
            table.Columns.Add("Time period");
            table.Rows.Add(new object[] { "1", "Operaciona sala", "08:00  - 12:30" });
            table.Rows.Add(new object[] { "2", "Sala za sastanke", "10:00  - 14:30" });
            table.Rows.Add(new object[] { "3", "Soba za odmor", "08:00  - 16:30" });

            table.Rows.Add(new object[] { "4", "Operaciona sala 2", "08:00  - 12:30" });
            table.Rows.Add(new object[] { "5", "Intenzivna nega", "10:00  - 14:30" });
            table.Rows.Add(new object[] { "6", "Soba za sastanke", "08:00  - 16:30" });

            table.Rows.Add(new object[] { "7", "Operaciona sala 3", "08:00  - 12:30" });
            table.Rows.Add(new object[] { "8", "Zubna ordinacija", "10:00  - 14:30" });
            table.Rows.Add(new object[] { "9", "Soba za odmor", "08:00  - 16:30" });

            table.Rows.Add(new object[] { "10", "Operaciona sala 4", "08:00  - 12:30" });
            table.Rows.Add(new object[] { "11", "Soba za vezbanje", "10:00  - 14:30" });
            table.Rows.Add(new object[] { "12", "Psiholoska ordinacija", "08:00  - 16:30" });

            table.Rows.Add(new object[] { "13", "Operaciona sala 5", "08:00  - 12:30" });
            table.Rows.Add(new object[] { "14", "Magacin", "10:00  - 14:30" });
            table.Rows.Add(new object[] { "15", "Soba za odmor 2", "08:00  - 16:30" });
            PdfGrid grid = new PdfGrid();
            grid.DataSource = table;
            grid.Draw(page, 40, 120);
            string[] parameters= date.Split("/");
            var filename =parameters[0]+"-"+parameters[1]+"-"+parameters[2]+"-"+ "report.pdf";
            document.Save(filename);
            document.Close();
            this.Close();
        }
    }
}
