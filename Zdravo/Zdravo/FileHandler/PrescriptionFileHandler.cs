using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace Zdravo.FileHandler
{
    internal class PrescriptionFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/prescriptions.csv";
        private static readonly string regexString = "#(\\d+)#(\\d+)#(\\w+)#(\\d+/\\d+/\\d+)";
        //|1|43243|F22|8/10/2021|Polomljena noga

        public List<object> Read()
        {
           
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

            foreach (string line in File.ReadLines(filePath))
            {
                if (line.Equals("")) break;
                
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    Prescription prescription = new Prescription();
                    prescription.FromCSV(matchResult.Groups);
                    list.Add(prescription);
                }
                else
                {
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
