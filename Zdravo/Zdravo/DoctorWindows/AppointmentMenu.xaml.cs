using Controller;
using Model;
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
        
        
        public AppointmentMenu(int id, DoctorHomeViewModel callerWindow)
        {
            this.id = id;
            this.callerWindow = callerWindow;
            apptController = new AppointmentController();
            InitializeComponent();
            if (!apptController.IsReportAvailable(id))
            {
                PrescriptionBtn.IsEnabled = false;
                ReportBtn.IsEnabled = false;
            }
            
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
            NewAppointment updateAppointment = new NewAppointment(callerWindow,id);
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
    }
}
