/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Zdravo;
using Zdravo.Model;
using ZdravoCorporation.Model;

namespace Model
{
   public class Patient : User
   {
        private List<Appointment> appointments;
        public List<Appointment> Appointments { get { return appointments; } set { appointments = value; } }
        private List<Drug> allergens;
        public List<Drug> Allergens { get { return allergens; } set { allergens = value; } }
        private List<Prescription> prescriptions;
        public List<Prescription> Prescriptions { get { return prescriptions; } set { prescriptions = value; } }
        private string workPlace;
        private List<Report> reports;
        public List<Report> Reports { get { return reports; } set { reports = value; } }
        public string WorkPlace { get { return workPlace; } set { workPlace = value; } }
        private MarriageStatus status;
        public MarriageStatus Status { get { return status; } set { status = value; } }

        public Patient(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,string mejl) :base(fn,ln,i,un,pas,pn,date,g,ad,gu,mejl)
        {
            appointments = new List<Appointment>();
            prescriptions = new List<Prescription>();
            reports = new List<Report>();
        }

        public void AddReport(Report rpt)
        {
            reports.Add(rpt);
        }
        internal void AddAppt(Appointment appt)
        {
            appointments.Add(appt);
        }

        internal void RemoveAppt(Appointment appt)
        {
            appointments.Remove(appt);
        }

        public void AddPrescription(Prescription p)
        {
            prescriptions.Add(p);
        }
   }
}