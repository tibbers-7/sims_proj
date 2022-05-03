using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo;
using Zdravo.Repository;
using Zdravo.Model;

namespace Service
{
   public class RoomService
   {
      private Repository.RoomRepository roomRepo;
        private Repository.AppointmentRepository appointmentRepo;
        private BasicRenovationRepository bRenovationRepo;

        public RoomService() {
            roomRepo = new Repository.RoomRepository();
            appointmentRepo = new Repository.AppointmentRepository();
            bRenovationRepo = new BasicRenovationRepository();
        }
      
      public void Create(Room newRoom)
      {
            roomRepo.Create(newRoom);
      }
      
      public ObservableCollection<Room> GetAll()
      {
            return roomRepo.GetAll();
      }

        public ObservableCollection<int> getAllIds()
        {
            ObservableCollection<int> ids = new ObservableCollection<int>();
            foreach (Room room in roomRepo.GetAll())
            {
                ids.Add(room.id);
            }

            return ids;
        }

        public Model.Room GetById(int id)
      {
            return roomRepo.GetById(id);
      }
      
      public void Update(int id, RoomType type)
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

        public bool IsAvailableAppt1(int roomId, TimeOnly time, DateOnly date) {
            bool available = true;
            int cmp;
            DateTime dateTimeNew = date.ToDateTime(time);
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentRepo.GetAll());
            foreach (Appointment appointment in appointments) {
                if (appointment.Room == roomId) {
                    DateTime dateTimeAppt = appointment.Date.ToDateTime(appointment.Time);
                    cmp = DateTime.Compare(dateTimeNew, dateTimeAppt);
                    if (cmp == 0) {
                        available = false;
                    }
                }
            }
            return available;
        }

        public bool IsAvailableRenov1(int roomId, TimeOnly time, DateOnly date) {
            bool available = true;
            int cmp;
            DateTime dateTimeNew = date.ToDateTime(time);
            DateTime dateNew = dateTimeNew.Date;
            ObservableCollection<BasicRenovation> renovations = bRenovationRepo.GetAll();
            foreach (BasicRenovation renovation in renovations)
            {
                if (renovation.RoomId == roomId) { 
                    cmp = DateTime.Compare(dateNew, renovation.Date);
                    if (cmp == 0) {
                        available = false;
                    }
                }
            }
            return available;
        }

        public bool IsAvailableAppt(int roomId, DateTime date)
        {
            bool available = true;
            //int cmp;
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>(appointmentRepo.GetAll());
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room == roomId)
                {
                    DateTime dateTimeAppt = appointment.Date.ToDateTime(appointment.Time);
                    DateTime dateAppt = dateTimeAppt.Date;
                    //cmp = DateTime.Compare(date, dateTimeAppt);
                    //cmp = date.Date.CompareTo(appointment.Date);
                    /*DateOnly dateOnlyAppt = appointment.Date;
                    string dateAppt = dateOnlyAppt.ToString();*/
                    if (dateAppt.Equals(date)) {
                        available = false;
                    }
                    /*if (true)
                    {
                        available = false;
                    }*/
                }
            }
            return available;
        }

        public bool IsAvailableRenov(int roomId, DateTime date)
        {
            bool available = true;
            int cmp;
            ObservableCollection<BasicRenovation> renovations = bRenovationRepo.GetAll();
            foreach (BasicRenovation renovation in renovations)
            {
                if (renovation.RoomId == roomId)
                {
                    cmp = DateTime.Compare(date, renovation.Date);
                    if (cmp == 0)
                    {
                        available = false;
                    }
                }
            }
            return available;
        }

    }
}