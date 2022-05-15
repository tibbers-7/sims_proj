using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zdravo.DoctorWindows;

namespace Zdravo.ViewModel
{
    internal class ReferralViewModel
    {
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private ObservableCollection<string> spetializations;
        public ObservableCollection<string> Spetializations { get { return spetializations; } set { spetializations = value; } }
        private bool surgery;
        public bool Surgery { get { return surgery; } set { surgery = value;} }
        private bool appt;
        public bool Appt { get { return appt; } set { appt = value; } }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }
        private string doctorSpetialization;
        public string DoctorSpetialization { get { return doctorSpetialization; } set { doctorSpetialization = value; } }
        private int doctorId;
        public string CurrentDoctor;

        private AppointmentController apptController;
       

        public ReferralViewModel(int doctorId)
        {
            this.doctorId=doctorId;
            var app = Application.Current as App;
            apptController = app.appointmentController;
            spetializations = apptController.GetAllSpetializations();

        }

        internal int ScheduleReferral()
        {
            return apptController.CreateReferral(patientId,doctorId, doctorSpetialization, appt,emergency);
            
        }

        internal void ShowChart()
        {
            PatientChart chartWindow = new PatientChart(0, patientId);
            chartWindow.Show();
        }
    }
}
