using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Repository
{
    internal class DrugRepository
    {
        private List<string> drugs;
        public List<string> Drugs { get { return drugs; } set { drugs = value; } }

        public DrugRepository()
        {
            drugs = new List<string>() { "AMOXICILLIN","FEBRICET","PANKLAV","BETAKLAV","SINACILIN","MINIRIN","ASPIRIN","BRUFEN"};
        }

        public void AddDrug(string drugName)
        {
            drugs.Add(drugName);
        }

        public List<string> GetAllDrugs()
        {
            return drugs;
        }
    }
}
