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
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentManagement.xaml
    /// </summary>
    public partial class AppointmentManagement : Window
    {
        private AppointmentRecordViewModel viewModel;
        public AppointmentManagement()
        {
            InitializeComponent();
            viewModel= new AppointmentRecordViewModel();
            DataContext = viewModel;
        }
    }
}
