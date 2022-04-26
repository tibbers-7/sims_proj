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
using Zdravo.Model;
using Zdravo.Repository;

namespace Controller
{
   public class AppointmentController
   {
        private AppointmentService service;
      private PatientRepository patientRepository;
        private RoomController roomController;
        private ReportRepository reportRepo;

      public AppointmentController()
        {
            service = new AppointmentService();

            //CHANGE
            patientRepository = new PatientRepository();
            roomController = new RoomController();
            reportRepo = new ReportRepository();
        }

        public ObservableCollection<Appointment> GetAppointments()
        {
            return service.GetAll();
        }

        // creating should immediately link it to the patient and the room
        public int CreateAppointment(int patientId,int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
      {
            int errorCode=0;
            DateOnly date = new DateOnly();

            Patient p = patientRepository.GetById(patientId);
            Room r = roomController.GetById(roomId);

            // uncomment when implemented crossrepo validation

/*            if (p == null) errorCode = 1;
            if(r == null) errorCode = 2;*/
            try
            {
                date = new DateOnly(year, month, day);
            }
            catch (Exception e)
            {
                // Invalid date error
                errorCode = 3;
            }
            

            TimeOnly _time = new TimeOnly(hours, minutes);
            DateTime datetime = date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime,DateTime.Now);
            if (cmp < 0) errorCode = 4;   // Cannot make appointment in the past


            if (errorCode==0) {
                Appointment appt = new Appointment() { Date = date, Time = _time, Doctor = 32, Duration = duration, Patient = patientId, Room = roomId, Emergency=emergency };
                service.CreateAppointment(appt);
            }

            return errorCode;


        }

        public bool DeleteAppointment(int id)
        {
            return service.DeleteAppointment(id);
        }

        //should update in the patient's list too
        public int UpdateAppointment(int id, int patientId, int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
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

            // add proper doctor id
            Appointment appt = new Appointment() { Id = id, Date = date, Time = _time, Doctor = 32, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency };
            service.UpdateAppointment(appt);
            return errorCode;
        }

        //link report to patient
        internal void CreateReport(int apptId,DateTime date, string diagnosis, string report)
        {
            Report rpt=service.CreateReport(date, diagnosis, report);
            Appointment appt=service.GetAppointment(apptId);

            // Change to controller later
            Patient p = patientRepository.GetById(appt.Patient);
            p.AddReport(rpt);
            
            reportRepo.AddReport(rpt);
        }

        internal bool CheckAllergies(int appointmentId, string selectedDrug)
        {
            return service.CheckAllergies(appointmentId,selectedDrug);
        }

        internal ObservableCollection<string> GetAllDrugs()
        {
            return service.GetAllDrugs();
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
            if (DateTime.Compare(DateTime.Now, datetime) > 0) return true;
            return false;
        }

        
        
    }
}