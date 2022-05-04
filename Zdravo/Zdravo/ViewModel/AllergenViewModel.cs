using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Collections.ObjectModel;
using Zdravo.Model;
using Zdravo.Service;
using Model;
using System.ComponentModel;
using Zdravo.Repository;
using Repository;

namespace Zdravo.ViewModel
{
    public class AllergenViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<Allergen> allergens;
        private AllergenService service;
        private Patient patient;
        private AllergenRepository repo;
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
        public AllergenViewModel(Patient p)
        {
          //  service = new AllergenService();
            this.patient = p;
         //   repo=new AllergenRepository();
            allergens = patient.Allergens;
        }
        public void Refresh()
        {
            PatientRepository repo = new PatientRepository();
            ObservableCollection<Patient> patients=repo.GetAll();
            foreach(Patient pat in patients)
            {
                if (pat.Id == patient.Id) allergens = pat.Allergens;
            }
            //allergens = service.GetAllergensByPatient(patient);
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
