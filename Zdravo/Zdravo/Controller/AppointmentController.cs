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

     
      
      public int CreateAppointment(int patientId,int roomId, int hours, int minutes, int duration, int day, int month, int year)
      {
            int errorCode=0;
            PatientRepository patientRepo = new PatientRepository();
            RoomRepository roomRepo = new RoomRepository();
            DateOnly date = new DateOnly();

            Patient p = patientRepo.GetById(patientId);
            Room r = roomRepo.GetById(roomId);

            // uncomment when implemented crossrepo validation
/*            if (p == null) errorCode = 1;
            if(r == null) errorCode = 2;*/
            try
            {
                date = new DateOnly(year, month, day);
            }
            catch (Exception e)
            {
                errorCode = 3;
            }
            

           

            TimeOnly _time = new TimeOnly(hours, minutes);
            DateTime datetime = date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime,DateTime.Now);
            if (cmp < 0) errorCode = 4;


            if (errorCode==0) {
                Appointment appt = new Appointment() { Date = date, Time = _time, Doctor = 32, Duration = 30, Patient = patientId, Room = roomId };
                service.CreateAppointment(appt);
            }

            return errorCode;


        }

        internal bool CheckAllergies(int appointmentId, string selectedDrug)
        {
            throw new NotImplementedException();
        }

        internal ObservableCollection<string> GetAllDrugs()
        {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment(int id)
        {
            return service.DeleteAppointment(id);
        }

        public int UpdateAppointment(int id, int patientId,int roomId,int hours,int minutes,int duration, int day, int month, int year)
        {
            int errorCode = 0;
            DateOnly date = new DateOnly();
            TimeOnly _time = new TimeOnly(hours, minutes);
            try
            {
                date = new DateOnly(year, month, day);
            }
            catch (Exception e)
            {
                errorCode = 3;
            }
            DateTime datetime = date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) errorCode = 4;

            Appointment appt = new Appointment() {Id=id, Date = date, Time = _time, Doctor = 32, Duration = duration, Patient = patientId, Room = roomId };
            service.UpdateAppointment(appt);
            return errorCode;
        }

        public bool CheckRoomAvailability(int idRoom)
      {
         throw new NotImplementedException();
      }
      public ObservableCollection<Appointment> GetAll()
        {
          return service.GetAll();
      }
       
        public bool PatientExists(int id)
        {
            if (service.GetByPatientID(id) == null) return false;
            return true;
        }

        public Appointment GetAppointment(int id)
        {
            return service.GetAppointment(id);
        }

        public bool IsReportAvailable(int id)
        {
            Appointment appt = GetAppointment(id);
            DateTime datetime = appt.Date.ToDateTime(appt.Time);
            int cmp = DateTime.Compare(DateTime.Now, datetime);
            if (cmp>0)
            {
                return true;
            }
            return false;
        }
        public ObservableCollection<Appointment> GetAppointments()
        {
            return service.GetAll();
        }
    }
}