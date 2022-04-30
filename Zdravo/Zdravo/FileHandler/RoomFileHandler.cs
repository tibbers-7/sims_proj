using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo;

namespace FileHandler
{
   public class RoomFileHandler
   {
      private String filePath = "data/rooms.txt";

        public RoomFileHandler()
        {
           // filePath = "data/rooms.txt";
            
        }
      public ObservableCollection<Room> Read()
      {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int id = Int32.Parse(ss[0]);
                int floor = Int32.Parse(ss[1]);
                String type = ss[2];
                RoomType type1;
                switch (type)
                {
                    case "operatingRoom":
                        type1 = RoomType.operatingRoom;
                        break;
                    case "laboratory":
                        type1 = RoomType.laboratory;
                        break;
                    default:
                        type1 = RoomType.operatingRoom;
                        break;
                }
                ObservableCollection<int> equipmentIds = new ObservableCollection<int>();
                int equipmentId = 0;
                for (int i = 3; i < ss.Length; i++)
                {
                    equipmentId = Int32.Parse(ss[i]);
                    equipmentIds.Add(equipmentId);
                }
                Room room = new Room(id, floor, type1, equipmentIds);
                rooms.Add(room);
            }
            return rooms;
        }
      
      public void Write(Room newRoom)
      {
         throw new NotImplementedException();
      }
   
   }
}