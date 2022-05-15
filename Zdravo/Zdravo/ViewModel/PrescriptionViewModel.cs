using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Zdravo.Controller;

namespace Zdravo.ViewModel
{
    internal class PrescriptionViewModel
    {
        private int appointmentId;
        private ObservableCollection<string> drugs;
        public string SelectedDrug { get; set; }
        public ObservableCollection<string> Drugs { get { return drugs; } set { drugs = value; } }
        private AppointmentController appointmentController;
        private DrugController drugController;
        
        public PrescriptionViewModel(int appointmentId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController=app.drugController;
            this.appointmentId = appointmentId;
            drugs = drugController.GetAllDrugNames();
        }

        public bool CheckAllergies()
        {
            return appointmentController.CheckAllergies(appointmentId,SelectedDrug);
        }

        internal void AddPrescription()
        {
            Appointment appt= appointmentController.GetAppointment(appointmentId);
            appointmentController.AddPrescription(appt.Patient,SelectedDrug,DateTime.Now);
        }
    }
}
