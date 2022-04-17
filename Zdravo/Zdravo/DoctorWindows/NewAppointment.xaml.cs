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

namespace Zdravo
{
    /// <summary>
    /// Window with a form for adding a new user or updating existing one
    /// </summary>
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;

        
        //when adding a new user id is 0
        public NewAppointment(int id)
        {
            InitializeComponent();
            viewModel = new NewAppointmentViewModel(id);
            DataContext = viewModel;  

            
        }
        

        //Schedule btn
        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            bool success=viewModel.CreateAppointment();
            if (success)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Pacijent sa JMBG: "+patientId_tb.Text+" ne postoji.", "Error");
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
