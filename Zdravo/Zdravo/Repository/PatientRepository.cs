/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Darko
 * Purpose: Definition of the Class Repository.PatientRepository
 ***********************************************************************/

using System;
using Model;
using Controller;
using Service;
using FileHandler;
using Repository;
using System.Collections.Generic;
using Zdravo.Repository;
using System.Collections.ObjectModel;
using Zdravo.Model;

namespace Repository
{
   public class PatientRepository
   {
      private ObservableCollection<Patient> patients;
        private ReportRepository reportRepo;

        public PatientRepository()
        {
            Init();
            reportRepo = new ReportRepository();
        }

        private void Init()
        {
            if(patients==null)
            {
                fileHandler = new PatientFileHandler();
                patients = fileHandler.read();
            }
        }


        public Patient GetById(int id)
      {
         foreach(Patient patient in patients)
            {
                if(patient.Id == id) return patient;
            }
         return null;
      }

        
      
      public ObservableCollection<Patient> GetAll()
      {
            //patients = fileHandler.Load();
            return patients;
      }
      
       public bool DeleteById(int id)
        {
            // TODO: implement
         fileHandler = new PatientFileHandler();
         fileHandler.deleteById(id);
         return false;
       }
        public void addPatient(Patient p)
        {
            fileHandler = new PatientFileHandler();
            fileHandler.addPatient(p);
        }
        public void updatePatient(Patient p)
        {
            fileHandler = new PatientFileHandler();
            fileHandler.updatePatient(p);
        }
        private PatientFileHandler fileHandler;

        internal void RemoveReport(int patientId, int reportId)
        {
            foreach(Patient p in patients)
            {
                if (p.Id == patientId)
                {
                    p.Reports.Remove(reportRepo.GetReportById(reportId));
                }
            }
        }
        internal void UpdateReport(Report rpt,int patientId)
        {
            foreach(Patient p in patients)
            {
                if (p.Id == patientId)
                {
                    p.Reports.Remove(reportRepo.GetReportById(rpt.Id));
                    p.Reports.Add(rpt);
                }
            }
        }
    }
}