﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zdravo.Controller;

namespace Zdravo.managerView
{
    public partial class BasicRenovation : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Room> rooms { get; set; }
        public RoomController roomController { get; set; }
        private BasicRenovationController bsConroller;

        #region NotifyProperties
        private int id;
        private DateTime date;
        private string description;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
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
                    OnPropertyChanged("Date");
                }
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
                    OnPropertyChanged("Description");
                }
            }
        }

        #endregion
        public BasicRenovation()
        {
            InitializeComponent();
            this.DataContext = this;
            bsConroller = new BasicRenovationController(); 
            roomController = new RoomController();
            rooms = roomController.GetAll();
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)dataGridRooms.SelectedItem;
            int roomId = selected.id;
            bsConroller.Create(Id, roomId, Description, Date);
            this.Close();
        }
    }
}