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
        private readonly AppointmentFileHandler fileHandler=new AppointmentFileHandler();
        private List<Appointment> appointments;
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;
        private int errorCode;
        public AppointmentRepository(DoctorRepository doctorRepository,PatientRepository patientRepository)
        {
            
            InitList();
            this.patientRepository = patientRepository;
            this.doctorRepository=doctorRepository;
        }

        private void InitList()
        {
            appointments = new List<Appointment>();
            List<object> apptList= fileHandler.Read();
            
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

        //Darko
        public ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            InitList();
            ObservableCollection<AppointmentRecord> records = new ObservableCollection<AppointmentRecord>();
            foreach (Appointment appointment in appointments)
            {
                Patient patient = patientRepository.GetById(appointment.Patient);
                Doctor doctor = doctorRepository.getById(appointment.Doctor);
                if (patient != null && doctor != null)
                {
                    AppointmentRecord record = new AppointmentRecord(appointment.Id, patient.Ime, patient.Prezime, doctor.Name, doctor.LastName, doctor.Specialization, appointment.Date, appointment.Time, patient.Id.ToString());
                    records.Add(record);
                }

            }
            return records;
        }

        public Appointment GetByID(int id)
        {
            InitList();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    return appointment; 
                }
            }

            return null;
        }
      
        public int AddNew(Appointment appointment)
        {
            appointment.Id = appointments.Last().Id + 1;
            int listCount = appointments.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = appointments[i].ToCSV();
            }
            newLines[listCount] = appointment.ToCSV();
            errorCode=fileHandler.Write(newLines);
            InitList();
            return errorCode;
        }

        internal int Update(Appointment newAppt)
        {
            int listCount = appointments.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Appointment appt in appointments)
            {
                if (appt.Id != newAppt.Id)  newLines[i] = appt.ToCSV();
                else newLines[i] = newAppt.ToCSV();
                i++;
            }
            errorCode=fileHandler.Write(newLines);
            InitList();
            return errorCode;
        }

        public int Delete(int idAppointment)
        {

            int listCount = appointments.Count;
            string[] newLines = new string[listCount - 1];
            int i = 0;
            foreach (Appointment newApt in appointments)
            {
                if (newApt.Id != idAppointment)  newLines[i] = newApt.ToCSV();
                i++;
            }

            errorCode=fileHandler.Write(newLines);
            InitList();
            return errorCode;
        }


    }
}