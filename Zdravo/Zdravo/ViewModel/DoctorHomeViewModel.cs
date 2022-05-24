using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Zdravo.Controller;
using Zdravo.DoctorView;
using Zdravo.DoctorWindows;

namespace Zdravo.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController apController;
        VacationController vacationController;
        DrugController drugController;
        private ObservableCollection<Appointment> upcomingAppointments;
        private ObservableCollection<Appointment> passedAppointments;
        private ObservableCollection<VacationString> vacations;
        private ObservableCollection<Drug> drugs;
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


        public ObservableCollection<Appointment> UpcomingAppointments
        {
            get
            {
                return upcomingAppointments;
            }
            set
            {
                if (upcomingAppointments == value)
                    return;
                upcomingAppointments = new ObservableCollection<Appointment>(apController.GetPassedAppointmentsForDoctor(doctorId));
                NotifyPropertyChanged("UpcomingAppointments");
            }
        }

        public ObservableCollection<Appointment> PassedAppointments
        {
            get
            {
                return passedAppointments;
            }
            set
            {
                if (passedAppointments == value)
                    return;
                passedAppointments = new ObservableCollection<Appointment>(apController.GetPassedAppointmentsForDoctor(doctorId));
                NotifyPropertyChanged("PassedAppointments");
            }
        }

        public ObservableCollection<VacationString> Vacations
        {
            get
            {
                return vacations;
            }
            set
            {
                if (vacations == value)
                    return;
                vacations = new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
                NotifyPropertyChanged("Vacations");
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public DoctorHomeViewModel(int doctorId)
        {
            var app = Application.Current as App;
            apController = app.appointmentController;
            drugController = app.drugController;
            vacationController=app.vacationController;
            this.doctorId=doctorId;
            upcomingAppointments = new ObservableCollection<Appointment>(apController.GetUpcomingAppointmentsForDoctor(doctorId));
            passedAppointments = new ObservableCollection<Appointment>(apController.GetPassedAppointmentsForDoctor(doctorId));
            drugs=new ObservableCollection<Drug>(drugController.GetValidDrugs());
            vacations= new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
            
        }

        internal void DrugShow(int drugId)
        {
            DrugWindow drugWindow = new DrugWindow(this, drugId);
            drugWindow.Show();
        }
        internal void ShowReferral()
        {
            ReferralWindow referralWindow = new ReferralWindow(doctorId);
            referralWindow.Show();
        }

        internal void ShowAppointment(int id)
        {
            NewAppointment updateAppointment = new NewAppointment(this, id, doctorId,false);
            updateAppointment.Show();
        }

        public void RefreshAppointments()
        {
            UpcomingAppointments = new ObservableCollection<Appointment>(apController.GetPassedAppointmentsForDoctor(doctorId));
            passedAppointments = new ObservableCollection<Appointment>(apController.GetPassedAppointmentsForDoctor(doctorId));
            
        }

        public void RefreshDrugs()
        {
            Drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
        }

        public void NewAppointment()
        {
             NewAppointment newAppointment = new NewAppointment(this,0,doctorId,true);
            newAppointment.Show();
        }

        

        internal void SearchTable()
        {
            upcomingAppointments=apController.SearchTable(doctorId,Date,Hours,Minutes);

            NotifyPropertyChanged("Appointments");
        }

        internal void UpdateAppointment(int id)
        {
            NewAppointment updateAppointment = new NewAppointment(this, id, doctorId,true);
            updateAppointment.Show();
        }

        internal int ScheduleVacation(bool emergency)
        {
            return vacationController.ScheduleVacation(doctorId,startDate,endDate,reason, emergency);
        }

        

        internal void ReportShow(int id)
        {
            ReportWindow reportWindow = new ReportWindow(id, 0, 0, null);
            reportWindow.Show();
        }

        internal void DeleteAppt(int id)
        {
            bool success = apController.DeleteAppointment(id);
            if (success) RefreshAppointments();
            else MessageBox.Show("Nepoznata greška: Ne može se obrisati!", "Greška");
            
        }
    }
}
