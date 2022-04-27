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
        public PatientService()
        {
            p = new PatientRepository();
            ReportRepository reportRepository = new ReportRepository();
            
            foreach (Report report in reportRepository.apptReports)
            {
                if(p.GetById(report.PatientId)!=null)
                p.GetById(report.PatientId).AddReport(report);
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

        private PatientRepository p=new PatientRepository();

        internal ObservableCollection<Report> GetReports(int patientId)
        {
            Patient patient=p.GetById(patientId);
            return new ObservableCollection<Report>(patient.Reports);
        }
    }
}