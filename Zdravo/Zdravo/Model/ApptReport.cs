using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Model
{
    // APPOINTMENT REPORT
    internal class ApptReport
    {
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string report;
        public string Report { get { return report; } set { report = value; } }
    }
}
