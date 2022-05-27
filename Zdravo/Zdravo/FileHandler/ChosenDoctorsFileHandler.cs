using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zdravo.FileHandler
{
    internal class ChosenDoctorsFileHandler
    {
        private static readonly string filePath = "data/chosenDoctors.csv";

        public List<ChosenDoctors> Read()
        {

            //                          INT id,INT patientId,INT room,DATEONLY date,TIMEONLY time,INT duration,INT doctorId,INT scheduledDoctorId,CHAR type,CHAR emergency,CHAR status
            Regex regexObj = new Regex("(\\d+),{(\\d+,\\d+,\\d+,\\d+,\\d+,\\d+,\\d+)}");
            List<ChosenDoctors> list = new List<ChosenDoctors>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    ChosenDoctors doctors = new ChosenDoctors();
                    doctors.FromCSV(matchResult.Groups);
                    list.Add(doctors);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }
            }
            return list;
        }
    }
}
