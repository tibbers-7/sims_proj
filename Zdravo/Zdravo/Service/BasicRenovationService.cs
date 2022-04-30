using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Repository;

namespace Zdravo.Service
{
    public class BasicRenovationService
    {
        private BasicRenovationRepository bsRepository;

        public BasicRenovationService() { 
            bsRepository = new BasicRenovationRepository();
        }

        public void Create(BasicRenovation newRenovation)
        {
            bsRepository.Create(newRenovation);
        }
    }
}
