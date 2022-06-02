using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
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
            return service.GetAllDrugs();
        }

        internal Drug GetById(int drugId)
        {
            return service.GetById(drugId);
        }

        internal bool ChangeStatus(bool isAccepted, int drugId)
        {
            return service.ChangeStatus(isAccepted, drugId);
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            service.CreateDrugReport(drugId, reason);
        }

        public List<DrugReport> GetAllReports()
        {
            return service.GetAllReports();
        }
    }
}
