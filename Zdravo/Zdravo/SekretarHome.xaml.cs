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
            DataContext = viewModel;
        }

 

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Refresh();
            this.DataContext = null;
            this.DataContext = viewModel;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)table.SelectedValue;
            if (selectedPatient != null)
            {
                PatientView.UpdatePatient updateWindow = new PatientView.UpdatePatient(selectedPatient.Ime, selectedPatient.Prezime, selectedPatient.Id, selectedPatient.KorisnickoIme, selectedPatient.Lozinka, selectedPatient.BrojTelefona, selectedPatient.DatumRodjenja, selectedPatient.pol, selectedPatient.GuestNalog, selectedPatient.Adresa, selectedPatient.Mail, this);
                updateWindow.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)table.SelectedValue;
            PatientController patientController = new PatientController();
            patientController.DeletePatient(selectedPatient);
            viewModel.Refresh();
            this.DataContext = null;
            this.DataContext = viewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SecretaryHome secretaryHomeWindow = new SecretaryHome();
            secretaryHomeWindow.Show();
            this.Close();
        }

        private void Allergens_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)table.SelectedValue;
            Allergens allergensWindow = new Allergens(selectedPatient);
            allergensWindow.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Patient izabran = (Patient)table.SelectedValue;
            PatientService service = new PatientService();
            service.checkId();
            AddPatient addp = new AddPatient(this);
            addp.Show();
        }
    }
}