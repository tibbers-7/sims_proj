using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.DoctorWindows;
using Zdravo.Model;

namespace Zdravo.ViewModel
{
    internal class HistoryViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Report> reports;
        private int patientId;
        public ObservableCollection<Report> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                if (reports == value)
                    return;
                reports = patientController.GetReports(patientId);
                NotifyPropertyChanged("Reports");
            }
        }
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();

        internal void ShowReport(int reportId)
        {
            foreach(Report r in reports)
            {
                if(r.Id == reportId)
                {
                    ReportWindow reportWindow = new ReportWindow(0,reportId);
                    reportWindow.Show();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HistoryViewModel(int id)
        {
            Appointment appt=appointmentController.GetAppointment(id);
            patientId = appt.Patient;
            reports= patientController.GetReports(appt.Patient);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
