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
using Repository;
using Model;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentManagement.xaml
    /// </summary>
    public partial class AppointmentManagement : Window
    {
        public AppointmentRecordViewModel viewModel;
        private AppointmentController appointmentController;
        public AppointmentManagement()
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            InitializeComponent();
            viewModel= new AppointmentRecordViewModel();
            DataContext = viewModel;
        }


        private void CancelAppointment(object sender, RoutedEventArgs e)
        { 
                AppointmentRecord selectedRecord = (AppointmentRecord)table.SelectedValue;
                appointmentController.DeleteAppointment(selectedRecord.Id);
                viewModel = new AppointmentRecordViewModel();
                DataContext = null;
                DataContext = viewModel;
     
        }

        private void EditAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentRecord selectedRecord = (AppointmentRecord)table.SelectedValue;
            Appointment appointment = appointmentController.GetAppointment(selectedRecord.Id);
            EditAppointmentDate editAppointmentDateWindow = new EditAppointmentDate(this, appointment);
            editAppointmentDateWindow.Show();

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            SecretaryHome secretaryHomeWindow = new SecretaryHome();
            secretaryHomeWindow.Show();
            this.Close();
        }

        private void newAppointmentClick(object sender, RoutedEventArgs e)
        {
            DoctorPriority doctorPriorityWindow = new DoctorPriority(this);
            doctorPriorityWindow.Show();
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            if (!searchTb.Text.Equals(""))
            {
                viewModel = new AppointmentRecordViewModel();
                ObservableCollection<AppointmentRecord> foundRecords = new ObservableCollection<AppointmentRecord>();
                foreach (AppointmentRecord record in viewModel.Records)
                {
                    if (record.Jmbg.Equals(searchTb.Text)) foundRecords.Add(record);
                }
                viewModel = new AppointmentRecordViewModel(foundRecords);
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
    }
}
