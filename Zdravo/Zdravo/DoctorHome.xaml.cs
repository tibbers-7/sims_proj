using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zdravo.ViewModel;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for DoctorHome.xaml
    /// </summary>
    public partial class DoctorHome : Window
    {
       
        private DoctorHomeViewModel viewModel=new DoctorHomeViewModel();
        public DoctorHome()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NewAppointment();
        }

        

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = AppointmentTable.SelectedItem;
            viewModel.MenuShow(int.Parse((AppointmentTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        

    }
}
