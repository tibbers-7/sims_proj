// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zdravo.Controller;

namespace Zdravo.Repository
{
    public class AppointmentRepository
   {
      public AppointmentFileHandler fileHandler=new AppointmentFileHandler();
        private PatientController patientController;
        private List<Appointment> appointments;
        private List<Appointment> doctorAppts;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;

        public AppointmentRepository(DoctorRepository doctorRepository,PatientRepository patientRepository)
        {
            InitList();
            this.patientRepository = patientRepository;
            this.doctorRepository=doctorRepository;
        }

        private void InitList()
        {
            List<object> apptList= fileHandler.Read();
            appointments = new List<Appointment>();
            foreach (object appt in apptList)
            {
                Appointment appointment = (Appointment) appt;
                appointments.Add(appointment);
            }
        }

        public List<Appointment> GetAll()
      {
            InitList();
            return appointments;
         
      }
        public ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            InitList();
            ObservableCollection < AppointmentRecord > records = new ObservableCollection<AppointmentRecord>();
            foreach(Appointment a in appointments)
            {
                Patient p = patientRepository.GetById(a.Patient);
                Doctor d = doctorRepository.getById(a.Doctor);
                if (p!=null && d != null)
                {
                    AppointmentRecord record = new AppointmentRecord(a.Id, p.Ime, p.Prezime, d.Name, d.LastName, d.Specialization, a.Date, a.Time,p.Id.ToString());
                    records.Add(record);
                }
                
            }
            return records;

        }

        internal List<Appointment> GetAppointmentsForDoctor(bool isUpcoming,int doctorId)
        {
            doctorAppts = new List<Appointment>();
            foreach(Appointment appt in appointments)
            {
                if (appt.Doctor == doctorId)
                { 
                    DateTime apptDateTime = appt.Date.ToDateTime(appt.Time);
                    int cmp = DateTime.Compare(apptDateTime,DateTime.Now);
                    if ((cmp >= 0 && isUpcoming) | (cmp<0 && !isUpcoming))
                    {
                        if (appt.Status == Zdravo.Status.accepted)
                            doctorAppts.Add(appt);
                    }
                }
               
            }
            return doctorAppts;
        }
        public Appointment GetByID(int idAppointment)
      {
            InitList();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == idAppointment)
                {
                    return appointment; 
                }
            }

            return null;
      }
      
      

        internal ObservableCollection<Appointment> SearchTable(int doctorId,DateOnly date, int hours, int minutes)
        {
            ObservableCollection<Appointment> list=new ObservableCollection<Appointment>();
            DateOnly _date;
            TimeOnly _time=new TimeOnly(hours,minutes);
            int cmp = DateTime.Compare(new DateTime(), date.ToDateTime(TimeOnly.Parse("12:00 AM")));
            if (cmp==0) _date = DateOnly.FromDateTime(DateTime.Now); else _date = date;
            DateTime datetime = _date.ToDateTime(_time);
            
            foreach(Appointment appointment in appointments)
            {
                if (appointment.Status == Zdravo.Status.accepted)
                {
                    if (appointment.Doctor == doctorId)
                    {
                        DateTime apptDatetime = appointment.Date.ToDateTime(appointment.Time);
                        int cmp2 = DateTime.Compare(apptDatetime, datetime);
                        if (cmp2 > 0) list.Add(appointment);   // Show appointments after the specified date and time
                    }

                }
            }

            return list;
        }

        public void AddNew(Appointment appointment)
      {
            int listCount = appointments.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = appointments[i].ToCSV();
            }
            newLines[listCount] = appointment.ToCSV();
            fileHandler.Write(newLines);
            InitList();
        }

        internal void Update(Appointment newAppt)
        {
            int listCount = appointments.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Appointment appt in appointments)
            {
                if (appt.Id != newAppt.Id)
                {
                    newLines[i] = appt.ToCSV();
                    i++;
                }
                else newLines[i] = newAppt.ToCSV();
            }
            fileHandler.Write(newLines);
            InitList();
        }

        public bool Delete(int idAppointment)
        {

            Appointment appointment = GetByID(idAppointment);
            if (appointment == null) return false;

            if (patientController.GetById(appointment.Patient) == null) return false;
            patientController.GetById(appointment.Patient).RemoveAppt(appointment);

            int listCount = appointments.Count;
            string[] newLines = new string[listCount];

            newLines = new string[listCount - 1];
            int i = 0;
            foreach (Appointment newApt in appointments)
            {
                if (newApt.Id != appointment.Id)
                {
                    newLines[i] = newApt.ToCSV();
                    i++;
                }
            }

            fileHandler.Write(newLines);
            InitList();
            return true;
        }


    }
}