using Controller;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zdravo.DoctorWindows;

namespace Zdravo.ViewModel
{
    public class PatientChartViewModel
    {
        private int appId;
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController;
        private int idPatient;
        public int IdPatient { get { return idPatient; } set { idPatient = value; } }
        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }
        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }
        private string birthDate;
        public string BirthDate { get { return birthDate; } set { birthDate = value; } }
        private string workPlace;
        public string WorkPlace { get { return workPlace; } set { workPlace = value; } }
        private string address;
        public string Address { get { return address; } set { address = value; } } 
        private char gender;
        public char Gender { get { return gender; } set { gender = value; } }
        private char marriageStatus;
        public char MarriageStatus { get { return marriageStatus; } set { marriageStatus = value; } }
        
        private ObservableCollection<string> allergens;
        public ObservableCollection<string> Allergens { get { return allergens; } set { allergens = value; } }
        private ObservableCollection<Report> reports;
        private ObservableCollection<Prescription> prescriptions;
        public ObservableCollection<Report> Reports
        {
            get { return reports; }
            set
            {
                if (reports == value) return;
                reports = patientController.GetReports(idPatient);
                NotifyPropertyChanged("Reports");
            }
        }
        public ObservableCollection<Prescription> Prescriptions
        {
            get { return prescriptions; }
            set
            {
                if (prescriptions == value) return;
                prescriptions = patientController.GetPrescriptions(idPatient);
                NotifyPropertyChanged("Prescriptions");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




        public PatientChartViewModel(int apptId,int patientId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            Patient p;
            if (apptId != 0)
            {
                Appointment appt = appointmentController.GetAppointment(apptId);
                p = patientController.GetById(appt.Patient);
                if (p == null) return;
            }
            else 
            {
                p=patientController.GetById(patientId);
                if (p == null) return;
            }

                idPatient = p.Id;
                firstName = p.Ime;
                lastName = p.Prezime;
                allergens = p.GetAllergens();
                reports = patientController.GetReports(idPatient);
                prescriptions = patientController.GetPrescriptions(idPatient);
                birthDate = p.DatumRodjenja.ToString("mm.dd.yyyy.");
                address = p.Adresa;
                if (p.pol == Zdravo.Gender.male)
                {
                    gender = 'm';
                }
                else gender = 'f';
                switch (p.Status)
                {
                    case Zdravo.MarriageStatus.married:
                        marriageStatus = 'm';
                        break;
                    case Zdravo.MarriageStatus.widow:
                        marriageStatus = 'w';
                        break;
                    case Zdravo.MarriageStatus.divorced:
                        marriageStatus = 'd';
                        break;
                    case Zdravo.MarriageStatus.single:
                        marriageStatus = 's';
                        break;
                }
                
            }
        

        internal void ShowReport(int reportId)
        {
            foreach (Report r in reports)
            {
                if (r.Id == reportId)
                {
                    ReportWindow reportWindow = new ReportWindow(0, reportId, 1, this);
                    reportWindow.Show();

                    if (!reportWindow.IsActive) RefreshReports();
                }
            }

        }

        public void RefreshReports()
        {
            reports = patientController.GetReports(IdPatient);
            prescriptions = patientController.GetPrescriptions(IdPatient);
            //table.ItemsSource = Reports;
        }
    }

    
}
