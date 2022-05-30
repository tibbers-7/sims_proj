using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Model;

namespace Zdravo.FileHandler
{
    internal class VacationFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/vacations.csv";
        private static readonly string regexString = "#(\\d+)#(\\d+)#(\\d+/\\d+/\\d+)#(\\d+/\\d+/\\d+)#([\\w\\s]+)#(\\w{1})#(\\w{1})";

        public List<object> Read()
        {
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    Vacation vacation = new Vacation();
                    vacation.FromCSV(matchResult.Groups);
                    list.Add(vacation);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");

                }

            }
            
            return list;


        }

        public void Write(string[] newLines)
        {
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
    }
}
