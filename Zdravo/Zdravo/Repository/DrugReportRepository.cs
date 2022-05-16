using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    public class DrugReportRepository
    {
        private List<DrugReport> drugReports;
        private DrugReportFileHandler fileHandler;

        public DrugReportRepository()
        {
            fileHandler = new DrugReportFileHandler();
            drugReports = fileHandler.Read();
        }

        public List<DrugReport> GetAll()
        {
            return drugReports;
        }
        public DrugReport GetById(int id)
        {
            foreach (DrugReport drugReport in drugReports)
            {
                if (drugReport.Id == id) return drugReport;
            }
            return null;
        }

        public void CreateDrugReport(DrugReport drugReport)
        {
            drugReport.Id = drugReports.Last().Id + 1;
            fileHandler.Write(drugReport, 0);
            drugReports = fileHandler.Read();
        }
    }
}
