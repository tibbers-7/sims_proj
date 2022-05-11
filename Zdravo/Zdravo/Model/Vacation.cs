using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Vacation
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private int doctorId;
        public int DoctorId { get { return doctorId; } set { doctorId = value; } }
        private DateOnly startDate;
        public DateOnly StartDate { get { return startDate; } set { startDate = value; } }
        private DateOnly endDate;
        public DateOnly EndDate { get { return endDate; } set { endDate = value; } }
        private bool accepted;
        public bool Accepted { get { return accepted; } set { accepted = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        
        public void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            doctorId = int.Parse(csvValues[2].Value);
            startDate= DateOnly.Parse(csvValues[3].Value);
            endDate = DateOnly.Parse(csvValues[4].Value);
            reason=csvValues[4].Value;
            if(csvValues[5].Value.Equals('Y')) accepted = true; else accepted = false;
        }

        internal string ToCSV()
        {
            //#doctorId#startDate#endDate#accepted
            //#1#2022/01/01#2022/02/02#Y
            char _accepted;
            if (accepted) _accepted = 'Y'; else _accepted = 'N';
            string res = '#' + id.ToString()+ '#' + doctorId.ToString() + "#" + startDate.ToString() + "#" + endDate.ToString() + "#" + _accepted;
            return res;
        }


    }
}
