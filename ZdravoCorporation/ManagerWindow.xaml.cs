﻿using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using Repo;
using Model;
using Controller;

namespace ZdravoCorporation
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Room> rooms { get; set; }
        public RoomController roomController { get; set; }
        #region NotifyProperties
        public int id;
        public int floor;
        public string type;
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
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                if (value != floor)
                {
                    floor = value;
                    OnPropertyChanged("Floor");
                }
            }
        }

        public string Type
        {

            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }

        }
        #endregion
        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            rooms = new ObservableCollection<Room>();
            roomController = new RoomController();
            rooms = roomController.GetAll();
            id = 100;
            floor = 100;
            type = "operatingRoom";
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)dataGridRooms.SelectedItem;
            if (dataGridRooms.Items.Count > 0)
            {
                if (selected == null)
                {
                    MessageBox.Show("Niste izabrali prostoriju", "Error");
                }
                else
                {
                    roomController.DeleteById(selected.id);
                }
            }
            else {
                MessageBox.Show("Nije moguce brisati iz prazne tabele", "Error");
            }
            
            
           
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RoomType type1;
            switch (type)
            {
                case "operatingRoom":
                    type1 = RoomType.operatingRoom;
                    break;
                case "laboratory":
                    type1 = RoomType.laboratory;
                    break;
                default:
                    type1 = RoomType.operatingRoom;
                    break;
            }
            roomController.Create(id, floor, type1);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RoomType type1;
            switch (type)
            {
                case "operatingRoom":
                    type1 = RoomType.operatingRoom;
                    break;
                case "laboratory":
                    type1 = RoomType.laboratory;
                    break;
                default:
                    type1 = RoomType.operatingRoom;
                    break;
            }
            roomController.Update(id, type1);
            dataGridRooms.Items.Refresh();
        }
    }
}
