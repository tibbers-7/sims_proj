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
using Zdravo.Model;
using System.Collections.ObjectModel;
using Controller;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!searchTb.Text.Equals(""))
            {
                viewModel = new AppointmentRecordViewModel();
                string jmbg = searchTb.Text;
                ObservableCollection<AppointmentRecord> recordi = new ObservableCollection<AppointmentRecord>();
                foreach (AppointmentRecord record in viewModel.Records)
                {
                    if (record.Jmbg.Equals(jmbg)) recordi.Add(record);
                }
                viewModel = new AppointmentRecordViewModel(recordi);
                DataContext = null;
                DataContext = viewModel;
            }
            else
            {
                viewModel = new AppointmentRecordViewModel();
                DataContext = null;
                DataContext = viewModel;
            }
        }

        private void CancelAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentController ac = new AppointmentController();
            AppointmentRecord selected = (AppointmentRecord)table.SelectedValue;
            ac.DeleteAppointment(selected.Id);
            
                viewModel = new AppointmentRecordViewModel();
                string jmbg = selected.Jmbg;
                ObservableCollection<AppointmentRecord> recordi = new ObservableCollection<AppointmentRecord>();
                foreach (AppointmentRecord record in viewModel.Records)
                {
                    if (record.Jmbg.Equals(jmbg)) recordi.Add(record);
                }
                viewModel = new AppointmentRecordViewModel(recordi);
                DataContext = null;
                DataContext = viewModel;
     
        }

        private void EditAppointment(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecretaryHome s = new SecretaryHome();
            s.Show();
            this.Close();
        }
    }
}
