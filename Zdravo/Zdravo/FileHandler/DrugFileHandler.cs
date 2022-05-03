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
    internal class DrugFileHandler
    {
        private static readonly string filePath = "data/drugs.csv";

        public List<Drug> Read()
        {


            List<Drug> drugList = new List<Drug>();

            foreach (string line in File.ReadLines(filePath))
            {
                //|1|43243|F22|8/10/2021|Polomljena noga

                Regex regexObj = new Regex("#(\\d+)#(\\w+)#([\\w\\s;]*)");
                Match matchResult = regexObj.Match(line);
                if (matchResult.Success)
                {
                    if (line.Equals("")) break;
                    Drug drug = new Drug();
                    drug.fromCSV(matchResult.Groups);
                    drugList.Add(drug);
                }
                else
                {
                    if (line.Equals("")) break;
                    throw new ArgumentException("Regex issue");
                }

            }
            return drugList;
        }

        public void Write(Drug drug, int j)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Drug> reportList = Read();
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
                        newLines[lines.Length] = drug.toCSV();

                        break;
                    }
                //update
                case 1:
                    {
                        int i = 0;
                        //newLines = new string[reportList.Count];
                        foreach (Drug newDrug in reportList)
                        {
                            if (newDrug.Id == drug.Id) newLines[i] = drug.toCSV();
                            else newLines[i] = newDrug.toCSV();
                            i++;
                        }
                        break;
                    }

                //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (Drug newDrug in reportList)
                        {
                            if (newDrug.Id != drug.Id)
                            {
                                newLines[i] = newDrug.toCSV();
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
