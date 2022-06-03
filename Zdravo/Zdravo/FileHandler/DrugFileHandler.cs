using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace Zdravo.FileHandler
{
    internal class DrugFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/drugs.csv";
        private static readonly string regexString = "#(\\d+)#(\\w+)#([\\w\\s]+)#(A|D|W|R)#([\\w\\s;]*)#([\\w\\s.,;\"()-]*)#(\\d+)";

        public List<object> Read()
        {
            // id # naziv # tip # status # sastojci #opis # id alternativnog leka
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    Drug drug = new Drug();
                    drug.FromCSV(matchResult.Groups);
                    list.Add(drug);
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
