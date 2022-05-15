using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Service
{
    public class DrugService
    {
        private DrugRepository drugRepo;

        public DrugService(DrugRepository drugRepo)
        {
            this.drugRepo = drugRepo;
        }

        internal List<Drug> GetValidDrugs()
        {
            return drugRepo.GetValidDrugs();
        }

        internal List<Drug> GetAllDrugs()
        {
            return drugRepo.GetAllDrugs();
        }

        internal Drug GetById(int drugId)
        {
            return drugRepo.GetById(drugId);
        }

        internal void ChangeStatus(bool isAccepted, int drugId)
        {
            drugRepo.ChangeStatus(isAccepted, drugId);
        }
    }
}
