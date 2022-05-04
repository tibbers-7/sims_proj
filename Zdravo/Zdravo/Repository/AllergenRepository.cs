using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;
using System.Collections.ObjectModel;

namespace Zdravo.Repository
{
    public class AllergenRepository
    {
        private AllergenFileHandler filehandler;
        
        public AllergenRepository()
        {
            filehandler = new AllergenFileHandler();
        }
        public ObservableCollection<Allergen> getAllAllergens()
        {
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>();
            allergens = filehandler.Load();
            return allergens;
        }
    }
}
