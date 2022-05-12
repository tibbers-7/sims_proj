using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class SplittingRoomController
    {
        private SplittingRoomService splittingRoomService;

        public SplittingRoomController() { 
            this.splittingRoomService = new SplittingRoomService();
        }
        public void Create(int selectedRoomId, string description, DateTime startDate, DateTime endDate, int firstRoomId, RoomType firstRoomType, int secondRoomId, RoomType secondRoomType) {
            SplittingRoom splittingRoom = new SplittingRoom(selectedRoomId, description, startDate, endDate, firstRoomId, firstRoomType, secondRoomId, secondRoomType);
            splittingRoomService.Create(splittingRoom);
        }
    }
}
