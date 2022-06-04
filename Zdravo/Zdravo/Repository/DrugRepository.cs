using System;
using System.Collections.Generic;
using Zdravo.FileHandler;
using Model;

namespace Zdravo.Repository
{
    public class DrugRepository
    {
        private List<Drug> drugs;
        public List<Drug> Drugs { get { return drugs; } set { drugs = value; } }
        private DrugFileHandler fileHandler=new DrugFileHandler();

        public DrugRepository()
        {
            initDrugs();
        }

        private void initDrugs()
        {
            List<object> drugList=fileHandler.Read();
            drugs = new List<Drug>();
            foreach (object drugObj in drugList)
            {
                Drug drug = (Drug)drugObj;
                drugs.Add(drug);
            }
        }

        public void AddNew(Drug drug)
        {
            List<Drug> list = drugs;
            int listCount = list.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = list[i].ToCSV();
            }
            newLines[listCount] = drug.ToCSV();
            fileHandler.Write(newLines);
        }

        public void Update(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id)
                {
                    newLines[i] = drug.ToCSV();
                    
                }
                else newLines[i] = newDrug.ToCSV();
                i++;
            }
            fileHandler.Write(newLines);
            initDrugs();
        }

        public bool Delete(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];

            newLines = new string[listCount - 1];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id)
                {
                    newLines[i] = drug.ToCSV();
                    i++;
                }
            }

            fileHandler.Write(newLines);
            initDrugs();
            return true;
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

        internal bool ChangeStatus(bool isAccepted, int drugId)
        {
            Drug selectedDrug=null;
            foreach (Drug drug in drugs)
            {
                if (drug.Id == drugId)
                {
                    if (isAccepted) drug.Status = Zdravo.Status.accepted;
                    else drug.Status = Zdravo.Status.reported;
                    selectedDrug = drug;
                    break;
                }
            }
            if (selectedDrug == null) return false;
            Update(selectedDrug);
            return true;
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
            initDrugs();
            foreach(Drug drug in drugs)
            {
                if (drug.Status!=Zdravo.Status.denied) validDrugs.Add(drug);
            }
            return validDrugs;
        }
    }
}
