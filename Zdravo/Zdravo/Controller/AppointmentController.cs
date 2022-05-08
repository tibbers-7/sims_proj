// File:    AppointmentController.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:58:38 PM
// Purpose: Definition of Class AppointmentController

using Model;
using Repo;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo.Model;
using Zdravo.Repository;

namespace Controller
{
   public class AppointmentController
   {
        private AppointmentService service;
       private PatientController patientController;
        private RoomController roomController;

      public AppointmentController()
        {
            service = new AppointmentService();
            roomController = new RoomController();
            patientController = new PatientController();
            
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return service.GetAppointmentsForDoctor(doctorId);
        }

        
        public int CreateAppointment(int patientId, int doctor, int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;
            
            DateOnly date = new DateOnly();
            try
            {
                date = new DateOnly(year, month, day);
            }
            catch (Exception e)
            {
                // Invalid date error
                return 2;
            }


            TimeOnly _time = new TimeOnly(hours, minutes);
            DateTime datetime = date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) return 3;   // Cannot make appointment in the past

            Appointment appt = new Appointment() { Date = date, Time = _time, Doctor = doctor, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency };
            service.CreateAppointment(appt);
            

            return 0;


        }

        internal void AddPrescription(int patient, string selectedDrug, DateTime now)
        {
            Prescription presc = new Prescription() { Date = DateOnly.FromDateTime(now), PatientId = patient };
            service.AddPrescription(presc,selectedDrug);
        }

        public bool DeleteAppointment(int id)
        {
            return service.DeleteAppointment(id);
        }

        //should update in the patient's list too
        public int UpdateAppointment(int id, int patientId,int doctorId, int roomId, int hours, int minutes, int duration, int day, int month, int year, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;

            DateOnly date = new DateOnly();
            TimeOnly _time = new TimeOnly(hours, minutes);
            try
            {
                date = new DateOnly(year, month, day);
            }
            catch (Exception e)
            {
                return 2;
            }
            DateTime datetime = date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) return 3;   // Cannot make appointment in the past

            
            Appointment appt = new Appointment() { Id = id, Date = date, Time = _time, Doctor = doctorId, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency };
            service.UpdateAppointment(appt);
            return 0;
        }

        //link report to patient
        internal void CreateReport(int apptId,DateOnly date, string diagnosis, string report)
        {
            Appointment appt=service.GetAppointment(apptId);
            Report rpt = new Report() { Date = date, PatientId = appt.Patient, ReportString = report, Diagnosis = diagnosis };

            // Change to controller later
            Patient p = patientController.GetById(appt.Patient);
            p.AddReport(rpt);
            service.AddReport(rpt);
        }

        internal void UpdateReport(int patientId,int reportId, DateOnly date, string diagnosis, string reportString)
        {
            service.UpdateReport(patientId,reportId, date, diagnosis, reportString);
        }

        internal bool CheckAllergies(int appointmentId, string selectedDrug)
        {
            return service.CheckAllergies(appointmentId,selectedDrug);
        }

        internal ObservableCollection<string> GetAllDrugNames()
        {
            return new ObservableCollection<string>(service.GetAllDrugNames());
        }


      public List<Appointment> GetAll()
        {
          return service.GetAll();
      }
       

        public Appointment GetAppointment(int id)
        {
            return service.GetAppointment(id);
        }

        public bool IsReportAvailable(int id)
        {
            Appointment appt = GetAppointment(id);
            DateTime datetime = appt.Date.ToDateTime(appt.Time);
            if (DateTime.Compare(DateTime.Now, datetime) > 0) return true;
            return false;
        }

        public Report GetReport(int id)
        {
            return service.GetReportById(id);
        }

        
        
    }
}