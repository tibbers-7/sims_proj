using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Service
{
    public class VacationService
    {
        private VacationRepository repo;
        private DoctorRepository doctorRepo;
        public VacationService(VacationRepository repo,DoctorRepository doctorRepo)
        {
            this.repo = repo;
            this.doctorRepo = doctorRepo;
        }

        internal int ScheduleVacation(int doctorId,DateOnly startDate, DateOnly endDate, string reason,bool emergency)
        {
            if (CheckIsInPast(startDate)) return 1;
            if (!CheckDates(startDate, endDate)) return 2;// Greska; Pocetni datum je posle krajnjeg
            Vacation vacation = new Vacation() { Status=Zdravo.Status.waiting, DoctorId = doctorId, EndDate = endDate, StartDate = startDate, Reason = reason, Emergency = emergency };
            if (!emergency)
            {
                if (!Check48h(startDate)) return 3; //Greska: nije 48h ranije
                if (!CheckSpecialization(doctorId, vacation)) return 4; //Greska; Ima vise od dva doktora iste spec koji su zakazali 
            }
            repo.AddNew(vacation);
            return 0;
        }
        internal void processVacation(int id,int option)
        {
            repo.processVacation(id,option);
        }
        internal ObservableCollection<VacationRecord> getPendingVacationRecords()
        {
            return repo.getPendingVacationRecords();
        }
        internal List<VacationString> GetDoctorVacationStrings(int doctorId)
        {
            return repo.GetDoctorVacationStrings(doctorId);
        }

        private bool CheckIsInPast(DateOnly startDate)
        {
            
            int cmp = DateTime.Compare(DateTime.Now,startDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (cmp > 0) return true;
            return false;
        }

        private bool CheckDates(DateOnly startDate,DateOnly endDate)
        {
            int startDateEndDate = DateTime.Compare(startDate.ToDateTime(TimeOnly.Parse("00:00 AM")), endDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (startDateEndDate > 0) return false;
            return true;
        }

        private bool CheckSpecialization(int doctorId,Vacation vacation)
        {
            Doctor d=doctorRepo.getById(doctorId);
            return repo.CheckSpecialization(d,vacation);
        }

        private bool Check48h(DateOnly startDate)
        {
            DateTime twoDaysLater = DateTime.Now.AddDays(2);
            int cmp = DateTime.Compare(twoDaysLater, startDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (cmp > 0) return false;
            return true;
        }

    }
}
