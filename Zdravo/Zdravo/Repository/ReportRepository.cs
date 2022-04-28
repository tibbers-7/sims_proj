using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    internal class ReportRepository
    {
        private ReportFileHandler fileHandler=new ReportFileHandler();
        public List<Report> apptReports;
        private int reportCount;

        public ReportRepository()
        {
            apptReports = fileHandler.Read();
            reportCount = apptReports.Count;
        }

        public List<Report> GetReports()
        {
            return apptReports;
        }

        public Report GetReportById(int id)
        {
            foreach (Report report in apptReports)
            {
                if (report.Id == id) return report;
            }
            return null;
        }

        public void AddReport(Report report)
        {
            reportCount=apptReports.Count+1;
            report.Id = reportCount;
            fileHandler.Write(report,0);
        }

        internal void UpdateReport(Report rpt)
        {
            fileHandler.Write(rpt, 1);
            apptReports = fileHandler.Read();
        }
    }
}
