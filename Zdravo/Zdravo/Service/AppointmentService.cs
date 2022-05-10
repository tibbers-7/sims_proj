// File:    AppointmentService.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:47:00 PM
// Purpose: Definition of Class AppointmentService

using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo.DoctorWindows;
using Zdravo.Model;
using Zdravo.Repository;

namespace Service
{
   public class AppointmentService
   {
      private AppointmentRepository appointmentRepo;
      private RoomRepository roomRepo;
      private PatientRepository patientRepo=new PatientRepository();
      private DrugRepository drugRepo=new DrugRepository();
        private ReportRepository reportRepo=new ReportRepository();
        private PrescriptionRepository prescriptionRepo=new PrescriptionRepository();
      
        public AppointmentService()
        {
            
            appointmentRepo= new AppointmentRepository();
        }

        internal List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return appointmentRepo.GetAppointmentsForDoctor(doctorId);
        }

        internal List<Appointment> GetAll()
        {
            return appointmentRepo.GetAll();
        }
        public List<Appointment> GetByDoctorID(int idDoctor)
      {
            List<Appointment> result= new List<Appointment>();
         foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Doctor==idDoctor) result.Add(appt);
            }

         return result;
      }
      
      public List<Appointment> GetByRoomID(int idRoom)
      {
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Room.Equals(idRoom)) result.Add(appt);
            }

            return result;
        }

        

        public List<Appointment> GetByPatientID(int idPatient)
      {
            List<Appointment> result = new List<Appointment>();
            foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Patient == idPatient) result.Add(appt);
            }

            return result;
        }

        internal bool CheckAllergies(int appointmentId, string selectedDrug)
        {
            Appointment appointment = appointmentRepo.GetByID(appointmentId);
            Patient patient = patientRepo.GetById(appointment.Patient);
            if (patient.Allergens == null) return true;
            foreach(Allergen allergen in patient.Allergens)
            {
                if (allergen.Name.Equals(selectedDrug)) return false;
            }
            return true;
        }

        public void CreateAppointment(Appointment appt)
        {
            appointmentRepo.CreateAppointment(appt);
        }


        internal Appointment GetAppointment(int id)
        {
            return appointmentRepo.GetByID(id);
        }

        public bool DeleteAppointment(int id)
      {
         return appointmentRepo.DeleteAppointment(id);
      }

        internal void UpdateAppointment(Appointment appt)
        {
            appointmentRepo.UpdateAppointment(appt);

        }


        internal Report UpdateReport(int patientId,int reportId, DateOnly date, string diagnosis, string reportString)
        {
            Report rpt=new Report() { PatientId=patientId, Id=reportId, ReportString= reportString, Diagnosis=diagnosis,Date=date };
            reportRepo.UpdateReport(rpt); //updating in file
            patientRepo.UpdateReport(rpt,patientId); //updating in patient list
            return rpt;
        }

        internal void AddReport(Report rpt)
        {
            reportRepo.AddReport(rpt);
        }

        internal Report GetReportById(int id)
        {
            return reportRepo.GetReportById(id);
        }

        internal void AddPrescription(Prescription p,string selectedDrug)
        {
            p.DrugId = drugRepo.GetByName(selectedDrug).Id;
            prescriptionRepo.AddPrescription(p);
        }

        internal List<string> GetAllDrugNames()
        {
            return drugRepo.GetAllDrugNames();
        }
    }
}