using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Zdravo.Controller;
using Zdravo.DoctorView;

namespace Zdravo.ViewModel
{
    internal class PrescriptionViewModel
    {
        private int appointmentId;
        private ObservableCollection<Drug> drugs;
        public string SelectedDrug { get; set; }
        public ObservableCollection<Drug> Drugs { get { return drugs; } set { drugs = value; } }
        private AppointmentController appointmentController;
        private DrugController drugController;
        
        public PrescriptionViewModel(int appointmentId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController=app.drugController;
            this.appointmentId = appointmentId;
            drugs = drugController.GetAllDrugs();


        }

        public bool CheckAllergies(int drugId)
        {
            return appointmentController.CheckAllergies(appointmentId,drugId);
        }

        internal void AddPrescription(int drugId)
        {
            Appointment appt= appointmentController.GetAppointment(appointmentId);
            appointmentController.AddPrescription(appt.Patient,drugId,DateTime.Now);
        }

        internal void ShowDrug(int drugId)
        {
            DrugWindow drugWindow = new DrugWindow(null, drugId);
            drugWindow.Show();
        }
    }
}
