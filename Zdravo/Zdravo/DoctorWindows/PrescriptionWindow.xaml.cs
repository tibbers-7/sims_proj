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

namespace Zdravo.DoctorWindows
{
    /// <summary>
    /// Interaction logic for PrescriptionWindow.xaml
    /// </summary>
    public partial class PrescriptionWindow : Window
    {
        private PrescriptionViewModel viewModel;
        public PrescriptionWindow(int id)
        {
            InitializeComponent();
            viewModel = new PrescriptionViewModel(id);
            DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.CheckAllergies())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Pacijent je alergičan na lek! Molimo Vas da odaberete drugi lek.", "Upozorenje");
            }
        }
    }
}
