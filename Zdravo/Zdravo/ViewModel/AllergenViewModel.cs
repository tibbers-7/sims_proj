using System.Collections.ObjectModel;
using Service;
using Model;
using System.ComponentModel;
using Repository;

namespace Zdravo.ViewModel
{
    public class AllergenViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Allergen> allergens;
        private Patient patient;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Allergen> Allergens
        {
            get
            {
                return allergens;
            }
            set
            {
                if (allergens == value)
                    return;
                allergens = patient.Allergens;
                NotifyPropertyChanged("Allergens");
            }
        }
        public AllergenViewModel(Patient patient)
        {
            this.patient = patient;
            allergens = patient.Allergens;
        }

        public void Refresh()
        {
            PatientRepository patientRepository = new PatientRepository();
            ObservableCollection<Patient> patients = patientRepository.GetAll();
            foreach (Patient patientFromList in patients)
            {
                if (patientFromList.Id == patient.Id) allergens = patientFromList.Allergens;
            }
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
