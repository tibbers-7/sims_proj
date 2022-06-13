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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;
using System.Data;

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
            int index = comboBoxJezik.SelectedIndex;
            string selected = comboBoxJezik.SelectedValue.ToString();
            if (index == 0)
            {
                vacationLabel.Text = "Vacations";
                meetingsLabel.Text = "Meetings";
                ordersLabel.Text = "Orders";
                patientsLabel.Text = "Patients";
                appsLabel.Text = "Appointments";
                accountsLabel.Text = " Report";
                logOutButton.Content = "Log out";
                comboBoxJezik.SelectedIndex = 0;
            }
            else if (index == 1)
            {
                vacationLabel.Text = "  Odmori";
                meetingsLabel.Text = "Sastanci";
                ordersLabel.Text = "Porudzbine";
                patientsLabel.Text = "Pacijenti";
                appsLabel.Text = "   Pregledi";
                accountsLabel.Text = " Izvestaj";
                logOutButton.Content = "Odjavi se";
                comboBoxJezik.SelectedIndex = 1;
            }
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

        private void Meetings_Click(object sender, RoutedEventArgs e)
        {
            MeetingsWindow meetingsWindow = new MeetingsWindow();
            meetingsWindow.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index=comboBoxJezik.SelectedIndex;
            string selected = comboBoxJezik.SelectedValue.ToString();
            if (index == 0) {
                vacationLabel.Text = "Vacations";
                meetingsLabel.Text = "Meetings";
                ordersLabel.Text = "Orders";
                patientsLabel.Text = "Patients";
                appsLabel.Text = "Appointments";
                accountsLabel.Text = " Report";
                logOutButton.Content = "Log out";
                comboBoxJezik.SelectedIndex = 0;
            }
            else if (index == 1)
            {
                vacationLabel.Text = "  Odmori";
                meetingsLabel.Text = "Sastanci";
                ordersLabel.Text = "Porudzbine";
                patientsLabel.Text = "Pacijenti";
                appsLabel.Text = "   Pregledi";
                accountsLabel.Text = " Izvestaj";
                logOutButton.Content = "Odjavi se";
                comboBoxJezik.SelectedIndex = 1;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            datePick datePickWindow = new datePick();
            datePickWindow.Show();
        }
    }
}
