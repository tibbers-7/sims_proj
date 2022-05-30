using System.Collections.Generic;
using FileHandler;
using Model;
using Zdravo.FileHandler;

namespace Repository
{
    public class ReportRepository
    {
        private ReportFileHandler fileHandler=new ReportFileHandler();
        public List<Report> reports;

        public ReportRepository()
        {
            InitReports();
        }

        private void InitReports()
        {
            List<object> reportList = fileHandler.Read();
            reports=new List<Report>();
            foreach (object reportObj in reportList)
            {
                Report report = (Report)reportObj;
                reports.Add(report);
            }
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

        public void AddNew(Report report)
        {
            report.Id = reports.Count + 1;
            int listCount = reports.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = reports[i].ToCSV();
            }
            newLines[listCount] = report.ToCSV();
            fileHandler.Write(newLines);
            InitReports();
        }

        internal void Update(Report newReport)
        {
            int listCount = reports.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Report report in reports)
            {
                if (newReport.Id != report.Id)
                {
                    newLines[i] = report.ToCSV();
                    i++;
                }
                else newLines[i] = newReport.ToCSV();
            }
            fileHandler.Write(newLines);
            InitReports();
        }
    }
}
