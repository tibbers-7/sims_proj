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

        public VacationRepository(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
            vacations = fileHandler.Read();
        }

        public List<Vacation> GetVacations()
        {
            return vacations;
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
            vacation.Id = vacations.Last().Id+1;
            fileHandler.Write(vacation);
        }

        internal bool CheckSpecialization(Doctor d)
        {
            int counter = 0;
            foreach(Vacation vacation in vacations)
            {
                Doctor doctor = doctorRepository.getById(vacation.DoctorId);
                if (doctor.Specialization.Equals(d.Specialization) && doctor.Id!=d.Id) counter++;
            }

            if (counter > 1) return false;
            return true;
        }
    }
}
