// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Repository
{
   public class AppointmentRepository
   {
      private static int idCounter=0;
      public AppointmentFileHandler fileHandler=new AppointmentFileHandler();
      private ObservableCollection<Appointment> appointments { get; set; }

        public AppointmentRepository()
        {
            appointments = fileHandler.Read();
        }

        public ObservableCollection<Appointment> GetAll()
      {

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
                
                fileHandler.Write(appt, 2);
                appointments = fileHandler.Read();
                return true;
        }
      
      public void CreateAppointment(Appointment appointment)
      {
            appointments.Add(appointment);
            fileHandler.Write(appointment,0);
      }
   
   }
}