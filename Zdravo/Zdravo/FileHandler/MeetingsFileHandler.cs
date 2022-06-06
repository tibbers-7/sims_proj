using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace FileHandler
{
    public class MeetingsFileHandler
    {
        private const string filepath= "data/Meetings.txt";
        public ObservableCollection<Meeting> Load()
        {

            ObservableCollection<Meeting> meetings = new ObservableCollection<Meeting>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                string[] parameters = line.Split(',');
                int id=int.Parse(parameters[0]);
                DateOnly date=DateOnly.Parse(parameters[1]);
                TimeOnly time=TimeOnly.Parse(parameters[2]);
                List<int> userIds = new List<int>();
                if (parameters.Length == 4)
                {
                    string[] idParameters = parameters[3].Split(".");
                    foreach(string idString in idParameters)
                    {
                        userIds.Add(int.Parse(idString));
                    }
                }
                Meeting meeting = new Meeting(id, date, time, userIds);
                meetings.Add(meeting);

            }
            return meetings;
        }
    }
}
