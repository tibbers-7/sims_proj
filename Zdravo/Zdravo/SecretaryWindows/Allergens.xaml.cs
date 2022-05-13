using System;
using System.Windows;
using Model;
using Zdravo.ViewModel;
using Service;
using System.Collections.ObjectModel;
using Repository;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for Allergens.xaml
    /// </summary>
    public partial class Allergens : Window
    {
        private AllergenViewModel allergenViewModel;
        private Patient patient;
        private AllergenRepository allergenRepository = new AllergenRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private PatientService patientService = new PatientService();
        public Allergens(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            allergenViewModel = new AllergenViewModel(patient);
            tbName.Text = patient.Ime;
            tbLastName.Text = patient.Prezime;
            tbId.Text = patient.Id.ToString();
            ObservableCollection<Allergen> allergens = allergenRepository.getAllAllergens();
            foreach (Allergen allergen in allergens)
            {
                comboBox.Items.Add(allergen.Name);
            }
            comboBox.SelectedIndex = 0;
            DataContext = allergenViewModel;
        }
        private void DescriptionClick(object sender, RoutedEventArgs e)
        {
            AllergenDescription allergenDescriptionWindow = new AllergenDescription((Allergen)table.SelectedValue);
            allergenDescriptionWindow.Show();
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            Allergen allergen =(Allergen) table.SelectedValue;
            patientService.removeAllergen(patient, allergen);
            allergenViewModel = new AllergenViewModel(this.patient);
            DataContext = null;
            DataContext = allergenViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (String)comboBox.SelectedValue;
            bool allergenAllreadyExists = false;
            foreach (Allergen allergen in patient.Allergens)
            {
                if (allergen.Name.ToLower().Equals(name.ToLower()))
                {
                    allergenAllreadyExists = true;
                }
            }
            if (allergenAllreadyExists) errorLabel.Content = "ERROR! It is already in a list";
            if (!allergenAllreadyExists)
            {
                addAllergenToPatient();
            }
        }
        private void addAllergenToPatient()
        {
            string name = (String)comboBox.SelectedValue;
            ObservableCollection<Allergen> Allergeni = allergenRepository.getAllAllergens();
            Allergen newAllergen = null;
            foreach (Allergen allergen in Allergeni)
            {
                if (allergen.Name.ToLower().Equals(name.ToLower())) { newAllergen = allergen; }
            }
            this.patient.Allergens.Add(newAllergen);
            patientRepository.updatePatient(this.patient);
            allergenViewModel = new AllergenViewModel(this.patient);
            this.DataContext = null;
            this.DataContext = allergenViewModel;
        }
    }
}
