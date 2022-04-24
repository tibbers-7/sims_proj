using Controller;
using Model;
using Repo;
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
using Zdravo.ViewModel;

namespace Zdravo
{
    /// <summary>
    /// Window with a form for adding a new user or updating existing one
    /// </summary>
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;
        private DoctorHomeViewModel callerWindow;

        
        //when adding a new user id is 0
        public NewAppointment(DoctorHomeViewModel callerWindow, int id)
        {
            InitializeComponent();
            this.callerWindow = callerWindow;
            viewModel = new NewAppointmentViewModel(id);
            DataContext = viewModel;  

            
        }
        

        //Schedule btn
        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCode=viewModel.CreateAppointment();
            switch (errorCode)
            {
                case 0:
                    callerWindow.RefreshAppointments();
                    this.Close();
                    break;
                case 3:
                    MessageBox.Show("Uneseni datum nije validan.", "Greška");
                    break;
                case 4:
                    MessageBox.Show("Vreme koje ste odabrali za zakazivanje termina je prošlo.", "Greška");
                    break;
            }

        }

        //CLose btn
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ViewPatient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
