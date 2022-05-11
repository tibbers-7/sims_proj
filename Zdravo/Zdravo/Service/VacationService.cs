using Model;
using Repository;
using System;

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

        internal int ScheduleVacation(int doctorId,DateOnly startDate, DateOnly endDate, string reason)
        {
            int cmp = DateTime.Compare(startDate.ToDateTime(TimeOnly.Parse("00:00 AM")), endDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (cmp>0) return 1; // Greska; Pocetni datum je posle krajnjeg
            if (!CheckSpecialization(doctorId)) return 2; //Greska; Ima vise od dva doktora iste spec koji su zakazali 
            Vacation vacation = new Vacation() { Accepted = false, DoctorId = doctorId, EndDate=endDate,StartDate=startDate };
            repo.AddVacation(vacation);
            return 0;
        }

        private bool CheckSpecialization(int doctorId)
        {
            Doctor d=doctorRepo.getById(doctorId);
            return repo.CheckSpecialization(d);
        }
    }
}
