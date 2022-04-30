using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo;

namespace Repository
{
   public class RoomRepository
   {
      private FileHandler.RoomFileHandler fileHandler;
        public ObservableCollection<Room> rooms;

        public RoomRepository()
        {
            fileHandler = new FileHandler.RoomFileHandler();
            rooms = new ObservableCollection<Room>();
            rooms = fileHandler.Read();
            /*var room1 = new Room() { id = 1, floor = 1, type = RoomType.operatingRoom };
            var eq1 = new StaticEquipment {id = 1, name = "sto", amount = 1, roomId = 1};
            var eq2 = new StaticEquipment { id = 2, name = "stolica", amount = 1, roomId = 1 };
            room1.AddEquipment(eq1);
            room1.AddEquipment(eq2);

            rooms.Add(room1);

            var room2 = new Room() { id = 2, floor = 1, type = RoomType.operatingRoom };
            var eq3 = new StaticEquipment { id = 3, name = "hanzaplast", amount = 1, roomId = 2 };
            var eq4 = new StaticEquipment { id = 2, name = "bensedin", amount = 1, roomId = 2 };
            room2.AddEquipment(eq3);
            room2.AddEquipment(eq4);

            rooms.Add(room2);*/

        }
      
      public void Create(Room newRoom)
      {
            rooms.Add(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return rooms;
      }
      
      public void DeleteAll()
      {
            
      }

        //internal Room GetById(int id)
        //{
        //    foreach (Room r in rooms)
        //    {
        //        if (r.id==id) return r;
        //    }

        //    return null;
        //}

        public void DeleteById(int id)
      {
            int selected = -1;
            int i = 0;
            foreach (Room room in rooms) {
                if (room.id == id) {
                    selected = i;
                }
                i++;
            }
            if (selected >= 0) {
                rooms.RemoveAt(selected);
            }
            
        }
      
      public Model.Room GetById(int id)
      {
            foreach (Room room in rooms)
            {
                if (room.id == id)
                {
                    return room;
                }
            }
            return null;
        }
      
      public void Update(int id, RoomType type)
      {
            foreach (Room room in rooms)
            {
                if (room.id == id)
                {
                    room.type = type;
                    return;
                }
            }
        }
   
   }
}