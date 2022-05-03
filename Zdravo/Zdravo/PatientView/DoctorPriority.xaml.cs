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
using Repo;
using System.Collections.ObjectModel;
using Model;
using Zdravo.Model;
using Repository;
using Controller;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for DoctorPriority.xaml
    /// </summary>
    public partial class DoctorPriority : Window
    {
        private AppointmentManagement ap;
        public DoctorPriority(AppointmentManagement am)
        {
            InitializeComponent();
            this.ap = am;
            DoctorRepository d = new DoctorRepository();
            AppointmentRepository a=new AppointmentRepository();
            foreach(Doctor doctor in d.getAll())
            {
                comboBoxDoctors.Items.Add(doctor.Id+"-"+doctor.Name + " " + doctor.LastName+","+doctor.Specialization);
            }
            comboBoxDoctors.SelectedIndex = 0;
            ObservableCollection<Appointment> appointments = a.GetAll();
            datePicker.SelectedDate = DateTime.Now;
            String date=datePicker.SelectedDate.ToString();
            String datee = date.Split(" ")[0];
            DateOnly dateonly = DateOnly.Parse(datee);
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
            String date = datePicker.SelectedDate.ToString();
            String datee = date.Split(" ")[0];
            AppointmentController appointmentController = new AppointmentController();
            //  (int patientId, int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
            appointmentController.CreateAppointment(patientId, doctorId,1, Int32.Parse(timeTb.Text.Split(":")[0]),Int32.Parse(timeTb.Text.Split(":")[1]), Int32.Parse(durationTb.Text),Int32.Parse( datee.Split("/")[1]), Int32.Parse(datee.Split("/")[0]),Int32.Parse(datee.Split("/")[2]), false);
            this.ap.viewModel.Refresh();
            this.ap.DataContext = null;
            this.ap.DataContext = this.ap.viewModel;
            this.Close();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            busySlots.Items.Clear();
            AppointmentRepository a = new AppointmentRepository();
            ObservableCollection<Appointment> appointments = a.GetAll();
            String date = datePicker.SelectedDate.ToString();
            String datee = date.Split(" ")[0];
            DateOnly dateonly = DateOnly.Parse(datee);
            int doctorId = Int32.Parse(comboBoxDoctors.SelectedItem.ToString().Split("-")[0]);
            foreach (Appointment appointment in appointments)
            {
                
                if (doctorId == appointment.Doctor)
                {
                    if (dateonly == appointment.Date)
                    {
                        busySlots.Items.Add(appointment.Time.ToString()+"("+appointment.Duration.ToString()+" mins)");
                    }
                }
            }
            busySlots.SelectedIndex = 0;
        }
    }
}
