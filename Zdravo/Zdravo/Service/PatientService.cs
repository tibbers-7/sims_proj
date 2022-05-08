/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using System;
using Model;
using Controller;
using Service;
using FileHandler;
using Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo.DoctorWindows;
using Zdravo.Model;
using Zdravo.Repository;

namespace Service
{
    
   public class PatientService

   {

        private PatientRepository p;
        public PatientService()
        {
            p = new PatientRepository();
            ReportRepository reportRepository = new ReportRepository();
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
            
            foreach (Report report in reportRepository.reports)
            {
                if(p.GetById(report.PatientId)!=null) p.GetById(report.PatientId).AddReport(report);
            }

            foreach(Prescription presc in prescriptionRepository.prescriptions)
            {
                if (p.GetById(presc.PatientId) != null) p.GetById(presc.PatientId).AddPrescription(presc);
            }


        }
        public string checkId()
        {
            
            ObservableCollection<Patient> patients = p.GetAll();
            int sifra = 0;
            for(int i = 0; i < patients.Count; i++)
            {
                if (i == patients.Count - 1) sifra = i+2;
            }
            return sifra.ToString();
        }

        public void removeAllergen(Patient patient,Allergen allergen)
        {
            p = new PatientRepository();
            p.removeAllergen(patient,allergen);
        }
        internal ObservableCollection<Prescription> GetPrescriptions(int patientId)
        {
            Patient patient = p.GetById(patientId);
            return new ObservableCollection<Prescription>(patient.Prescriptions);
        }

        internal ObservableCollection<Patient> GetAll()
        {
            return p.GetAll();
        }

        internal Patient GetById(int patientId)
        {
            return p.GetById(patientId);
        }

        internal ObservableCollection<Report> GetReports(int patientId)
        {
            Patient patient = p.GetById(patientId);
            return new ObservableCollection<Report>(patient.Reports);
        }
        
   
   }

        
 }
