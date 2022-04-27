// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Zdravo.Repository;

namespace Repository
{
   public class AppointmentRepository
   {
      private static int idCounter=0;
      public AppointmentFileHandler fileHandler=new AppointmentFileHandler();
        private PatientRepository patientRepository=new PatientRepository();
        private ObservableCollection<Appointment> appointments;
        private ReportRepository reportRepo;
        private int idCount;

        public AppointmentRepository()
        {
            appointments = fileHandler.Read();
            idCount= appointments.Count;

        }

        public ObservableCollection<Appointment> GetAll()
      {
            appointments = fileHandler.Read();
            return appointments;
         
      }
      
      public Appointment GetByID(int idAppointment)
      {
            appointments=fileHandler.Read();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == idAppointment)
                {
                    return appointment; 
                }
            }

            return null;
      }
      
      public bool DeleteAppointment(int idAppointment)
      {

            Appointment appt= GetByID(idAppointment);
            if (appt == null) return false;

            patientRepository.GetById(appt.Patient).RemoveAppt(appt);
                
                fileHandler.Write(appt, 2);
                appointments = fileHandler.Read();
                return true;
        }
      
      public void CreateAppointment(Appointment appointment)
      {
            idCount = appointments.Last().Id+1;
            appointment.Id = idCount;
            fileHandler.Write(appointment,0);
            appointments = fileHandler.Read();
      }

        internal void UpdateAppointment(Appointment appt)
        {
            fileHandler.Write(appt,1);
            appointments = fileHandler.Read();
        }

        
    }
}