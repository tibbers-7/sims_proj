using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Repository
{
    public class SplittingRoomRepository
    {
        private SplittingRoomFileHandler splittingRoomFileHandler;
        private ObservableCollection<SplittingRoom> roomSplittings;

        public SplittingRoomRepository() { 
            this.splittingRoomFileHandler = new SplittingRoomFileHandler();
            roomSplittings = splittingRoomFileHandler.Read();
        }
        public void Create(SplittingRoom splittingRoom) {
            roomSplittings.Add(splittingRoom);
            splittingRoomFileHandler.Write(roomSplittings);
        }

        public ObservableCollection<SplittingRoom> GetAll() {
            roomSplittings = splittingRoomFileHandler.Read();
            return roomSplittings;
        }

        public void Delete(SplittingRoom splittingRoom) {
            roomSplittings.Remove(splittingRoom);
            splittingRoomFileHandler.Write(roomSplittings);
        }
    }
}
