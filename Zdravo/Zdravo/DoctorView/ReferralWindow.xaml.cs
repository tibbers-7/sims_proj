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
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            int errorCode=viewModel.ScheduleReferral();
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
            }
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowChart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
