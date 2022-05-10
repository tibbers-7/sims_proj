using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Repository;

namespace Service
{
    internal class VacationService
    {
        private VacationRepository repo;

        public VacationService()
        {
            repo = new VacationRepository();
        }
    }
}
