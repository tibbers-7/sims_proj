using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace FileHandler
{
    internal class ReportFileHandler
    {
        private static readonly string filePath = "data/reports.csv";
        
        public List<Report> Read()
        {
            //|1|43243|F22|8/10/2021|Polomljena noga
            Regex regexObj = new Regex("#(\\d+)#(\\d+)#(\\w+)#(\\d+/\\d+/\\d+)#([\\w\\s]+)#([\\w\\s]+)");
            List<Report> list = new List<Report>();

            foreach (string line in File.ReadLines(filePath))
            {
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    Report report = new Report();
                    report.FromCSV(matchResult.Groups);
                    list.Add(report);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }

            }
            return list;
        }

        public void Write(Report report, int j)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Report> list = Read();
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
                        newLines[lines.Length] = report.ToCSV();

                        break;
                    }
                //update
                case 1:
                    {
                        int i = 0;
                        //newLines = new string[reportList.Count];
                        foreach (Report newReport in list)
                        {
                            if (newReport.Id == report.Id) newLines[i] = report.ToCSV();
                            else newLines[i] = newReport.ToCSV();
                            i++;
                        }
                        break;
                    }

                //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (Report newReport in list)
                        {
                            if (newReport.Id != report.Id)
                            {
                                newLines[i] = newReport.ToCSV();
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
