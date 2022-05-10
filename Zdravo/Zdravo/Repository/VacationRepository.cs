using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    internal class VacationRepository
    {
        private VacationFileHandler fileHandler=new VacationFileHandler();
        private List<Vacation> vacations;

        public VacationRepository()
        {
            vacations = fileHandler.Read();
        }

        public List<Vacation> GetReports()
        {
            return vacations;
        }

        public Vacation GetReportById(int id)
        {
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Id == id) return vacation;
            }
            return null;
        }

        public void AddReport(Vacation vacation)
        {
            vacation.Id = vacations.Count + 1;
            fileHandler.Write(vacation);
        }

        internal void UpdateReport(Vacation vacation)
        {
            fileHandler.Write(vacation);
            vacations = fileHandler.Read();
        }
    }
}
