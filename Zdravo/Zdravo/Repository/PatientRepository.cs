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

namespace Repository
{
   public class PatientRepository
   {
      private List<Patient> patients;
        private ReportRepository reportRepo;
      public Patient GetById(int id)
      {
         foreach(Patient patient in patients)
            {
                if(patient.Id == id) return patient;
            }
         return null;
      }

        public PatientRepository()
        {
            fileHandler = new PatientFileHandler();
            patients = fileHandler.Load();
            //reportRepo = new ReportRepository();
        }
      
      public List<Patient> GetAll()
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
   
   }
}