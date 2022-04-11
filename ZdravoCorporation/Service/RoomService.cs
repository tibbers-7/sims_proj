using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
   public class RoomService
   {
      private Repo.RoomRepository roomRepo;

        public RoomService() {
            roomRepo = new Repo.RoomRepository();
        }
      
      public void Create(Room newRoom)
      {
            roomRepo.Create(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return roomRepo.GetAll();
      }
      
      public Model.Room GetById(int id)
      {
            return roomRepo.GetById(id);
      }
      
      public void Update(int id, Model.RoomType type)
      {
            roomRepo.Update(id, type);
      }
      
      public void DeleteAll()
      {
            roomRepo.DeleteAll();
      }
      
      public void DeleteById(int id)
      {
            roomRepo.DeleteById(id);
        }
   
   }
}