// File:    Appointment.cs
// Author:  Anja
// Created: Monday, March 28, 2022 2:54:34 PM
// Purpose: Definition of Class Appointment

using System;
using System.Text.RegularExpressions;

namespace Model
{
   public class Appointment
   {
      public int id { get; set; }
        public TimeOnly time { get; set; }
        public DateOnly date { get; set; }
        public int duration     { get; set; }
      
    //TODO: Change to appropriate classes after their implementation
      public int doctor     { get; set; }
      public int patient { get; set; }   
        public int room { get; set; }


        public void fromCSV(GroupCollection csvValues)
        {
            Console.WriteLine(csvValues[0]);
            patient = int.Parse(csvValues[1].Value);
            room = int.Parse(csvValues[2].Value);
            date = DateOnly.Parse(csvValues[3].Value);
            time = TimeOnly.Parse(csvValues[4].Value);
            duration = int.Parse(csvValues[5].Value);
            doctor = int.Parse(csvValues[6].Value);

        }

        internal string toCSV()
        {
            //3253,38G,2022/01/01,13:00,30,32
            Regex regexObj = new Regex("(\\d{2}:\\d{2})");
            Match matchResult = regexObj.Match(time.ToString());
            string _time=matchResult.Groups[0].Value;
            string res = patient.ToString() + "," + room + "," + date.ToString() + "," + _time.ToString() + "," + duration.ToString() + "," + doctor.ToString();
            return res;
        }
    }        

}