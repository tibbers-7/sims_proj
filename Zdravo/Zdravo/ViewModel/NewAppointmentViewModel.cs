using Controller;
using Model;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zdravo
{
    internal class NewAppointmentViewModel
    {

        private int patientId;
        public int PatientId {get{return patientId;} set{patientId = value;}}

        private int roomId;
        public int RoomId { get { return roomId; } set { roomId = value; } }

        private int hour;
        public int Hour { get { return hour; } set { hour = value; } }
        private int minutes;
        public int Minutes { get { return minutes; } set { minutes = value; } }
        private int day;
        public int Day { get { return day; } set { day = value; } }
        private int month;
        public int Month { get { return month; } set { month = value; } }
        private int year;
        public int Year { get { return year; } set { year = value; } }
        private int duration;
        public int Duration { get { return duration; } set { duration = value; } }

        private RoomController roomController=new RoomController();
        private ObservableCollection<int> rooms;
        public ObservableCollection<int> Rooms
        {
            get {
                rooms = roomController.getAllIds(); 
                return rooms; }
            set { rooms = roomController.getAllIds(); }
        }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }

        private Appointment appt;
        private int id;

        private AppointmentController ac= new AppointmentController();

        public NewAppointmentViewModel(int id)
        {
            this.id = id;
            // overriding the default empty window with specific appointment details
            if (id != 0)
            {
                appt = ac.GetAppointment(id);
                patientId = appt.Patient;
                roomId = appt.Room;  
                duration = appt.Duration;

                Regex regexObj = new Regex("(\\d+)/(\\d+)/(\\d{4})");
                Match matchResult = regexObj.Match(appt.Date.ToString());
                month=int.Parse(matchResult.Groups[1].Value);
                day=int.Parse(matchResult.Groups[2].Value);
                year=int.Parse(matchResult.Groups[3].Value);

                regexObj = new Regex("(\\d+):(\\d{2})");
                matchResult = regexObj.Match(appt.Time.ToString());
                hour=int.Parse(matchResult.Groups[1].Value);
                minutes=int.Parse(matchResult.Groups[2].Value);
                emergency = appt.Emergency;

                
            }
        }
        public int CreateAppointment()
        { 
                if (id == 0)
                {
                    return ac.CreateAppointment(patientId, roomId, hour, minutes, duration,day,month,year,emergency);
                }
                else return ac.UpdateAppointment(id, patientId, roomId, hour, minutes, duration,day,month,year,emergency);

         }
            
    }
      
}

    

