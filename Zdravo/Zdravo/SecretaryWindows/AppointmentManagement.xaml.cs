using System.Windows;
using Zdravo.ViewModel;
using System.Collections.ObjectModel;
using Controller;
using Model;
using Zdravo.SecretaryWindows;
using Repository;
using Zdravo.Controller;

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

        private void EmergencyAppointmentClick(object sender, RoutedEventArgs e)
        {
            EmergencyAppointmentWindow emergencyAppointmentWindow = new EmergencyAppointmentWindow();
            emergencyAppointmentWindow.Show();
            this.Close();
        }
    }
}
