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
        private ReportPrescriptionService reportPrescriptionService;

        public AppointmentController(AppointmentService _service,PatientController patientController, DoctorRepository doctorRepository, DrugController drugController, ReportPrescriptionService reportPrescriptionService)
        {
            service = _service;
            this.patientController = patientController;
            this.doctorRepository = doctorRepository;
            this.drugController = drugController;
            this.reportPrescriptionService = reportPrescriptionService;
            
        }

        internal ObservableCollection<Drug> SetAllergies(ObservableCollection<Drug> drugs,int appointmentId)
        {
            Patient patient = patientController.GetById(GetById(appointmentId).Patient);
            return drugController.SetAllergies(drugs, patient);
        }

        public List<Appointment> GetUpcomingAppointmentsForDoctor(int doctorId)
        {
            return service.GetAppointmentsForDoctor(true,doctorId);
        }

        internal ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            return service.GetAllRecords();
        }

        internal string GetDoctorInfo(int doctorId)
        {
            return doctorRepository.GetDoctorInfo(doctorId);
        }

        public int CreateAppointment(int patientId, int doctor, int roomId, int hours, int minutes, int duration, string date, bool emergency)
        {
            Appointment appt = new Appointment() { Date = DateOnly.Parse(date), Time = new TimeOnly(hours, minutes), Doctor = doctor, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, Status = Status.accepted, DoctorSchedules = doctor, Type = 'A' };
            return service.CreateAppointment(appt,patientId,null);
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

        internal int CreateReferral(int patientId, int doctorId, string doctorSpec, bool isAppt, bool emergency)
        {
            char type;
            if (isAppt) type = 'A'; else type = 'O';
            Appointment appointment = new Appointment() { Patient = patientId, Emergency = emergency, Status = Status.waiting, Type=type, DoctorSchedules = doctorId};
            return service.CreateAppointment(appointment,patientId,doctorSpec);
        }

        internal int AddPrescription(int patient, int drugId, DateTime now)
        {
            Prescription presc = new Prescription() { Date = DateOnly.FromDateTime(now), PatientId = patient };
            return reportPrescriptionService.AddPrescription(presc,drugId);
        }

        public int DeleteAppointment(int id)
        {
            return service.DeleteAppointment(id);
        }

        internal bool CheckAllergies(int drugId,ObservableCollection<Drug> drugs)
        {
            return drugController.GetAllergenConflicts(drugId, drugs);
        }
        
        public int UpdateAppointment(int id, int patientId,int doctorId, int roomId, int hours, int minutes, int duration,string date, bool emergency)
        {
            Appointment appt = new Appointment() { Id = id, Date = Tools.ParseDate(date), Time = new TimeOnly(hours, minutes), Doctor = doctorId, Duration = duration, Patient = patientId, Room = roomId, Emergency = emergency, DoctorSchedules=doctorId, Type='A', Status = Status.accepted };
            return service.UpdateAppointment(appt);
        }

        internal int CreateReport(int apptId,string date, string diagnosis, string _report,string anamnesis)
        {
            Appointment appt=GetById(apptId);
            Report report = new Report() { Date = Tools.ParseDate(date), PatientId = appt.Patient, ReportString = _report, Diagnosis = diagnosis, Anamnesis=anamnesis };
            return reportPrescriptionService.CreateReport(appt,report);
        }

        internal int UpdateReport(int patientId,int reportId, string date, string diagnosis, string reportString,string anamnesis)
        {
            return reportPrescriptionService.UpdateReport(patientId,reportId, Tools.ParseDate(date), diagnosis, reportString,anamnesis);
        }
        public List<Appointment> GetAll()
        {
          return service.GetAll();
        }

        public Appointment GetById(int id)
        {
            return service.GetById(id);
        }

        public bool IsReportAvailable(int id)
        {
            return reportPrescriptionService.IsReportAvailable(GetById(id));
        }

        public Report GetReport(int id)
        {
            return reportPrescriptionService.GetReportById(id);
        }
    }
}