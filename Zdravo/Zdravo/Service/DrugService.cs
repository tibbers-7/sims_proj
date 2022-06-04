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
            return drugRepo.GetValidDrugs();
        }

        internal List<Drug> GetAllDrugs()
        {
            return drugRepo.GetAllDrugs();
        }

        internal Drug GetById(int drugId)
        {
            return drugRepo.GetById(drugId);
        }

        public Drug GetByName(string selectedDrug)
        {
            return drugRepo.GetByName(selectedDrug);
        }

        internal bool ChangeStatus(bool isAccepted, int drugId)
        {
            return drugRepo.ChangeStatus(isAccepted, drugId);
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            DrugReport report=new DrugReport() { DrugId = drugId, Reason=reason };
            reportRepo.AddNew(report);
        }

        public List<DrugReport> GetAllReports() {
            return reportRepo.GetAll();
        }

        public List<string> GetAllDrugNames()
        {
            return drugRepo.GetAllDrugNames();
        }

        public void DeleteReport(int id)
        {
            reportRepo.Delete(id);
        }
    }
}
