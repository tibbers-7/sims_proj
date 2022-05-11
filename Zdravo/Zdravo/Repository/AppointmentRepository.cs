// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Controller;

namespace Repository
{
    public class AppointmentRepository
   {
      public AppointmentFileHandler fileHandler=new AppointmentFileHandler();
        private PatientController patientController;
        private List<Appointment> appointments;
        private List<Appointment> doctorAppts;
        private int idCount;

        public AppointmentRepository()
        {
            appointments = fileHandler.Read();
        }

        public List<Appointment> GetAll()
      {
            appointments = fileHandler.Read();
            return appointments;
         
      }
        public ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            PatientRepository prepo = new PatientRepository();
            DoctorRepository drepo = new DoctorRepository();
            appointments = fileHandler.Read();
            ObservableCollection < AppointmentRecord > records = new ObservableCollection<AppointmentRecord>();
            foreach(Appointment a in appointments)
            {
                Patient p = prepo.GetById(a.Patient);
                Doctor d = drepo.getById(a.Doctor);
                if (p!=null && d != null)
                {
                    AppointmentRecord record = new AppointmentRecord(a.Id, p.Ime, p.Prezime, d.Name, d.LastName, d.Specialization, a.Date, a.Time,p.Id.ToString());
                    records.Add(record);
                }
                
            }
            return records;

        }

        internal List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            doctorAppts = new List<Appointment>();
            foreach(Appointment appt in appointments)
            {
                if (appt.Doctor == doctorId) doctorAppts.Add(appt);                
               
            }
            return doctorAppts;
        }
        public Appointment GetByID(int idAppointment)
      {
            appointments=fileHandler.Read();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == idAppointment)
                {
                    return appointment; 
                }
            }

            return null;
      }
      
      public bool DeleteAppointment(int idAppointment)
      {

            Appointment appt= GetByID(idAppointment);
            if (appt == null) return false;

            patientController = new PatientController();
            if (patientController.GetById(appt.Patient) == null) return false;
            patientController.GetById(appt.Patient).RemoveAppt(appt);
                
                fileHandler.Write(appt, 2);
                appointments = fileHandler.Read();
                return true;
        }

        internal ObservableCollection<Appointment> SearchTable(DateOnly date, int hours, int minutes)
        {
            ObservableCollection<Appointment> list=new ObservableCollection<Appointment>();
            DateOnly _date;
            TimeOnly _time=new TimeOnly(hours,minutes);
            if (date.Equals("")) _date = DateOnly.FromDateTime(DateTime.Now); else _date = date;
            DateTime datetime = _date.ToDateTime(_time);
            
            foreach(Appointment appointment in appointments)
            {
                DateTime apptDatetime = appointment.Date.ToDateTime(appointment.Time);
                int cmp = DateTime.Compare(apptDatetime,datetime);
                if (cmp > 0) list.Add(appointment);   // Show appointments after the specified date and time
                
            }

            return list;
        }

        public void CreateAppointment(Appointment appointment)
      {
            appointment.Id = appointments.Last().Id + 1;
            fileHandler.Write(appointment,0);
            appointments = fileHandler.Read();
      }

        internal void UpdateAppointment(Appointment appt)
        {
            fileHandler.Write(appt,1);
            appointments = fileHandler.Read();
        }

        
    }
}