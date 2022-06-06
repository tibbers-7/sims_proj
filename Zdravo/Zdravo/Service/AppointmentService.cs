
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo.Repository;

namespace Zdravo.Service
{
   public class AppointmentService
   {
      private AppointmentRepository appointmentRepo;
      private PatientService patientService;
      private DrugRepository drugRepo;
      private ReportRepository reportRepo;
      private PrescriptionRepository prescriptionRepo;
        private List<Appointment> doctorsAppointments;

        public AppointmentService(AppointmentRepository aRepo, DrugRepository dRepo, PrescriptionRepository prescRepo,ReportRepository rRepo, PatientService pService)
        {
            appointmentRepo= aRepo;
            prescriptionRepo = prescRepo;
            drugRepo=dRepo;
            reportRepo=rRepo;
            patientService=pService;
        }

        internal List<Appointment> GetAppointmentsForDoctor(bool isUpcoming,int doctorId)
        {
            doctorsAppointments = new List<Appointment>();
            foreach (Appointment appt in appointmentRepo.GetAll())
            {
                if (appt.Doctor == doctorId)
                {
                    DateTime apptDateTime = appt.Date.ToDateTime(appt.Time);
                    int cmp = DateTime.Compare(apptDateTime, DateTime.Now);
                    if ((cmp >= 0 && isUpcoming) | (cmp < 0 && !isUpcoming))
                    {
                        if (appt.Status == Zdravo.Status.accepted)
                            doctorsAppointments.Add(appt);
                    }
                }
            }
            return doctorsAppointments;
        }

        internal List<Appointment> GetAll()
        {
            return appointmentRepo.GetAll();
        }

    

        internal ObservableCollection<AppointmentRecord> GetAllRecords()
        {
            return appointmentRepo.GetAllRecords();
        }


        public int CreateAppointment(Appointment appt,int patientId,string doctorSpec)
        {
            Patient p = patientService.GetById(patientId);
            if (p == null) return 1;

            if (Tools.IsInPast(appt.Date, appt.Time)) return 2;

            if (doctorSpec!=null)
            {
                Doctor d = patientService.GetChosenDoctor(doctorSpec, patientId);
                if (d == null) return 2;
                appt.Doctor = d.Id;
            }

            return appointmentRepo.AddNew(appt);
        }

        internal Appointment GetById(int id)
        {
            return appointmentRepo.GetByID(id);
        }

        public int DeleteAppointment(int id)
      {
            Appointment appointment = GetById(id);
            if (appointment == null) return 1;

            if (patientService.GetById(appointment.Patient) == null) return 2;
            patientService.GetById(appointment.Patient).RemoveAppt(appointment);
            return appointmentRepo.Delete(id);
      }

        internal int UpdateAppointment(Appointment appt)
        {
            Patient p = patientService.GetById(appt.Patient);
            if (p == null) return 1;
            if (Tools.IsInPast(appt.Date,appt.Time)) return 2;


            return appointmentRepo.Update(appt);

        }
        
    }
}