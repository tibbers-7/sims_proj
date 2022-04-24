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

        public DoctorHomeViewModel(DataGrid table)
        {
            this.table = table;
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
            
            Appointments = apController.GetAll();
            table.ItemsSource = Appointments;
        }

        public void NewAppointment()
        {
             NewAppointment newAppointment = new NewAppointment(this,0);
             newAppointment.Show();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
