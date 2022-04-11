using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Repository;
using Controller;
using Service;

namespace ZdravoCorporation
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
   
        public MainWindow1()
        {
           
        InitializeComponent();
         PatientRepository p = new PatientRepository();
            List<Patient> patients = p.GetAll();
            tabela.ItemsSource = patients;
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            
            Patient izabran = (Patient)tabela.SelectedValue;
            PatientController controller = new PatientController();
            controller.DeletePatient(izabran);
            PatientRepository p = new PatientRepository();
            List<Patient> patients = p.GetAll();
            tabela.ItemsSource = patients;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            string id = null;
            Patient izabran = (Patient)tabela.SelectedValue;
            PatientService service = new PatientService();
            service.checkId();
            AddPatient addp = new AddPatient(id);
            addp.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Patient izabran = (Patient)tabela.SelectedValue;
            if (izabran != null)
            {
                UpdatePatient update = new UpdatePatient(izabran.Ime, izabran.Prezime, izabran.Id, izabran.KorisnickoIme, izabran.Lozinka, izabran.BrojTelefona, izabran.DatumRodjenja, izabran.pol, izabran.GuestNalog, izabran.Adresa, izabran.Mail);
                update.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRepository p = new PatientRepository();
            List<Patient> patients = p.GetAll();
            tabela.ItemsSource = patients;
        }
    }
}
