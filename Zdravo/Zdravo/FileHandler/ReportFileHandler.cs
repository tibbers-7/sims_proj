﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace Zdravo.FileHandler
{
    internal class ReportFileHandler : FileHandlerInterface
    {
        private static readonly string filePath = "data/reports.csv";
        private static readonly string regexString = "#(\\d+)#(\\d+)#(\\w+)#(\\d+/\\d+/\\d+)#([\\w\\s]+)#([\\w\\s]+)";
                                                    //#  id  # jmbg # sifra#  datum         # dijagnoza # anamneza

        public List<object> Read()
        {
            Regex regexObj = new Regex(regexString);
            List<object> list = new List<object>();

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

        public int Write(string[] newLines)
        {
            try
            {
                System.IO.File.WriteAllText(filePath, "");
                System.IO.File.WriteAllLines(filePath, newLines);
                return 0;
            } catch { return -1; }


        }
    }
}
