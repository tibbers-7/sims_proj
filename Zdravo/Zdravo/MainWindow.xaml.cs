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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Service;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimeService timeService = new TimeService();
            Thread thread = new Thread(new ThreadStart(timeService.ThreadFunction));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            string[] lines = System.IO.File.ReadAllLines("data/accounts.txt");
            foreach (string line in lines)
            {
                string[] parameters = line.Split(',');
                String password = tbPassword.Password.ToString();
                if (tbUsername.Text.Equals(parameters[0]) && password.Equals(parameters[1]))
                {
                    found = true;
                    if (parameters[2].Equals("S"))
                    {
                        SecretaryHome secretaryWindow = new SecretaryHome();
                        secretaryWindow.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("U"))
                    {
                        ManagerHome managerWindow = new ManagerHome();
                        managerWindow.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("L"))
                    {
                        DoctorHome doctorWindow = new DoctorHome(int.Parse(parameters[3]));
                        doctorWindow.Show();
                        this.Close();
                    }
                }

            }
            if (!found)
            {
                errorLabel.Content = "Pogresno korisnicko ime ili lozinka!";
            }
        }
    }
}
