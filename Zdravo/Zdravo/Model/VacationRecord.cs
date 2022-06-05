using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VacationRecord
    {
        private int id;
        public int Id => id;

        private string doctorFirstName;
        public string DoctorFirstName => doctorFirstName;

        private string doctorLastName;
        public string DoctorLastName => doctorLastName;

        private string doctorSpecialization;
        public string DoctorSpecialization => doctorSpecialization;
        
        private string period;
        public string Period => period;

        private string reason;

        public string Reason => reason;

        public VacationRecord(int id,string doctorFirstName,string doctorLastName,string doctorSpecialization,string period,string reason)
        {
            this.id = id;
            this.doctorFirstName=doctorFirstName;
            this.doctorLastName=doctorLastName;
            this.doctorSpecialization=doctorSpecialization;
            this.period=period;
            this.reason=reason;
        }
    }
}
