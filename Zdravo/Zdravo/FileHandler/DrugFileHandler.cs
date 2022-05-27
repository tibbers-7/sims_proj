using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace FileHandler
{
    internal class DrugFileHandler
    {
        private static readonly string filePath = "data/drugs.csv";

        public List<Drug> Read()
        {
            // id # naziv # tip # status # sastojci
            Regex regexObj = new Regex("#(\\d+)#(\\w+)#([\\w\\s]+)#(A|D|W|R)#([\\w\\s;]*)#([\\w\\s.,;\"()-]*)");
            List<Drug> list = new List<Drug>();

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

        public void Write(Drug drug, int j)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Drug> list = Read();
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
                        newLines[lines.Length] = drug.ToCSV();

                        break;
                    }
                //update
                case 1:
                    {
                        int i = 0;
                        foreach (Drug newDrug in list)
                        {
                            if (newDrug.Id == drug.Id) newLines[i] = drug.ToCSV();
                            else newLines[i] = newDrug.ToCSV();
                            i++;
                        }
                        break;
                    }

                //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (Drug newDrug in list)
                        {
                            if (newDrug.Id != drug.Id)
                            {
                                newLines[i] = newDrug.ToCSV();
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
