using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using Repository;
using Zdravo.SecretaryWindows;
using FileHandler;
namespace ViewModel
{
    public class MeetingsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Meeting> meetings;
        private MeetingsFileHandler meetingsFileHandler;
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return meetings;
            }
            set
            {
                if (meetings == value)
                    return;
                meetings = meetingsFileHandler.Load();
                NotifyPropertyChanged("Meetings");
            }
        }

        public MeetingsViewModel()
        {
            meetingsFileHandler = new MeetingsFileHandler();
            meetings = meetingsFileHandler.Load();
        }


        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
