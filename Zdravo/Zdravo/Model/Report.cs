using System;
using System.Text.RegularExpressions;

namespace Model
{
    // APPOINTMENT REPORT
    public class Report
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string reportString;
        public string ReportString { get { return reportString; } set { reportString = value; } }
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }

        internal void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            patientId = int.Parse(csvValues[2].Value);
            diagnosis = csvValues[3].Value;
            date = DateOnly.Parse(csvValues[4].Value);
            reportString = csvValues[5].Value;
        }

        internal string ToCSV()
        {
            return "#"+id.ToString()+"#"+patientId.ToString()+"#"+diagnosis+"#"+date.ToString()+"#"+ reportString;
        }
    }
}
