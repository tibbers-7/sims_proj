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
    /// Interaction logic for AppointmentReport.xaml
    /// </summary>
    public partial class Report : Window
    {
        private ReportViewModel viewModel;
        public Report(int id)
        { 
            InitializeComponent();
            viewModel = new ReportViewModel(id);
            DataContext = viewModel;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AcceptClick();
        }
    }
}
