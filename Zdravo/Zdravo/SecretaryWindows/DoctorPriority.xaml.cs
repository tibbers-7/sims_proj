using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Model;
using Repository;
using Controller;
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
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
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
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentRepository.GetAll());
            datePicker.SelectedDate = DateTime.Now;
            String selectedDate=datePicker.SelectedDate.ToString();
            String dateStringForParsing = selectedDate.Split(" ")[0];
            DateOnly dateonly = DateOnly.Parse(dateStringForParsing);
            foreach(Appointment appointment in appointments)
            {
                int doctorId = Int32.Parse(comboBoxDoctors.SelectedItem.ToString().Split("-")[0]);
                if (doctorId == appointment.Doctor)
                {
                    if (dateonly == appointment.Date)
                    {
                        busySlots.Items.Add(appointment.Date.ToString() + "   " + appointment.Time.ToString());
                    }
                }
            }
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

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            busySlots.Items.Clear();
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentRepository.GetAll());
            String selectedDate = datePicker.SelectedDate.ToString();
            String dateForParsing = selectedDate.Split(" ")[0];
            DateOnly dateonly = DateOnly.Parse(dateForParsing);
            int doctorId = Int32.Parse(comboBoxDoctors.SelectedItem.ToString().Split("-")[0]);
            foreach (Appointment appointment in appointments)
            {
                if (doctorId == appointment.Doctor && dateonly==appointment.Date)
                {
                        busySlots.Items.Add(appointment.Time.ToString()+"("+appointment.Duration.ToString()+" mins)");
                }
            }
            busySlots.SelectedIndex = 0;
        }
    }
}
