using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using Model;

namespace Zdravo.Repository
{
    internal class ReportRepository
    {
        private ReportFileHandler fileHandler=new ReportFileHandler();
        public List<Report> reports;

        public ReportRepository()
        {
            reports = fileHandler.Read();
        }

        public List<Report> GetReports()
        {
            return reports;
        }

        public Report GetReportById(int id)
        {
            foreach (Report report in reports)
            {
                if (report.Id == id) return report;
            }
            return null;
        }

        public void AddReport(Report report)
        {
            report.Id = reports.Count + 1;
            fileHandler.Write(report,0);
        }

        internal void UpdateReport(Report report)
        {
            fileHandler.Write(report, 1);
            reports = fileHandler.Read();
        }
    }
}
