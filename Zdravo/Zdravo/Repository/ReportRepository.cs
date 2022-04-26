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
        private PatientRepository patientRepo =new PatientRepository();
        private List<Report> apptReports;

        public ReportRepository()
        {
            apptReports = fileHandler.Read();
            foreach(Report report in apptReports)
            {
                //greska   patientRepo.GetById(report.PatientId).AddReport(report);
            }
        }

        public void AddReport(Report report)
        {
            fileHandler.Write(report,0);
        }
    }
}
