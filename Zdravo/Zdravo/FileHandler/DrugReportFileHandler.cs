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
    internal class DrugReportFileHandler
    {
        private static readonly string filePath = "data/drugReports.csv";
        public List<DrugReport> Read()
        {
            // id # drugId # reason
            Regex regexObj = new Regex("#(\\d+)#(\\d+)#([\\w\\s]*)");
            List<DrugReport> list = new List<DrugReport>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    DrugReport drugReport = new DrugReport();
                    drugReport.FromCSV(matchResult.Groups);
                    list.Add(drugReport);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }

            }
            return list;
        }

        public void Write(DrugReport drugReport, int j)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<DrugReport> list = Read();
            string[] newLines = new string[lines.Length];

            switch (j)
            {
                //add new
                case 0:
                    {
                        newLines = new string[lines.Length + 1];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            newLines[i] = lines[i];
                        }
                        newLines[lines.Length] = drugReport.ToCSV();

                        break;
                    }
                //update
                case 1:
                    {
                        int i = 0;
                        foreach (DrugReport newDrugReport in list)
                        {
                            if (newDrugReport.Id == drugReport.Id) newLines[i] = drugReport.ToCSV();
                            else newLines[i] = newDrugReport.ToCSV();
                            i++;
                        }
                        break;
                    }

                //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (DrugReport newDrugReport in list)
                        {
                            if (newDrugReport.Id != drugReport.Id)
                            {
                                newLines[i] = newDrugReport.ToCSV();
                                i++;
                            }
                        }
                        break;
                    }
            }

            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);


        }

    }
}
