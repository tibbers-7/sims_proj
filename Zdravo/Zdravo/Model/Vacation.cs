using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zdravo;

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
        private Status status;
        public Status Status { get { return status; } set { status = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }
        
        public void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            doctorId = int.Parse(csvValues[2].Value);
            startDate= DateOnly.Parse(csvValues[3].Value);
            endDate = DateOnly.Parse(csvValues[4].Value);
            reason=csvValues[5].Value;
            if (csvValues[6].Value.Equals("Y")) emergency = true; else emergency = false;
            switch (csvValues[7].Value)
            {
                case "A":
                    status = Status.accepted;
                    break;
                case "D":
                    status = Status.denied;
                    break;
                default:
                    status = Status.waiting;
                    break;
            }
        }

        internal string ToCSV()
        {
            //#doctorId#startDate#endDate#accepted
            //#1#2022/01/01#2022/02/02#Y
            char _status,_emergency;
            switch (status)
            {
                case Status.accepted:
                    _status='A';
                    break;
                case Status.denied:
                    _status='D';
                    break;
                default:
                    _status = 'W';
                    break;
            }
            if (emergency) _emergency = 'Y'; else _emergency = 'N';
            string res = '#' + id.ToString()+ '#' + doctorId.ToString() + "#" + startDate.ToString() + "#" + endDate.ToString() + "#"+ reason.ToString()+ "#" + _emergency + "#" + _status;
            return res;
        }


    }
}
