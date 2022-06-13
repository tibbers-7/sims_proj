using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Model;
using Repository;
using Controller;
using Zdravo.Controller;
using Zdravo.Repository;
using System.Text.RegularExpressions;

namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for DoctorPriority.xaml
    /// </summary>
    public partial class DoctorPriority : Window
    {
        private AppointmentController appointmentController;
        private AppointmentManagement appointmentManagementWindow;
        private  DoctorRepository doctorRepository = new DoctorRepository();
        public DoctorPriority(AppointmentManagement parentWindow)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            InitializeComponent();
            this.appointmentManagementWindow = parentWindow;
            foreach(Doctor doctor in doctorRepository.getAll())
            {
                comboBoxDoctors.Items.Add(doctor.Id+"-"+doctor.Name + " " + doctor.LastName+","+doctor.Specialization);
            }
            comboBoxDoctors.SelectedIndex = 0;
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentController.GetAll());
            datePicker.SelectedDate = DateTime.Now;
            String selectedDate=datePicker.SelectedDate.ToString();
            String dateStringForParsing = selectedDate.Split(" ")[0];
            DateOnly dateonly = DateOnly.Parse(dateStringForParsing);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = Int32.Parse(comboBoxDoctors.SelectedItem.ToString().Split("-")[0]);
            String jmbg = jmbgTb.Text;
            int patientId = Int32.Parse(jmbg);
            String selectedDate = datePicker.SelectedDate.ToString();
            String dateStringForParsing = selectedDate.Split(" ")[0];
            DateOnly.TryParse(selectedDate, out DateOnly date);
            appointmentController.CreateAppointment(patientId, doctorId,1, Int32.Parse(timeTb.Text.Split(":")[0]),Int32.Parse(timeTb.Text.Split(":")[1]), Int32.Parse(durationTb.Text),dateStringForParsing, false);
            this.appointmentManagementWindow.viewModel.Refresh();
            this.appointmentManagementWindow.DataContext = null;
            this.appointmentManagementWindow.DataContext = this.appointmentManagementWindow.viewModel;
            this.Close();
        }
        private bool validateNumbers(string s)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(s);
        }
        private void jmbgTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateNumbers(jmbgTb.Text);
            if (!result)
            {
                emailError.Text = "not valid jmbg!";
            }
            if (result)
            {
                emailError.Text = "";
            }
        }
    }
}
