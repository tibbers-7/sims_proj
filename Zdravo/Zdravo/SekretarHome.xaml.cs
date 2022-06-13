using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Repository;
using Model;
using Service;
using Controller;
using Zdravo.ViewModel;
using Zdravo.PatientView;
using Zdravo.Controller;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for SekretarHome.xaml
    /// </summary>
    public partial class SekretarHome : Window
    {
        private PatientsViewModel viewModel = new PatientsViewModel();
        public SekretarHome()
        {
            InitializeComponent();
            // PatientRepository p = new PatientRepository();
            //   List<Patient> patients = p.GetAll();
            //  table.ItemsSource = patients;
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient izabran = (Patient)table.SelectedValue;
            PatientService service = new PatientService();
            service.checkId();
            AddPatient addp = new AddPatient(this);
            addp.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  PatientRepository p = new PatientRepository();
            //List<Patient> patients = p.GetAll();
            //table.ItemsSource = patients;
            viewModel.Refresh();
            this.DataContext = null;
             this.DataContext = viewModel;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Patient izabran = (Patient)table.SelectedValue;
            if (izabran != null)
            {
                PatientView.UpdatePatient update = new PatientView.UpdatePatient(izabran.Ime, izabran.Prezime, izabran.Id, izabran.KorisnickoIme, izabran.Lozinka, izabran.BrojTelefona, izabran.DatumRodjenja, izabran.pol, izabran.GuestNalog, izabran.Adresa, izabran.Mail,this);
                update.Show();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Patient izabran = (Patient)table.SelectedValue;
            PatientController controller = new PatientController();
            controller.DeletePatient(izabran);
            // PatientRepository p = new PatientRepository();
            //  List<Patient> patients = p.GetAll();
            //  table.ItemsSource = patients;
            viewModel.Refresh();
            this.DataContext = null;
            this.DataContext = viewModel;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SecretaryHome s = new SecretaryHome();
            s.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)table.SelectedValue;
            Allergens a = new Allergens(selectedPatient);
            a.Show();
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Patient selected=(Patient)table.SelectedValue;
            if (selected != null)
            {
                labelDateOfBirth.Text=selected.DatumRodjenja.ToString().Split(" ")[0];
                labelGuest.Text = selected.GuestNalog.ToString();
                labelMail.Text = selected.Mail;
                labelPassword.Text = selected.Lozinka;
                labelUsername.Text = selected.KorisnickoIme;
            }
        }
    }
}
