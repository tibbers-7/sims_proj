// File:    AppointmentRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:16:12 PM
// Purpose: Definition of Class AppointmentRepository

using FileHandler;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zdravo.Repository;
using Zdravo.Model;
using Zdravo.Repository;
using Repo;
using Repository;

namespace Repository
{
   public class AppointmentRepository
   {
      public AppointmentFileHandler fileHandler=new AppointmentFileHandler();
        private PatientRepository patientRepository;
        private List<Appointment> appointments;
        private int idCount;

        public AppointmentRepository()
        {
            appointments = fileHandler.Read();
            idCount= appointments.Count;

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
               // Patient p = prepo.GetById(0);
                Doctor d = drepo.getById(a.Doctor);
                if (p!=null && d != null)
                {
                    AppointmentRecord record = new AppointmentRecord(a.Id, p.Ime, p.Prezime, d.Name, d.LastName, d.Specialization, a.Date, a.Time,p.Id.ToString());
                    records.Add(record);
                }
                
            }
            return records;

        }
       // public ObservableCollection<AppointmentRecord> GetByName()
       // {
       //
       // }
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

            patientRepository = new PatientRepository();
            if (patientRepository.GetById(appt.Patient) == null) return false;
            patientRepository.GetById(appt.Patient).RemoveAppt(appt);
                
                fileHandler.Write(appt, 2);
                appointments = fileHandler.Read();
                return true;
        }
      
      public void CreateAppointment(Appointment appointment)
      {
            idCount = appointments.Last().Id+1;
            appointment.Id = idCount;
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