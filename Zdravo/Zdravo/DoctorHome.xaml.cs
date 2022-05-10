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
using System.Windows.Threading;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for DoctorHome.xaml
    /// </summary>
    public partial class DoctorHome : Window
    {

        private DoctorHomeViewModel viewModel;
        public DoctorHome(int doctorId)
        {
            InitializeComponent();
            viewModel = new DoctorHomeViewModel(AppointmentTable,doctorId);
            DataContext = viewModel;
            
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NewAppointment();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();
        }



        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = AppointmentTable.SelectedItem;
            viewModel.MenuShow(int.Parse((AppointmentTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(0);
            MainWindow m = new MainWindow();
            m.Show();
            
           this.Close();
            
        }

        private void Referral_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void VacationButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
