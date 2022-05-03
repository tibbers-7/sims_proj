using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.table = table;
            this.doctorId=doctorId;
            apController = new AppointmentController();
            appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
            
        }

        public void MenuShow(int rowId)
        {
            AppointmentMenu menu = new AppointmentMenu(rowId, this,doctorId);
            menu.Show();
            if (!menu.IsActive) RefreshAppointments();
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
