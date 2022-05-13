using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Controller;

namespace Zdravo.ViewModel
{
    public class MergingRoomsViewModel : INotifyPropertyChanged
    {
        #region NotifyProperties
        private ObservableCollection<int> roomIds;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int newRoomId;
        private RoomController roomController;
        //private SplittingRoomController splittingRoomController;


        public ObservableCollection<int> RoomIds
        {
            get
            {
                return roomIds;
            }
            set
            {
                if (roomIds == value)
                    return;
                roomIds = roomController.getAllIds();
                NotifyPropertyChanged("RoomIds");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    NotifyPropertyChanged("StartDate");
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    NotifyPropertyChanged("EndDate");
                }
            }
        }

        public int NewRoomId
        {
            get
            {
                return newRoomId;
            }
            set
            {
                if (value != newRoomId)
                {
                    newRoomId = value;
                    NotifyPropertyChanged("NewRoomId");
                }
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public MergingRoomsViewModel()
        {
            roomController = new RoomController();
            roomIds = roomController.getAllIds();
            
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Create(int selectedRoomId, RoomType firstRoomType, RoomType secondRoomType)
        {
           // splittingRoomController.Create(selectedRoomId, description, StartDate, endDate, firstRoomId, firstRoomType, secondRoomId, secondRoomType);
        }
    }
}
