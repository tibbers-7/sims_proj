using Controller;
using System.Windows;
using Zdravo.Controller;
using Zdravo.DoctorWindows;
using Zdravo.ViewModel;

namespace Zdravo
{
    /// <summary>
    /// Window for interacting with the selected row of AppointmentTable
    /// NOT IMPLEMENTED
    /// </summary>
    /// 
    public partial class AppointmentMenu : Window
    {
        private int id;
        private DoctorHomeViewModel callerWindow;
        AppointmentController apptController;
        private int doctorId;
        
        
        public AppointmentMenu(int id, DoctorHomeViewModel callerWindow,int doctorId)
        {
            this.id = id;
            this.callerWindow = callerWindow;
            this.doctorId = doctorId;
            var app = Application.Current as App;
            apptController = app.appointmentController;
            InitializeComponent();
            ChangeMenuItems();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool success=apptController.DeleteAppointment(id);
            if (success)
            {
                callerWindow.RefreshAppointments();
                this.Close();
            }
            else
            {
                MessageBox.Show("Can't delete", "Error");
            }
            
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            NewAppointment updateAppointment = new NewAppointment(callerWindow,id,doctorId,true);
            updateAppointment.Show();
            this.Close();
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
                ReportWindow reportWindow = new ReportWindow(id,0,0,null);
                reportWindow.Show();
 
        }

        private void Prescription_Click(object sender, RoutedEventArgs e)
        {
                PrescriptionWindow prescriptionWindow = new PrescriptionWindow(id);
                prescriptionWindow.Show();
            
        }

        private void ChangeMenuItems()
        {
            if (!apptController.IsReportAvailable(id))
            {
                PrescriptionBtn.IsEnabled = false;
                ReportBtn.IsEnabled = false;
                prescLabel.IsEnabled = false;
                reportLabel.IsEnabled = false;
            }
            else
            {
                UpdateBtn.IsEnabled = false;
                updateLabel.IsEnabled=false;
            }
        }
    }
}
