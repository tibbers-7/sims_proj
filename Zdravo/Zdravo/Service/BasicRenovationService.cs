using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class BasicRenovationService
    {
        private BasicRenovationRepository bsRepository;
        private RoomService roomService;

        public BasicRenovationService() { 
            bsRepository = new BasicRenovationRepository();
            roomService = new RoomService();
        }

        public int Create(BasicRenovation newRenovation)
        {
            int errorCode = 0;

            bool a = roomService.IsAvailableAppt(newRenovation.RoomId, newRenovation.Date);
            bool b = roomService.IsAvailableRenov(newRenovation.RoomId, newRenovation.Date);
            if (!a) errorCode = 1;
            else if(!b) errorCode = 1;

            int cmp = DateTime.Compare(newRenovation.Date, DateTime.Now);
            if (cmp < 0) errorCode = 2;

            if (errorCode == 0)
            {
                bsRepository.Create(newRenovation);
            }
            return errorCode;
        }

        public ObservableCollection<BasicRenovation> GetAll()
        {
            return bsRepository.GetAll();
        }
    }
}
