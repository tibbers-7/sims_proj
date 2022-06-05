using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Collections.ObjectModel;
using Model;

namespace Repository
{
    public class MeetingsRepository
    {
        private MeetingsFileHandler meetingsFileHandler;

        public ObservableCollection<Meeting> getAllMeetings()
        {
            meetingsFileHandler=new MeetingsFileHandler();
            return meetingsFileHandler.Load();
        }
    }
}
