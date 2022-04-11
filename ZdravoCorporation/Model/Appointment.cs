// File:    Appointment.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:54:34 PM
// Purpose: Definition of Class Appointment

using System;

namespace Model
{
   public class Appointment
   {
      private DateTime appointmentStart;
      private double duration;
      
      public Doctor doctor;
      public Patient patient;
      public Room room;
   
   }
}