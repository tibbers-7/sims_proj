using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class DrugController
    {

        private DrugService service;

        public DrugController(DrugService service)
        {
            this.service = service;
        }

        internal List<Drug> GetValidDrugs()
        {
            return service.GetValidDrugs();
        }

        

        internal List<Drug> GetAllDrugs()
        {
            return service.GetAll();
        }

        internal Drug GetById(int drugId)
        {
            return service.GetById(drugId);
        }

        internal int ChangeStatus(bool isAccepted, int drugId)
        {
            return service.ChangeStatus(isAccepted, drugId);
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            service.CreateDrugReport(drugId, reason);
        }

        internal ObservableCollection<Drug> SetAllergies(ObservableCollection<Drug> drugs, Patient patient)
        {
            return service.SetAllergies(drugs, patient);
        }

        internal bool GetAllergenConflicts(int drugId, ObservableCollection<Drug> drugs)
        {
            return service.GetAllergenConflicts(drugId, drugs);
        }
    }
}
