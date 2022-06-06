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
                string time = parameters[2];
                ObservableCollection<string> users = new ObservableCollection<string>();
                string description = parameters[3];
                if(parameters.Length > 4)
                {
                    string[] usersParameter=parameters[3].Split('.');
                    foreach(string userString in usersParameter)
                    {
                        users.Add(userString);
                    }
                }
                Meeting meeting = new Meeting(id,description, date, time, users);
                meetings.Add(meeting);

            }
            return meetings;
        }
    }
}
