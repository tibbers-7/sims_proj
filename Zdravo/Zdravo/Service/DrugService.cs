using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Repository;

namespace Zdravo.Service
{
    public class DrugService
    {
        private DrugRepository drugRepo;
        private DrugReportRepository reportRepo;

        public DrugService(DrugRepository drugRepo,DrugReportRepository reportRepo)
        {
            this.drugRepo = drugRepo;
            this.reportRepo = reportRepo;
        }

        public void AddNew(Drug newDrug)
        {
            drugRepo.AddNew(newDrug);
        }

        public void Update(Drug newDrug)
        {
            drugRepo.Update(newDrug);
        }

        internal List<Drug> GetValidDrugs()
        {
            List<Drug> validDrugs = new List<Drug>();
            foreach (Drug drug in drugRepo.GetAll())
            {
                if (drug.Status != Zdravo.Status.denied) validDrugs.Add(drug);
            }
            return validDrugs;
        }

        internal List<Drug> GetAll()
        {
            return drugRepo.GetAll();
        }

        internal Drug GetById(int drugId)
        {
            return drugRepo.GetById(drugId);
        }

        internal int ChangeStatus(bool isAccepted, int drugId)
        {
            Drug drug = GetById(drugId);
            if (drug == null) return 1;
            if (isAccepted) drug.Status = Zdravo.Status.accepted;
            else drug.Status = Zdravo.Status.reported;

            return drugRepo.ChangeStatus(drug);
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            DrugReport report=new DrugReport() { DrugId = drugId, Reason=reason };
            reportRepo.AddNew(report);
        }

        internal ObservableCollection<Drug> SetAllergies(ObservableCollection<Drug> drugs, Patient patient)
        {
            if (patient.Allergens == null) return drugs;
            ObservableCollection<Drug> drugsUpdated = new ObservableCollection<Drug>();
            

            foreach (Drug drug in drugs)
            {
                drug.AllergenConflicts = new List<string>();
                drugsUpdated.Add(CompareDrugToAllergens(drug, patient));
            }

            return drugsUpdated;
        }

        private Drug CompareDrugToAllergens(Drug drug, Patient patient)
        {
            foreach (Allergen allergen in patient.Allergens)
            {
                drug=SetAllergicStatus(drug, allergen);
            }
            return drug;
        }

        private Drug SetAllergicStatus(Drug drug, Allergen allergen)
        {
            if (allergen.Name.ToLower().Equals(drug.Name.ToLower()))
            {
                drug.IsAllergic = true;
                drug.AllergenConflicts.Add(drug.Name);
            }
            else
            {
                foreach (string ingredient in drug.Ingredients)
                {
                    if (allergen.Name.ToLower().Equals(ingredient.ToLower()))
                    {
                        drug.IsAllergic = true;
                        drug.AllergenConflicts.Add(ingredient);
                    }
                }
            }
            return drug;
        }

        internal bool GetAllergenConflicts(int drugId, ObservableCollection<Drug> drugs)
        {
            foreach (Drug drugUpdated in drugs)
            {
                if (drugUpdated.Id == drugId) return drugUpdated.IsAllergic;
            }
            return false;
        }

    }
}
