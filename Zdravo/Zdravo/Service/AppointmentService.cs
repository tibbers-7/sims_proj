// File:    AppointmentService.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:47:00 PM
// Purpose: Definition of Class AppointmentService

using Model;
using Repo;
using Repository;
using System;
using System.Collections.ObjectModel;

namespace Service
{
   public class AppointmentService
   {
      private AppointmentRepository appointmentRepo;
      private DoctorRepository doctorRepo;
      private RoomRepository roomRepo;
      private PatientRepository patientRepo;
      
        public AppointmentService()
        {
            
            appointmentRepo= new AppointmentRepository();
        }

        internal ObservableCollection<Appointment> GetAll()
        {
            return appointmentRepo.GetAll();
        }
        public ObservableCollection<Appointment> GetByDoctorID(int idDoctor)
      {
        ObservableCollection<Appointment> result= new ObservableCollection<Appointment>();
         foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Doctor==idDoctor) result.Add(appt);
            }

         return result;
      }
      
      public ObservableCollection<Appointment> GetByRoomID(int idRoom)
      {
            ObservableCollection<Appointment> result = new ObservableCollection<Appointment>();
            foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Room.Equals(idRoom)) result.Add(appt);
            }

            return result;
        }

        

        public ObservableCollection<Appointment> GetByPatientID(int idPatient)
      {
            ObservableCollection<Appointment> result = new ObservableCollection<Appointment>();
            foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Patient == idPatient) result.Add(appt);
            }

            return result;
        }

       
      public void CreateAppointment(Appointment appt)
        {
            appointmentRepo.CreateAppointment(appt);
        }

        internal Appointment GetAppointment(int id)
        {
            return appointmentRepo.GetByID(id);
        }

        public bool DeleteAppointment(int idAppointment)
      {
         return appointmentRepo.DeleteAppointment(idAppointment);
      }

        internal bool UpdateAppointment(int id)
        {
            throw new NotImplementedException();
        }
    }
}