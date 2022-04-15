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

namespace Zdravo
{
    /// <summary>
    /// Window for interacting with the selected row of AppointmentTable
    /// NOT IMPLEMENTED
    /// </summary>
    public partial class AppointmentMenu : Window
    {
        public AppointmentMenu()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
