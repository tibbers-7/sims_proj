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
using Zdravo.Controller;
using static System.Net.Mime.MediaTypeNames;

namespace Controller
{
   public class AppointmentController
   {
        private AppointmentService service;
       private PatientController patientController;
        private DoctorRepository doctorRepository;
        private DrugController drugController;

      public AppointmentController(AppointmentService _service,PatientController patientController, DoctorRepository doctorRepository, DrugController drugController)
        {
            service = _service;
            this.patientController = patientController;
            this.doctorRepository = doctorRepository;
            this.drugController = drugController;
            
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

            Appointment appt = new Appointment() { Date = _date, Time = _time, Doctor = doctor, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, Status = Status.accepted, DoctorSchedules = doctor, Type = 'A' };
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

        

        internal void AddPrescription(int patient, int drugId, DateTime now)
        {
            Prescription presc = new Prescription() { Date = DateOnly.FromDateTime(now), PatientId = patient };
            service.AddPrescription(presc,drugId);
        }

        public bool DeleteAppointment(int id)
        {
            return service.DeleteAppointment(id);
        }

        internal bool CheckAllergies(int appointmentId, int drugId)
        {
            Drug drug=drugController.GetById(drugId);
            return service.CheckAllergies(appointmentId, drug);
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

            
            Appointment appt = new Appointment() { Id = id, Date = _date, Time = _time, Doctor = doctorId, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, DoctorSchedules=doctorId, Type='A', Status = Status.accepted };
            service.UpdateAppointment(appt);
            return 0;
        }


        //link report to patient
        internal void CreateReport(int apptId,string date, string diagnosis, string report,string anamnesis)
        {
            Appointment appt=service.GetAppointment(apptId);
            Report rpt = new Report() { Date = ParseDate(date), PatientId = appt.Patient, ReportString = report, Diagnosis = diagnosis, Anamnesis=anamnesis };

            // Change to controller later
            Patient p = patientController.GetById(appt.Patient);
            p.AddReport(rpt);
            service.AddReport(rpt);
        }

        internal void UpdateReport(int patientId,int reportId, string date, string diagnosis, string reportString,string anamnesis)
        {
            service.UpdateReport(patientId,reportId, ParseDate(date), diagnosis, reportString,anamnesis);
        }

        


      public List<Appointment> GetAll()
        {
          return service.GetAll();
      }

        public string GetDoctorInfo(int doctorId)
        {
            Doctor doctor=doctorRepository.getById(doctorId);
            string res = doctor.Name + " " + doctor.LastName + ", " + doctor.Specialization;
            return res;
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