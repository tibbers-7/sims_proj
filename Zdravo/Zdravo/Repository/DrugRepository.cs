using System;
using System.Collections.Generic;
using Zdravo.FileHandler;
using Model;

namespace Zdravo.Repository
{
    public class DrugRepository
    {
        private List<Drug> drugs;
        private readonly DrugFileHandler fileHandler=new DrugFileHandler();
        private int errorCode;

        public DrugRepository()
        {
            InitDrugs();
        }

        private void InitDrugs()
        {
            List<object> drugList=fileHandler.Read();
            drugs = new List<Drug>();
            foreach (object drugObj in drugList)
            {
                Drug drug = (Drug)drugObj;
                drugs.Add(drug);
            }
        }

        public int AddNew(Drug drug)
        {
            List<Drug> list = drugs;
            int listCount = list.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = list[i].ToCSV();
            }
            newLines[listCount] = drug.ToCSV();
            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        public int Update(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id) newLines[i] = drug.ToCSV();
                else newLines[i] = newDrug.ToCSV();
                i++;
            }
            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        public int Delete(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];

            newLines = new string[listCount - 1];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id) newLines[i] = drug.ToCSV();
                i++;
            }

            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        public List<Drug> GetAll()
        {
            return drugs;
        }


        internal Drug GetById(int drugId)
        {
            foreach(Drug drug in drugs)
            {
                if (drug.Id == drugId) return drug;
            }
            return null;
        }

        internal int ChangeStatus(Drug drug)
        {
            return Update(drug);
        }

    }
}
