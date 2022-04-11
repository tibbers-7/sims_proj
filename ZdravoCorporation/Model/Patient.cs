// File:    Patient.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:53:40 PM
// Purpose: Definition of Class Patient

using System;

namespace Model
{
   public class Patient : User
   {
      public Appointment[] appointment;
   
   }
}