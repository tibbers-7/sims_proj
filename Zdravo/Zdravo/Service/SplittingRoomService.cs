using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Repository;

namespace Zdravo.Service
{
    public class SplittingRoomService
    {
        private SplittingRoomRepository splittingRoomRepository;

        public SplittingRoomService()
        {
            this.splittingRoomRepository = new SplittingRoomRepository();
        }
        public void Create(SplittingRoom splittingRoom) { 
            splittingRoomRepository.Create(splittingRoom);
        }

    }
}
