using Controller;
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

namespace Zdravo.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController apController;
        private ObservableCollection<Appointment> appointments;
        private DataGrid table;
        private int doctorId;

        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                return appointments;
            }
            set
            {
                if (appointments == value)
                    return;
                appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
                NotifyPropertyChanged("Appointments");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DoctorHomeViewModel(DataGrid table,int doctorId)
        {
            var app = Application.Current as App;
            apController = app.appointmentController;
            this.table = table;
            this.doctorId=doctorId;
            appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
            
        }

        public void MenuShow(int rowId)
        {
            AppointmentMenu menu = new AppointmentMenu(rowId, this,doctorId);
            menu.Show();
            
        }
        public void RefreshAppointments()
        {
            
            Appointments = new ObservableCollection<Appointment>(apController.GetAll());
            table.ItemsSource = Appointments;
        }

        public void NewAppointment()
        {
             NewAppointment newAppointment = new NewAppointment(this,0,doctorId);
            newAppointment.Show();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
