using System;
using Model;
using System.Collections.Generic;
using Repo;
using Repository;

namespace Service
{
   public class AppointmentService
   {
      private AppointmentRepository appointmentRepo;
      private DoctorRepository doctorRepo;
      private RoomRepository roomRepo;
      private PatientRepository patientRepo;
      
      public void BindAppointmentsWithPatients()
      {
         throw new NotImplementedException();
      }
      
      public void BindAppointmentsToDoctors()
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByDoctorID()
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByRoomID()
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByPatientID()
      {
         throw new NotImplementedException();
      }
      
      public void DeleteAppointment()
      {
         throw new NotImplementedException();
      }
   
   }
}