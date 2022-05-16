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
using Repository;
using System.Collections.ObjectModel;
using Model;
using Controller;
using Zdravo.PatientView;
namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for EmergencyAppointmentWindow.xaml
    /// </summary>
   
    public partial class EmergencyAppointmentWindow : Window
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private AppointmentController appointmentController;
        public EmergencyAppointmentWindow()
        {
            InitializeComponent();
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            createAccountButton.Visibility= Visibility.Collapsed;
            ObservableCollection<Doctor> doctors = doctorRepository.getAll();
            foreach(Doctor doctor in doctors)
            {
                comboBoxSpecializations.Items.Add(doctor.Specialization);
            }
            comboBoxSpecializations.SelectedIndex = 0;
        }

        private void jmbgChangedEvent(object sender, TextChangedEventArgs e)
        {
            PatientRepository patientRepository = new PatientRepository();
            bool found = false;
            ObservableCollection<Patient> patients = patientRepository.GetAll();
            if (jmbgTextBox.Text != "")
            {
                foreach (Patient patient in patients)
                {
                    if (patient.Id == int.Parse(jmbgTextBox.Text))
                    {
                        found = true;
                    }
                }
            }
            if (found)
            {
                foundLabel.Foreground = Brushes.Green;
                foundLabel.Content = "Patient found.";
                createAccountButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                foundLabel.Foreground = Brushes.Red;
                foundLabel.Content = "Patient not found,please create new account.";
                createAccountButton.Visibility = Visibility.Visible;
            }
        }

        private void createAccountClick(object sender, RoutedEventArgs e)
        {
            AddPatient addPatientWindow = new AddPatient(new SekretarHome());
            addPatientWindow.Show();
        }

        private void okButtonClick(object sender, RoutedEventArgs e)
        {
            doctorRepository = new DoctorRepository();
            ObservableCollection<Doctor> doctors = doctorRepository.getAll();
            Doctor selectedDoctor = new Doctor();
            foreach(Doctor doctor in doctors)
            {
                if (doctor.Specialization == comboBoxSpecializations.SelectedItem.ToString()) selectedDoctor = doctor;
            }
            String jmbg = jmbgTextBox.Text;
            int patientId = Int32.Parse(jmbg);
            String selectedDate =DateTime.Now.AddMinutes(5).ToString();   
            String dateStringForParsing = selectedDate.Split(" ")[0];
            DateOnly.TryParse(selectedDate, out DateOnly date);
            String timeTb= selectedDate.Split(" ")[1];
            appointmentController.CreateAppointment(patientId, selectedDoctor.Id, 1, Int32.Parse(timeTb.Split(":")[0]), Int32.Parse(timeTb.Split(":")[1]), 60, dateStringForParsing, false);
            AppointmentManagement appointmentManagementWindow = new AppointmentManagement();
            appointmentManagementWindow.Show();
            this.Close();
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            AppointmentManagement appointmentManagementWindow = new AppointmentManagement();
            appointmentManagementWindow.Show();
            this.Close();
        }
    }
}
