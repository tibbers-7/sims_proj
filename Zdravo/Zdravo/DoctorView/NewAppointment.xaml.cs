using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zdravo.DoctorView;
using Zdravo.DoctorWindows;
using Zdravo.ViewModel;

namespace Zdravo
{
    /// <summary>
    /// Window with a form for adding a new user or updating existing one
    /// </summary>
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        private int apptId;

        public NewAppointment(DoctorHomeViewModel callerWindow, int apptId,int doctorId)
        {
            
            InitializeComponent();
            if (apptId == 0)
            {   // Ako je novi pregled
                patientButton.Content = "Izaberi pacijenta";

            }
            this.callerWindow = callerWindow;
            this.apptId = apptId;
            viewModel = new NewAppointmentViewModel(apptId, doctorId);
            DataContext = viewModel;   
        }
        
        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCode=viewModel.CreateAppointment();
            switch (errorCode)
            {
                case 0:
                    callerWindow.RefreshAppointments();
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Pacijent sa tim JMBG ne postoji.", "Greška");
                    break;

                case 2:
                    MessageBox.Show("Uneseni datum nije validan.", "Greška");
                    break;
                case 3:
                    MessageBox.Show("Vreme koje ste odabrali za zakazivanje termina je prošlo.", "Greška");
                    break;
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            if (apptId == 0)
            {
                viewModel.ChoosePatient();
                
            }
            else
            {
                viewModel.ShowChart(apptId);
                
            }
        }
    }
}
