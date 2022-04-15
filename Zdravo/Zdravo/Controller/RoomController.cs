using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controller
{
   public class RoomController
   {
      private Service.RoomService roomService;

        public RoomController() {
            roomService = new Service.RoomService();
        }
      
      public void Create(int id, int floor, Model.RoomType type)
      {
            var newRoom = new Room { id = id, floor = floor, type = type};
            roomService.Create(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return roomService.GetAll();
      }
      
      public Model.Room GetById(int id)
      {
            return roomService.GetById(id);
        }
      
      public void Update(int id, Model.RoomType type)
      {
            roomService.Update(id, type);
        }
      
      public void DeleteAll()
      {
            roomService.DeleteAll();
      }
      
      public void DeleteById(int id)
      {
            roomService.DeleteById(id);
      }
   
   }
}