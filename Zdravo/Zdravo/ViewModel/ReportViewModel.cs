using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;

namespace Zdravo.ViewModel
{
    internal class ReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int apptId;
        private int day;
        private int month;
        private int year;
        public int Day { get { return day; } set { day = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Year { get { return year; } set { year = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string reportString;
        public string ReportString { get { return reportString; } set { reportString = value; } }
        private AppointmentController appointmentController = new AppointmentController();
        public ReportViewModel(int apptId,int reportId)
        {
            this.apptId = apptId;
            if(reportId != 0)
            {

                Report r = appointmentController.GetReport(reportId);
                day = r.Date.Day;
                month = r.Date.Month;
                year = r.Date.Year;
                diagnosis=r.Diagnosis;
                reportString = r.ReportString;
            }
            else
            {
                day = DateTime.Now.Day;
                month=DateTime.Now.Month;
                year=DateTime.Now.Year;
            }
        }

        internal void AcceptClick()
        {
            appointmentController.CreateReport(apptId,date, diagnosis, reportString);
        }
    }
}
