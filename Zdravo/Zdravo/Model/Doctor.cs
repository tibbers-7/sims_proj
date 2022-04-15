// File:    Doctor.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:51:36 PM
// Purpose: Definition of Class Doctor

using System;

namespace Model
{
   public class Doctor : User
   {
      
      
      public Appointment[] appointment;
        public Doctor(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu, string mejl) : base(fn, ln, i, un, pas, pn, date, g, ad, gu, mejl)
        {

        }
    }
}