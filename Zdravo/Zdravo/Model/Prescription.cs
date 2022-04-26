using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zdravo.Model
{
    public class Prescription
    {
        //TODO: change to class instead of ids
        private int id;
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private string drugId;
        public string DrugId { get { return drugId; } set { drugId = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }

        internal void fromCSV(GroupCollection csvValues)
        {
            id=int.Parse(csvValues[1].Value);
            patientId = int.Parse(csvValues[2].Value);
            drugId = csvValues[3].Value;
            date = DateOnly.FromDateTime(DateTime.Parse(csvValues[4].Value));
        }

        internal string toCSV()
        {
            return "#"+id.ToString()+"#" + patientId.ToString() + "#" + drugId.ToString() + "#" + date.ToString();
        }
    }

    
}
