using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zdravo.Model;

namespace Zdravo.FileHandler
{
    internal class VacationFileHandler
    {
        private static readonly string filePath = "data/vacations.csv";

        public List<Vacation> Read()
        {
            List<Vacation> list = new List<Vacation>();

            foreach (string line in File.ReadLines(filePath))
            {
                Regex regexObj = new Regex("#(\\d+)#(\\d+/\\d+/\\d+)#(\\d+/\\d+/\\d+)#([\\w\\s]+)#(\\w{1})");
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    Vacation v = new Vacation();
                    v.FromCSV(matchResult.Groups);
                    list.Add(v);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }

            }



            return list;


        }

        public void Write(Vacation vacation)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Vacation> list = Read();
            string[] newLines = new string[lines.Length];

            newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            newLines[lines.Length] = vacation.ToCSV();


        }

    }
}
