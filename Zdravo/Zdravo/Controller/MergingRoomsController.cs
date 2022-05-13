using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class MergingRoomsController
    {
        private MergingRoomsService mergingRoomsService;

        public MergingRoomsController() {
            this.mergingRoomsService = new MergingRoomsService();
        }

        public void Create(int firstSelectedRoomId, int secondSelectedRoomId, DateTime startDate, DateTime endDate, string description, int newRoomId, RoomType newRoomType) {
            MergingRooms mergingRooms = new MergingRooms(firstSelectedRoomId, secondSelectedRoomId, startDate, endDate, description, newRoomId, newRoomType);
            mergingRoomsService.Create(mergingRooms);
        }
    }
}
