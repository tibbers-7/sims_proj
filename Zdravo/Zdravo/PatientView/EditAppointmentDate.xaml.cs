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
using Controller;
using Model;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for EditAppointmentDate.xaml
    /// </summary>
    public partial class EditAppointmentDate : Window
    {
        private AppointmentManagement am;
        private Appointment appointment;
        public EditAppointmentDate(AppointmentManagement m,Appointment appointment)
        {
            InitializeComponent();
            this.am = m;
            this.appointment = appointment;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppointmentController appointmentController = new AppointmentController();
            String date = datePicker.SelectedDate.ToString();
            String datee = date.Split(" ")[0];
            //  (int patientId, int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
            appointmentController.UpdateAppointment(appointment.Id,appointment.Patient,appointment.Doctor, 1, Int32.Parse(timeTb.Text.Split(":")[0]), Int32.Parse(timeTb.Text.Split(":")[1]),appointment.Duration, Int32.Parse(datee.Split("/")[1]), Int32.Parse(datee.Split("/")[0]), Int32.Parse(datee.Split("/")[2]), false);
            this.am.viewModel.Refresh();
            this.am.DataContext = null;
            this.am.DataContext = this.am.viewModel;
            this.Close();
        }
    }
}
