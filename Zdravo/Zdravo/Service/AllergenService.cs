using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Controller;
using System.Collections.ObjectModel;

namespace Zdravo.Service
{
    public class AllergenService
    {
        private AllergenController controller;
        public AllergenService()
        {
                controller = new AllergenController();  
        }
        public ObservableCollection<Allergen> GetAllergensByPatient(Patient p)
        {
            ObservableCollection<Allergen> allergens= new ObservableCollection<Allergen>();
            allergens=controller.GetAllergensByPatient(p);
            return allergens;
        }
    }
}
