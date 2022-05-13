using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Zdravo.ViewModel
{
    public class EquipmentRelocationViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<StaticEquipment> equipment;
        private ObservableCollection<Room> rooms;
        private RoomController roomController;
        private EquipmentController eqController;
        private DateTime date;
        private int amount;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<StaticEquipment> Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                if (equipment == value)
                    return;
                equipment = eqController.GetAll();
                NotifyPropertyChanged("Equipment");
            }
        }

        public ObservableCollection<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                if (rooms == value)
                    return;
                rooms = roomController.GetAll();
                NotifyPropertyChanged("Rooms");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value != amount)
                {
                    amount = value;
                    NotifyPropertyChanged("Amount");
                }
            }
        }

        public EquipmentRelocationViewModel() { 
            equipment = new ObservableCollection<StaticEquipment>();  
            eqController = new EquipmentController();
            equipment = eqController.GetAll();
            roomController = new RoomController();
            rooms = roomController.GetAll();
        }

        public void Refresh()
        {
            equipment = eqController.GetAll();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Create(StaticEquipment selectedEq, Room selectedRoom) {
            int _equipmentId = selectedEq.id;
            int _currentLocation = selectedEq.roomId;
            int _roomId = selectedRoom.id;
            int _errorCode = 0;
            if (_currentLocation == _roomId)
            {
                _errorCode = 2;
            }
            else
            {
                _errorCode = eqController.AddRelocation(_equipmentId, _roomId, Date, Amount);
            }
            return _errorCode;
        }
       
    }
}
