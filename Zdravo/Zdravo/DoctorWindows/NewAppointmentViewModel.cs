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

        private RoomService rs=new RoomService();
        private ObservableCollection<int> rooms;
        public ObservableCollection<int> Rooms
        {
            get {
                rooms = rs.getAllIds(); 
                return rooms; }
            set { rooms = rs.getAllIds(); }
        }

        private AppointmentController ac= new AppointmentController();
        public bool CreateAppointment()
        {
            DateOnly date = new DateOnly(Year,Month,Day);
            return ac.CreateAppointment(patientId, roomId, hour, minutes, date);
        }
        
    }

    
}
