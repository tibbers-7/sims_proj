﻿using Model;
using Repository;
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
using Controller;

namespace Zdravo.managerView
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window, INotifyPropertyChanged
    {
        public ObservableCollection<StaticEquipment> equipment { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private EquipmentController equipmentController;
        private RoomRepository roomRepo;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Equipment(Room room)
        {
            InitializeComponent();
            int roomId = room.id;
            roomRepo = new RoomRepository();
            Room roomm = roomRepo.GetById(roomId);
            this.DataContext = this;
            equipment = new ObservableCollection<StaticEquipment>();
            equipmentController = new EquipmentController();
            ObservableCollection<StaticEquipment> allEquipment = equipmentController.GetAll();
            foreach (int eqId in roomm.equipmentIds)
            {
                foreach (StaticEquipment eq in allEquipment)
                {
                    if (eq.id == eqId) {
                        equipment.Add(eq);
                    }
                }
            }
            tb_roomId.Text = room.id.ToString();
        }
    }
}
