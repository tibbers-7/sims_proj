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
    public class SplitingRoomsViewModel : INotifyPropertyChanged
    {
        #region NotifyProperties
        private ObservableCollection<int> roomIds;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int firstRoomId;
        private int secondRoomId;
        private RoomController roomController;
        private SplittingRoomController splittingRoomController;
        

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

        public int FirstRoomId
        {
            get
            {
                return firstRoomId;
            }
            set
            {
                if (value != firstRoomId)
                {
                    firstRoomId = value;
                    NotifyPropertyChanged("FirstRoomId");
                }
            }
        }

        

        public int SecondRoomId
        {
            get
            {
                return secondRoomId;
            }
            set
            {
                if (value != secondRoomId)
                {
                    secondRoomId = value;
                    NotifyPropertyChanged("SecondRoomId");
                }
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public SplitingRoomsViewModel() {
            roomController = new RoomController();
            roomIds = roomController.getAllIds();
            splittingRoomController = new SplittingRoomController();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Create(int selectedRoomId, RoomType firstRoomType, RoomType secondRoomType) {
            splittingRoomController.Create(selectedRoomId, description, StartDate, endDate, firstRoomId, firstRoomType, secondRoomId, secondRoomType);
        }
    }
}
