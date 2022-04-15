// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Repo
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
            foreach (Appointment appointment in appointments)
            {
                if (appointment.id == idAppointment)
                {
                    return appointment; 
                }
            }

            return null;
      }
      
      public Boolean DeleteAppointment(int idAppointment)
      {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.id == idAppointment)
                {
                    appointments.RemoveAt(idAppointment);
                    return true;
                }
            }

            return false;
        }
      
      public void CreateAppointment(Appointment appointment)
      {
            appointments.Add(appointment);
            fileHandler.Write(appointment,0);
      }
   
   }
}