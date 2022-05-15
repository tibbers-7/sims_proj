using System;
using System.Collections.Generic;
using FileHandler;
using Model;

namespace Repository
{
    public class DrugRepository
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

        internal Drug GetById(int drugId)
        {
            foreach(Drug drug in drugs)
            {
                if (drug.Id == drugId) return drug;
            }
            return null;
        }

        internal void ChangeStatus(bool isAccepted, int drugId)
        {
            Drug selectedDrug=null;
            foreach (Drug drug in drugs)
            {
                if (drug.Id == drugId)
                {
                    if (isAccepted) drug.Status = Zdravo.Status.accepted;
                    else drug.Status = Zdravo.Status.denied;
                    selectedDrug = drug;
                }
            }
            fileHandler.Write(selectedDrug, 1);
        }

        internal Drug GetByName(string selectedDrug)
        {
            foreach (Drug drug in drugs)
            {
                if (drug.Name.Equals(selectedDrug)) return drug;
            }
            return null;
        }

        internal List<Drug> GetValidDrugs()
        {
            List<Drug> validDrugs=new List<Drug>();
            foreach(Drug drug in drugs)
            {
                if (drug.Status!=Zdravo.Status.denied) validDrugs.Add(drug);
            }
            return validDrugs;
        }
    }
}
