using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Model
{
    // APPOINTMENT REPORT
    public class ApptReport
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private DateTime date;
        public DateTime Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string report;
        public string Report { get { return report; } set { report = value; } }
    }
}
