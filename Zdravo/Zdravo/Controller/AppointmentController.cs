// File:    AppointmentController.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:58:38 PM
// Purpose: Definition of Class AppointmentController

using Model;
using Repo;
using Repository;
using Service;
using System;
using System.Collections.ObjectModel;

namespace Controller
{
   public class AppointmentController
   {
      public AppointmentService service { get; }

      public AppointmentController()
        {
            service = new AppointmentService();
        }

     
      
      public bool CreateAppointment(int patientId,int roomId, int hours, int minutes, DateOnly _date)
      {
            bool isValid = true;
            PatientRepository patientRepo = new PatientRepository();
            RoomRepository roomRepo = new RoomRepository();

            Patient p = patientRepo.GetById(patientId);
            Room r = roomRepo.GetById(roomId);
            if (p == null | r == null) isValid = false;

           

            TimeOnly _time = new TimeOnly(hours, minutes);

            if (isValid) {
                Appointment appt = new Appointment() { date = _date, time = _time, doctor = 32, duration = 30, patient = patientId, room = roomId };
                service.CreateAppointment(appt);
            }

            return isValid;


        }

        public Boolean CheckRoomAvailability(int idRoom)
      {
         throw new NotImplementedException();
      }
      public ObservableCollection<Appointment> GetAll()
        {
          return service.GetAll();
      }
       
        public Boolean patientExists(int id)
        {
            if (service.GetByPatientID(id) == null) return false;
            return true;
        }

    }
}