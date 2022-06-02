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
    }
}
