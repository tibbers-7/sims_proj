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
        public int Id { get { return id; } set { id = value; } }
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private int drugId;
        public int DrugId { get { return drugId; } set { drugId = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }

        internal void FromCSV(GroupCollection csvValues)
        {
            id=int.Parse(csvValues[1].Value);
            patientId = int.Parse(csvValues[2].Value);
            drugId = int.Parse(csvValues[3].Value);
            date = DateOnly.FromDateTime(DateTime.Parse(csvValues[4].Value));
        }

        internal string ToCSV()
        {
            return "#"+id.ToString()+"#" + patientId.ToString() + "#" + drugId.ToString() + "#" + date.ToString();
        }
    }

    
}
