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
using Zdravo.Service;

namespace Zdravo.Controller
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

        public List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId)
        {
            return service.GetAppointmentsForDoctor(true,doctorId);
        }

        internal ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            return service.GetAllRecords();
        }

        public int CreateAppointment(int patientId, int doctor, int roomId, int hours, int minutes, int duration, string date, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;

            TimeOnly _time = new TimeOnly(hours, minutes);
            DateOnly _date = ParseDate(date);
            DateTime datetime = _date.ToDateTime(_time);
           // int cmp = DateTime.Compare(datetime, DateTime.Now);
         //   if (cmp < 0) return 2;   // Cannot make appointment in the past

            Appointment appt = new Appointment() { Date = _date, Time = _time, Doctor = doctor, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, Status = Status.accepted, DoctorSchedules = doctor, Type = 'A' };
            service.CreateAppointment(appt);
            

            return 0;


        }

        internal List<Appointment> GetPassedAppointmentsForDoctor(int doctorId)
        {
            return service.GetAppointmentsForDoctor(false,doctorId);
        }

        internal ObservableCollection<string> GetAllSpetializations()
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            return new ObservableCollection<string>(doctorRepository.GetAllSpetializations());
        }

        // 1-patient doesn't exist
        // 2-doctor specialization
        internal int CreateReferral(int patientId, int doctorId, string doctorSpec, bool isAppt, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;
            Doctor d = patientController.GetChosenDoctor(doctorSpec, patientId);
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

        // 1-patient doesn't exist
        // 2-specified time is in past
        public int UpdateAppointment(int id, int patientId,int doctorId, int roomId, int hours, int minutes, int duration,string date, bool emergency)
        {
            Patient p = patientController.GetById(patientId);
            if (p == null) return 1;
            TimeOnly _time = new TimeOnly(hours, minutes);
            DateOnly _date = ParseDate(date);
            if (!IsInPast(_date,_time)) return 2;

            
            Appointment appt = new Appointment() { Id = id, Date = _date, Time = _time, Doctor = doctorId, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, DoctorSchedules=doctorId, Type='A', Status = Status.accepted };
            service.UpdateAppointment(appt);
            return 0;
        }

        public static bool IsInPast(DateOnly date, TimeOnly time)
        {
            DateTime datetime = date.ToDateTime(time);
            int cmp = DateTime.Compare(datetime, DateTime.Now);
            if (cmp < 0) return false;
            return true;
        }



        internal void CreateReport(int apptId,string date, string diagnosis, string _report,string anamnesis)
        {
            Appointment appt=GetAppointment(apptId);
            Report report = new Report() { Date = ParseDate(date), PatientId = appt.Patient, ReportString = _report, Diagnosis = diagnosis, Anamnesis=anamnesis };
            service.AddReport(report);
            patientController.AddReport(report,appt);
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