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
using Zdravo.ViewModel;

namespace Zdravo.DoctorWindows
{
    /// <summary>
    /// Interaction logic for PatientChart.xaml
    /// </summary>
    public partial class PatientChart : Window
    {
        private int apptId;
        private PatientChartViewModel viewModel;
        public PatientChart(int apptId,int patientId)
        {
            this.apptId = apptId;
            viewModel = new PatientChartViewModel(apptId, patientId);
            this.DataContext = viewModel;
            InitializeComponent();
            if (viewModel.Gender == 'm')
            {
                male.IsChecked = true;
                female.IsEnabled = false;
            }
            else
            {
                female.IsChecked = true;
                male.IsEnabled = false;
            }
            switch (viewModel.MarriageStatus)
            {
                case 'm':
                    married.IsChecked = true;
                    widow.IsEnabled = false;
                    divorced.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                case 'w':
                    widow.IsChecked = true;
                    married.IsEnabled = false;
                    divorced.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                case 'd':
                    divorced.IsChecked = true;
                    married.IsEnabled = false;
                    widow.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                default:
                    single.IsChecked = true;
                    married.IsEnabled = false;
                    widow.IsEnabled = false;
                    divorced.IsEnabled = false;
                    break;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ReportRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = reportTable.SelectedItem;
            viewModel.ShowReport(int.Parse((reportTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

    }
}
