using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    public class MergingRoomsRepository
    {
        private MergingRoomsFileHandler mergingRoomsFileHandler;
        private ObservableCollection<MergingRooms> roomsMergings;

        public MergingRoomsRepository() { 
            this.mergingRoomsFileHandler = new MergingRoomsFileHandler();
            roomsMergings = mergingRoomsFileHandler.Read();
        }

        public void Create(MergingRooms mergingRooms) {
            roomsMergings.Add(mergingRooms);
            mergingRoomsFileHandler.Write(roomsMergings);
        }

        public ObservableCollection<MergingRooms> GetAll() {
            roomsMergings = mergingRoomsFileHandler.Read();
            return roomsMergings;
        }

        public void Delete(MergingRooms mergingRooms)
        {
            roomsMergings.Remove(mergingRooms);
            mergingRoomsFileHandler.Write(roomsMergings);
        }
    }
}
