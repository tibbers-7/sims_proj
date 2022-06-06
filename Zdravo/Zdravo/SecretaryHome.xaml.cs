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
            SekretarHome s=new SekretarHome();
            s.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppointmentManagement am = new AppointmentManagement();
            am.Show();
            this.Close();
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            this.Close();
        }

        private void Vacations_Click(object sender, RoutedEventArgs e)
        {
            VacationsWindow vacationsWindow = new VacationsWindow();
            vacationsWindow.Show();
            this.Close();
        }
    }
}
