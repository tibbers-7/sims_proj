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
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private TimeOnly time;
        public TimeOnly Time { get { return time; } set { time = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        private int duration;
        public int Duration { get { return duration; } set { duration = value; } }

        //TODO: Change to appropriate classes after their implementation
        private int doctor;
        public int Doctor { get { return doctor; } set { doctor = value; } }
        private int patient;
        public int Patient { get { return patient; } set { patient = value; } }
        private int room;
        public int Room { get { return room; } set { room = value; } }
        private bool emergency;
        public string EmergencyChar { get { if (emergency) return "DA"; else return "NE"; } set { if (value.Equals("DA")) emergency = true; else emergency = false; } }



        public void fromCSV(GroupCollection csvValues)
        {
            Console.WriteLine(csvValues[0]);
            id= int.Parse(csvValues[1].Value);
            patient = int.Parse(csvValues[2].Value);
            room = int.Parse(csvValues[3].Value);
            date = DateOnly.Parse(csvValues[4].Value);
            time = TimeOnly.Parse(csvValues[5].Value);
            duration = int.Parse(csvValues[6].Value);
            doctor = int.Parse(csvValues[7].Value);
            switch (csvValues[8].Value)
            {
                case "Y":
                    emergency = true;
                    break;
                case "N":
                    emergency = false;
                    break;
            }

        }

        internal string toCSV()
        {
            //1,3253,38G,2022/01/01,13:00,30,32
            Regex regexObj = new Regex("\\d+:\\d{2}");
            Match matchResult = regexObj.Match(time.ToString());
            string _time=matchResult.Value;
            char _emergency;
            if (emergency) _emergency = 'Y'; else _emergency = 'N';
            string res = id.ToString()+","+patient.ToString() + "," + room + "," + date.ToString() + "," + _time + "," + duration.ToString() + "," + doctor.ToString()+","+_emergency;
            return res;
        }
    }        

}