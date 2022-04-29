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
                // allergens = service.GetAllergensByPatient(patient);
                //   List<Allergen> allergeniSvi = new List<Allergen>();
                //   allergeniSvi = repo.getAllAllergens();
                // ObservableCollection<Allergen> ali = new ObservableCollection<Allergen>();
                //  ali.Add(new Allergen(1, "ime", "opis"));
                //  foreach(Allergen a in allergeniSvi)
                //  {
                //      ali.Add(a);
                //   }
                allergens = patient.Allergens;
                   NotifyPropertyChanged("Allergens");
            }
        }
        public AllergenViewModel(Patient p)
        {
            service = new AllergenService();
            this.patient = p;
            repo=new AllergenRepository();
            allergens = patient.Allergens;
        }
        public void Refresh()
        {
            allergens = service.GetAllergensByPatient(patient);
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
