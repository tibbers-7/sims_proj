using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using System.Collections.ObjectModel;

namespace Zdravo.FileHandler
{
    public class AllergenFileHandler
    {
        private string filepath = "data/Allergens.txt";
        
        public AllergenFileHandler()
        {
        
        }

        public ObservableCollection<Allergen> Load()
        {
            // TODO: implement
            string[] lines = System.IO.File.ReadAllLines(filepath);
            ObservableCollection<Allergen> allergens= new ObservableCollection<Allergen>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split('|');
                Allergen a = new Allergen(Int32.Parse(ss[0]), ss[1], ss[2]);
                allergens.Add(a);
            }
            return allergens ;
        }
    }
}
