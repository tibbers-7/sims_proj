using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class BasicRenovationController
    {
        private BasicRenovationService bsService;
        public BasicRenovationController() { 
            bsService = new BasicRenovationService();
        }

        public void Create(int id, int roomId, string description, DateTime date)
        {
            var newBasicRenovation = new BasicRenovation(id, roomId, description, date);
            bsService.Create(newBasicRenovation);
        }
    }
}
