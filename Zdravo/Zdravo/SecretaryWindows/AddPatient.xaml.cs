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
using Zdravo.Controller;
using System.Text.RegularExpressions;

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
        private bool validateMail(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        private bool validateName(string s)
        {
            Regex regex = new Regex("^[A-Z][a-zA-Z]*$");
            return regex.IsMatch(s);
        }
        
        private bool validateNumbers(string s)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(s);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRepository repo = new PatientRepository();
            PatientController controller = new PatientController();
            //  repo.addPatient(controller.CreatePatient(tbIme, tbPrezime, Int16.Parse(tbId.Text), tbUsername, tbSifra, tbTelefon, tbDatum, cbPol, tbAdresa, checkBoxGuest, tbMail));
            patientsViewModel.Refresh();
            secretaryHomeWindow.DataContext = null;
            secretaryHomeWindow.DataContext = patientsViewModel;
            this.Close();

        }

        private void tbMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateMail(tbMail.Text);
            if (!result)
            {
                emailError.Text = "not valid email!";
            }
            if (result)
            {
                emailError.Text = "";
            }
        }

        private void tbIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateName(tbIme.Text);
            if (!result)
            {
                imeError.Text = "not valid name!";
            }
            if (result)
            {
                imeError.Text = "";
            }
        }

        private void tbPrezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateName(tbPrezime.Text);
            if (!result)
            {
                prezimeError.Text = "not valid lastname!";
            }
            if (result)
            {
                prezimeError.Text = "";
            }
        }

        private void tbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateNumbers(tbId.Text);
            if (!result)
            {
                idError.Text = "not valid ID!";
            }
            if (result)
            {
                idError.Text = "";
            }
        }
    }
}
