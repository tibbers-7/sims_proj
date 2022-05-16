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

namespace Zdravo.DoctorView
{
    /// <summary>
    /// Interaction logic for DrugReportWindow.xaml
    /// </summary>
    public partial class DrugReportWindow : Window
    {
        private DrugReportViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        public DrugReportWindow(DoctorHomeViewModel callerWindow,int drugId)
        {
            viewModel = new DrugReportViewModel(drugId);
            this.callerWindow = callerWindow;
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (reason_tb.Text.Equals(""))
            {
                MessageBox.Show("Niste uneli sve potrebne podatke!", "Greška");
            }
            else
            {
                viewModel.CreateDrugReport();
                callerWindow.RefreshDrugs();
                this.Close();
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
