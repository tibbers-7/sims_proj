using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Repository;

namespace Zdravo.Service
{
    public class MergingRoomsService
    {
        private MergingRoomsRepository mergingRoomsRepository;

        public MergingRoomsService() { 
            this.mergingRoomsRepository = new MergingRoomsRepository();
        }

        public void Create(MergingRooms mergingRooms) { 
            mergingRoomsRepository.Create(mergingRooms);
        }
    }
}
