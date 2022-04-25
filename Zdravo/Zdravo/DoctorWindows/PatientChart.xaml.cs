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
        private PatientChartViewModel viewModel;
        public PatientChart(int id)
        {
            viewModel = new PatientChartViewModel(id);
            this.DataContext = viewModel;
            InitializeComponent();
            if (viewModel.Gender == 'm')
            {
                male.IsChecked = true;
            } else female.IsChecked = true;
            switch (viewModel.MarriageStatus)
            {
                case 'm':
                    married.IsChecked = true;
                    break;
                case 'w':
                    widow.IsChecked = true;
                    break;
                case 'd':
                    divorced.IsChecked = true;
                    break;
                default:
                    single.IsChecked = true;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
