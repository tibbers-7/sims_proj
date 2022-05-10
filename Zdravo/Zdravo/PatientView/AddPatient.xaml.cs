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
        private PatientsViewModel patientsViewModel = new PatientsViewModel();
        private SekretarHome secretaryHomeWindow = new SekretarHome();
        public AddPatient(SekretarHome secretaryHomeWindow)
        {
            InitializeComponent();
            PatientService service = new PatientService();
            this.secretaryHomeWindow = secretaryHomeWindow;
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
            patientsViewModel.Refresh();
            secretaryHomeWindow.DataContext = null;
            secretaryHomeWindow.DataContext = patientsViewModel;
            this.Close();

        }
    }
}
