using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Zdravo.Controller;
using Zdravo.DoctorView;

namespace Zdravo.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController apController;
        VacationController vacationController;
        DrugController drugController;
        private ObservableCollection<Appointment> appointments;
        private ObservableCollection<Drug> drugs;
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
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }


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

        public ObservableCollection<Drug> Drugs
        {
            get
            {
                return drugs;
            }
            set
            {
                if (drugs == value)
                    return;
                drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
                NotifyPropertyChanged("Drugs");
            }
        }

        internal void DrugShow(int drugId)
        {
            DrugWindow drugWindow = new DrugWindow(this,drugId);
            drugWindow.Show();
        }

        public DoctorHomeViewModel(DataGrid table,int doctorId)
        {
            var app = Application.Current as App;
            apController = app.appointmentController;
            drugController = app.drugController;
            vacationController=app.vacationController;
            this.table = table;
            this.doctorId=doctorId;
            appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
            drugs=new ObservableCollection<Drug>(drugController.GetValidDrugs());
            
        }

        internal void ShowReferral()
        {
            ReferralWindow referralWindow = new ReferralWindow(doctorId);
            referralWindow.Show();
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

        public void RefreshDrugs()
        {
            Drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
        }

        public void NewAppointment()
        {
             NewAppointment newAppointment = new NewAppointment(this,0,doctorId);
            newAppointment.Show();
        }

        

        internal void SearchTable()
        {
            appointments=apController.SearchTable(doctorId,Date,Hours,Minutes);
            NotifyPropertyChanged("Appointments");
        }

        internal void ResetTable()
        {
            Appointments = new ObservableCollection<Appointment>(apController.GetAppointmentsForDoctor(doctorId));
        }

        internal int ScheduleVacation(bool emergency)
        {
            return vacationController.ScheduleVacation(doctorId,startDate,endDate,reason, emergency);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
