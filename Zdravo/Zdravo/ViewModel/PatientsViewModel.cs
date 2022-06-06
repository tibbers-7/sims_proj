using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;

namespace Zdravo.ViewModel
{
    public class PatientsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Patient> patients;
        PatientFileHandler patientFileHandler;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Patient> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                if (patients == value)
                    return;
                patients = patientFileHandler.read();
                NotifyPropertyChanged("Patients");
            }
        }

        public PatientsViewModel()
        {
            patientFileHandler = new PatientFileHandler();
            patients = patientFileHandler.read();
        }
        public void Refresh()
        {
            patients = patientFileHandler.read();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
