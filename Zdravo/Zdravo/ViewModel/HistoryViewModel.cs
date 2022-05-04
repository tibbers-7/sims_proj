using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zdravo.DoctorWindows;
using Zdravo.Model;

namespace Zdravo.ViewModel
{
    public class HistoryViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Report> reports;
        private ObservableCollection<Prescription> prescriptions;
        private int patientId;
        private DataGrid table;

        public ObservableCollection<Report> Reports
        {
            get{ return reports;} 
            set{
                if (reports == value) return;
                reports = patientController.GetReports(patientId);
                NotifyPropertyChanged("Reports");
            }
        }
        public ObservableCollection<Prescription> Prescriptions
        {
            get{ return prescriptions;}
            set
            {
                if (prescriptions == value) return;
                prescriptions = patientController.GetPrescriptions(patientId);
                NotifyPropertyChanged("Prescriptions");
            }
        }
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();

        public HistoryViewModel(int id, DataGrid table)
        {
            Appointment appt = appointmentController.GetAppointment(id);
            this.table = table;
            patientId = appt.Patient;
            reports=patientController.GetReports(patientId);
            prescriptions = patientController.GetPrescriptions(patientId);
        }

        internal void ShowReport(int reportId)
        {
            foreach(Report r in reports)
            {
                if(r.Id == reportId)
                {
                    ReportWindow reportWindow = new ReportWindow(0,reportId,1,this);
                    reportWindow.Show();

                    if (!reportWindow.IsActive) RefreshReports();
                }
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshReports()
        {
            reports = patientController.GetReports(patientId);
            prescriptions = patientController.GetPrescriptions(patientId);
            //table.ItemsSource = Reports;
        }
    }
}
