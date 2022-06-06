﻿using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using Repository;
using Zdravo.Repository;
using System.Windows;
using Zdravo.Controller;

namespace Zdravo.ViewModel
{
    public class AppointmentRecordViewModel
    {
        private ObservableCollection<AppointmentRecord> records;
        private AppointmentController controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AppointmentRecord> Records
        {
            get
            {
                return records;
            }
            set
            {
                if (records == value)
                    return;
                records = controller.GetAllRecords();
                NotifyPropertyChanged("Records");
            }
        }
        public AppointmentRecordViewModel()
        {
            var app = Application.Current as App;
            controller = app.appointmentController;
            records = controller.GetAllRecords();
        }
        public AppointmentRecordViewModel(ObservableCollection<AppointmentRecord> rec)
        {
            var app = Application.Current as App;
            controller = app.appointmentController;
            records = rec;
        }
        public void Refresh()
        {
            records = controller.GetAllRecords();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
