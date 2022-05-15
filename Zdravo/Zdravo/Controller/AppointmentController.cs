// File:    AppointmentController.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:58:38 PM
// Purpose: Definition of Class AppointmentController

using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Zdravo;
using static System.Net.Mime.MediaTypeNames;

namespace Controller
{
   public class AppointmentController
   {
        private AppointmentService service;
       private PatientController patientController;

      public AppointmentController(AppointmentService _service,PatientController patientController)
        {
            service = _service;
            this.patientController = patientController;
            
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return service.GetAppointmentsForDoctor(doctorId);
        }

        
        public int CreateAppointment(int patientId, int doctor, int roomId, int hours, int minutes, int duration, string date, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;

            TimeOnly _time = new TimeOnly(hours, minutes);
            DateOnly _date=ParseDate(date);
            DateTime datetime = _date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) return 2;   // Cannot make appointment in the past

            Appointment appt = new Appointment() { Date = _date, Time = _time, Doctor = doctor, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, Status = Status.waiting, DoctorSchedules=doctor };
            service.CreateAppointment(appt);
            

            return 0;


        }

        internal ObservableCollection<string> GetAllSpetializations()
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            return new ObservableCollection<string>(doctorRepository.GetAllSpetializations());
        }

        internal int CreateReferral(int patientId, int doctorId, string doctorSpecialty, bool isAppt, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;
            Doctor d = patientController.GetChosenDoctor(doctorSpecialty,patientId);
            if (d == null) return 2;
            char type;
            if (isAppt) type = 'A'; else type = 'O';


            Appointment appointment = new Appointment() { Patient = patientId, Emergency = emergency, Status = Status.waiting, Type = type, DoctorSchedules = doctorId, Doctor=d.Id};
            service.CreateAppointment(appointment);

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

        internal bool CheckAllergies(int appointmentId, string selectedDrug)
        {
            return service.CheckAllergies(appointmentId, selectedDrug);
        }
        internal ObservableCollection<Appointment> SearchTable(int doctorId,string date, int hours, int minutes)
        {
            DateOnly _date = ParseDate(date);
            return service.SearchTable(doctorId,_date, hours, minutes);
        }

        //should update in the patient's list too
        public int UpdateAppointment(int id, int patientId,int doctorId, int roomId, int hours, int minutes, int duration,string date, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;
            TimeOnly _time = new TimeOnly(hours, minutes);
            DateOnly _date = ParseDate(date);
            DateTime datetime = _date.ToDateTime(_time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) return 3;   // Cannot make appointment in the past

            
            Appointment appt = new Appointment() { Id = id, Date = _date, Time = _time, Doctor = doctorId, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, DoctorSchedules=doctorId, Type='A' };
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

        public static DateOnly ParseDate(string s)
        {
            
            DateOnly date=new DateOnly();
            if (s == null) return date;
            Regex regexObj = new Regex("(\\d+)/(\\d+)/(\\d+)");
            Match matchResult = regexObj.Match(s);
            if (matchResult.Success)
            {
                date = new DateOnly(int.Parse(matchResult.Groups[3].Value), int.Parse(matchResult.Groups[2].Value), int.Parse(matchResult.Groups[1].Value));
                return date;
            }
            else return date;
            
        }
        
        
    }
}