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

        

        internal ObservableCollection<string> GetAllDrugNames()
        {
            return new ObservableCollection<string>(service.GetAllDrugNames());
        }

        internal Drug GetById(int drugId)
        {
            return service.GetById(drugId);
        }

        internal void ChangeStatus(bool isAccepted, int drugId)
        {
            service.ChangeStatus(isAccepted, drugId);
        }
    }
}
