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
        private AppointmentManagement appointmentManagementWindow;
        private Appointment appointment;
        private AppointmentController appointmentController;
        public EditAppointmentDate(AppointmentManagement parentWindow,Appointment appointment)
        {
            InitializeComponent();
            this.appointmentManagementWindow = parentWindow;
            this.appointment = appointment;
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            String datePickerString = datePicker.SelectedDate.ToString();
            String dateStringForParsing = datePickerString.Split(" ")[0];
            appointmentController.UpdateAppointment(appointment.Id, appointment.Patient, appointment.Doctor, 1, Int32.Parse(timeTb.Text.Split(":")[0]), Int32.Parse(timeTb.Text.Split(":")[1]), appointment.Duration, Int32.Parse(dateStringForParsing.Split("/")[1]), Int32.Parse(dateStringForParsing.Split("/")[0]), Int32.Parse(dateStringForParsing.Split("/")[2]), false);
            this.appointmentManagementWindow.viewModel.Refresh();
            this.appointmentManagementWindow.DataContext = null;
            this.appointmentManagementWindow.DataContext = this.appointmentManagementWindow.viewModel;
            this.Close();
        }
    }
}
