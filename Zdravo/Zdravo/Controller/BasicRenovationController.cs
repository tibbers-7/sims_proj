using System;
using System.Collections.ObjectModel;
using Service;
using Model;

namespace Controller
{
    public class BasicRenovationController
    {
        private BasicRenovationService bsService;
        public BasicRenovationController() { 
            bsService = new BasicRenovationService();
        }

        public int Create(int id, int roomId, string description, DateTime date)
        {
            var newBasicRenovation = new BasicRenovation(id, roomId, description, date);
            int errorCode = bsService.Create(newBasicRenovation);
            return errorCode;
        }

        public ObservableCollection<BasicRenovation> GetAll() {
            return bsService.GetAll();
        }
    }
}
