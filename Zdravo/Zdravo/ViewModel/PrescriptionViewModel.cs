using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.ViewModel
{
    internal class PrescriptionViewModel
    {
        private int appointmentId;
        private ObservableCollection<string> drugs;
        private bool isAllergic;
        public string SelectedDrug { get; set; }
        public ObservableCollection<string> Drugs { get { return drugs; } set { drugs = value; } }
        private AppointmentController apptController =new AppointmentController();

        public PrescriptionViewModel(int appointmentId)
        {
            this.appointmentId = appointmentId;
            drugs = apptController.GetAllDrugs();
        }

        public bool CheckAllergies()
        {
            return apptController.CheckAllergies(appointmentId,SelectedDrug);
        }

        
    }
}
