using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Zdravo.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController apController;
        VacationController vacationController;
        private ObservableCollection<Appointment> appointments;
        private DataGrid table;
        private int doctorId;
        private string date;
        public string Date { get { return date; } set { date = value; } }
        private int hours;
        public int Hours { get { return hours; } set { hours = value; } }
        private int minutes;
        public int Minutes { get { return minutes; } set { minutes = value; } }

        private string startDate;
        public string StartDate { get { return startDate; } set { startDate = value; } }

        private string endDate;
        public string EndDate { get { return endDate; } set { endDate = value; } }

        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }


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

        

        public DoctorHomeViewModel(DataGrid table,int doctorId)
        {
            var app = Application.Current as App;
            apController = app.appointmentController;
            vacationController=app.vacationController;
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

        

        internal void SearchTable()
        {
            appointments=apController.SearchTable(Date,Hours,Minutes);
            NotifyPropertyChanged("Appointments");
        }

        internal void ResetTable()
        {
            Appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
        }

        internal int ScheduleVacation()
        {
            return vacationController.ScheduleVacation(doctorId,startDate,endDate,reason);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
