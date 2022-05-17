using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using Model;

namespace Repository
{
    public class VacationRepository
    {
        private VacationFileHandler fileHandler=new VacationFileHandler();
        private DoctorRepository doctorRepository;
        private List<Vacation> vacations;
        private List<VacationString> vacationsString;

        public VacationRepository(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
            GetVacations();
            RemoveOldLogs();
        }

        public void GetVacations()
        {
            vacations = fileHandler.Read();
            vacationsString = new List<VacationString>();
            foreach (Vacation vacation in vacations)
            {
                VacationString vacString=vacation.ToString();
                vacationsString.Add(vacString);
            }
            RemoveOldLogs();
        }

        public Vacation GetVacationById(int id)
        {
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Id == id) return vacation;
            }
            return null;
        }

        public void AddVacation(Vacation vacation)
        {
            vacations = fileHandler.Read();
            vacation.Id = vacations.Last().Id+1;
            fileHandler.Write(vacation);
            GetVacations();
        }

        internal List<VacationString> GetDoctorVacationStrings(int doctorId)
        {
            List<VacationString> vacStrings = new List<VacationString>();
            foreach(VacationString vacationString in vacationsString)
            {
                if(vacationString.DoctorId==doctorId) vacStrings.Add(vacationString);
            }
            return vacStrings;
        }

        internal bool CheckSpecialization(Doctor d, Vacation newVacation)
        {
            int counter = 0;
            foreach(Vacation oldVacation in vacations)
            {
                    Doctor doctor = doctorRepository.getById(oldVacation.DoctorId);
                    if (doctor.Specialization.Equals(d.Specialization) && doctor.Id != d.Id && oldVacation.Status!=Zdravo.Status.denied)
                    {
                        if (FindVacationConflicts(newVacation, oldVacation)) counter++;
                    }
                
            }

            if (counter > 1) return false;
            return true;
        }

        internal static bool FindVacationConflicts(Vacation newVacation, Vacation oldVacation)
        {
            DateTime newStartDate = newVacation.StartDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime newEndDate = newVacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime oldStartDate = oldVacation.StartDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime oldEndDate = oldVacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 AM"));

            int newEndOldStart = DateTime.Compare(oldStartDate, newEndDate); 
            int newStartOldEnd = DateTime.Compare(newStartDate, oldEndDate); 
            int newStartOldStart = DateTime.Compare(newStartDate, oldStartDate); 
            int newEndOldEnd = DateTime.Compare(newEndDate, oldEndDate);

            if (newStartOldStart == 0) return true; // old and new start at the same date
            if (newStartOldStart >= 0 && newStartOldEnd <= 0) return true; //new starts after old starts and old ends after new starts 
            if (newStartOldStart <= 0 && newEndOldStart <= 0) return true; //old starts after new starts, old ends after new ends
            if (newStartOldStart<=0 && newEndOldEnd>=0) return true; //old date is inside new date
            if (newStartOldStart>=0 && newEndOldEnd<=0) return true; //old date encapsulates new date

            return false;
        }

        internal void RemoveOldLogs()
        {
            List<Vacation> currentVacations = new List<Vacation>();
            foreach(Vacation vacation in vacations)
            {
                int cmp = DateTime.Compare(DateTime.Now, vacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 PM")));
                if (cmp <= 0) currentVacations.Add(vacation);
            }

            vacations = currentVacations;
        }
    }
}
