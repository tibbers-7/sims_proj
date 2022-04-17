using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController apController;
        private ObservableCollection<Appointment> appointments;

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
                appointments = apController.GetAll();
                NotifyPropertyChanged("Appointments");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DoctorHomeViewModel()
        {
            apController = new AppointmentController();
            appointments = apController.GetAll();
        }

        public void MenuShow(int rowId)
        {
            AppointmentMenu menu = new AppointmentMenu(rowId, this);
            menu.Show();
            if (!menu.IsActive) RefreshAppointments();
        }
        public void RefreshAppointments()
        {
            appointments = apController.GetAll();
        }

        public void NewAppointment()
        {
             NewAppointment newAppointment = new NewAppointment(0);
             newAppointment.Show();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
