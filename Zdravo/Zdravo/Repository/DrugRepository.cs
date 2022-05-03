using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    internal class DrugRepository
    {
        private List<Drug> drugs;
        public List<Drug> Drugs { get { return drugs; } set { drugs = value; } }
        private DrugFileHandler fileHandler=new DrugFileHandler();

        public DrugRepository()
        {
            drugs = fileHandler.Read();
        }

        public List<Drug> GetAllDrugs()
        {
            return drugs;
        }

        internal List<string> GetAllDrugNames()
        {
            List<string> names = new List<string>();
            foreach(Drug drug in drugs)
            {
                names.Add(drug.Name);
            }
            return names;
        }

        internal Drug GetByName(string selectedDrug)
        {
            foreach (Drug drug in drugs)
            {
                if (drug.Name.Equals(selectedDrug)) return drug;
            }
            return null;
        }
    }
}
