using Model;
using Repository;
using System;
using System.Collections.Generic;
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

        internal void ChangeStatus(bool isAccepted, int drugId)
        {
            drugRepo.ChangeStatus(isAccepted, drugId);
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            DrugReport report=new DrugReport() { DrugId = drugId, Reason=reason };
            reportRepo.CreateDrugReport(report);
        }
    }
}
