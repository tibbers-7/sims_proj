using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Model;

namespace FileHandler
{
    internal class PrescriptionFileHandler
    {
        private static readonly string filePath = "data/prescriptions.csv";
        
        public List<Prescription> Read()
        {
            //|1|43243|F22|8/10/2021|Polomljena noga
            Regex regexObj = new Regex("#(\\d+)#(\\d+)#(\\w+)#(\\d+/\\d+/\\d+)");
            List<Prescription> list = new List<Prescription>();

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

        public void Write(Prescription prescription, int j)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Prescription> list = Read();
            string[] newLines = new string[lines.Length];

            switch (j)
            {
                //add new
                case 1:
                    {
                        newLines = new string[lines.Length + 1];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            newLines[i] = lines[i];
                        }
                        newLines[lines.Length] = prescription.ToCSV();

                        break;
                    }

                //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (Prescription newPrescription in list)
                        {
                            {
                                newLines[i] = newPrescription.ToCSV();
                                i++;
                            }
                        }
                        break;
                    }
                default:
                    return;
              
            }

            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);


        }
    }
}
