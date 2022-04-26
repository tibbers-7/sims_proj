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
using Service;
using Repository;
using Controller;
using Zdravo.ViewModel;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        private PatientsViewModel viewModel = new PatientsViewModel();
        public AddPatient()
        {
            InitializeComponent();
            PatientService service = new PatientService();
            tbId.Text = service.checkId();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRepository repo = new PatientRepository();
            PatientController controller = new PatientController();
            repo.addPatient(controller.CreatePatient(tbIme, tbPrezime, Int16.Parse(tbId.Text), tbUsername, tbSifra, tbTelefon, tbDatum, cbPol, tbAdresa, checkBoxGuest, tbMail));
            this.Close();
            viewModel.Refresh();
        }
    }
}
