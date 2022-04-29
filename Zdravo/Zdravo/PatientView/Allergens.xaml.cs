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
using Model;
using Zdravo.ViewModel;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for Allergens.xaml
    /// </summary>
    public partial class Allergens : Window
    {
        private AllergenViewModel viewModel;
        public Allergens(Patient patient)
        {
            InitializeComponent();
            viewModel= new AllergenViewModel(patient);
            tbName.Text = patient.Ime;
            tbLastName.Text = patient.Prezime;
            tbId.Text=patient.Id.ToString();
            DataContext = viewModel;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
