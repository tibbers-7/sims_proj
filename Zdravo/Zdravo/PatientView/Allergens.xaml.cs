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
using Service;
using Zdravo.Model;
using System.Collections.ObjectModel;
using Zdravo.Repository;
using Repository;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for Allergens.xaml
    /// </summary>
    public partial class Allergens : Window
    {
        private AllergenViewModel viewModel;
        private Patient patient;
        public Allergens(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            viewModel = new AllergenViewModel(patient);
            tbName.Text = patient.Ime;
            tbLastName.Text = patient.Prezime;
            tbId.Text = patient.Id.ToString();
            AllergenRepository repo = new AllergenRepository();
            ObservableCollection<Allergen> Allergeni = repo.getAllAllergens();
            foreach (Allergen a in Allergeni)
            {
                comboBox.Items.Add(a.Name);
            }
            comboBox.SelectedIndex = 0;
            DataContext = viewModel;
        }
        private void DescriptionClick(object sender, RoutedEventArgs e)
        {
            AllergenDescription desc = new AllergenDescription((Allergen)table.SelectedValue);
            desc.Show();
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            PatientService service = new PatientService();
            Allergen allergen =(Allergen) table.SelectedValue;
            service.removeAllergen(patient, allergen);
            viewModel.Refresh();
            DataContext = null;
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (String)comboBox.SelectedValue;
            bool ima = false;
            foreach (Allergen a in patient.Allergens)
            {
                if (a.Name.ToLower().Equals(name.ToLower()))
                {
                    ima = true;

                }
            }
            if (ima) errorLabel.Content = "Izabrani alergen se vec nalazi u spisku";
            if (!ima)
            {
                AllergenRepository repo = new AllergenRepository();
                ObservableCollection<Allergen> Allergeni = repo.getAllAllergens();
                Allergen novi = null;
                foreach (Allergen a in Allergeni)
                {
                    if (a.Name.ToLower().Equals(name.ToLower())) { novi = a; }
                }
                Patient noviPatient = this.patient;
                noviPatient.Allergens.Add(novi);
                PatientRepository repos = new PatientRepository();
                repos.updatePatient(noviPatient);

                this.DataContext = null;
                this.DataContext = viewModel;
            }
        }
    }
}
