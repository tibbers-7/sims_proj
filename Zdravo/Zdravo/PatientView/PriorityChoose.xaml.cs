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

namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for PriorityChoose.xaml
    /// </summary>
    public partial class PriorityChoose : Window
    {
        public PriorityChoose()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cbPriority.SelectedIndex == 0)
            {
                DoctorPriority f = new DoctorPriority();
                f.Show();
                this.Close();
            }else if(cbPriority.SelectedIndex == 1)
            {
                DatePriority d = new DatePriority();
                d.Show();
                this.Close();
            }
        }
    }
}
