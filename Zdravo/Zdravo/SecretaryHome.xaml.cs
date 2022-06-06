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
using Zdravo.PatientView;
using Zdravo.SecretaryWindows;
namespace Zdravo
{
    /// <summary>
    /// Interaction logic for SecretaryHome.xaml
    /// </summary>
    public partial class SecretaryHome : Window
    {
        public SecretaryHome()
        {
            InitializeComponent();
        }

        private void PatientsWindowClick(object sender, RoutedEventArgs e)
        {
            SekretarHome patientsWindow = new SekretarHome();
            patientsWindow.Show();
            this.Close();
        }


        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            AppointmentManagement appointmentsWindow = new AppointmentManagement();
            appointmentsWindow.Show();
            this.Close();
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            this.Close();
        }

        private void VacationsClick(object sender, RoutedEventArgs e)
        {
            VacationsWindow vacationsWindow=new VacationsWindow();
            vacationsWindow.Show();
            this.Close();
        }

        private void MeetingsClick(object sender, RoutedEventArgs e)
        {
            MeetingsWindow meetingsWindow = new MeetingsWindow();
            meetingsWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
