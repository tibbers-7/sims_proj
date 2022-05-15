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
using Zdravo.ViewModel;


namespace Zdravo.DoctorView
{
    /// <summary>
    /// Interaction logic for ReferralWindow.xaml
    /// </summary>
    public partial class ReferralWindow : Window
    {
        private ReferralViewModel viewModel;
        public ReferralWindow(int doctorId)
        {
            viewModel = new ReferralViewModel(doctorId);
            this.DataContext = viewModel;
            InitializeComponent();
            
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCode;
            if (surgery_rb.IsChecked == false && appt_tb.IsChecked == false) errorCode = 3;
            else errorCode=viewModel.ScheduleReferral();
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("Uspešno kreiran uput","Obaveštenje");
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Pacijent ne postoji!","Greška");
                    break;
                case 2:
                    MessageBox.Show("Trenutno ne postoji lekar te specijalizacije u sistemu!","Greška");
                    break;
                case 3:
                    MessageBox.Show("Niste uneli sve neophodne informacije!", "Greška");
                    break;
            }
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ChoosePatientShow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
