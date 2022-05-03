// File:    AppointmentFileHandler.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:35:07 PM
// Purpose: Definition of Class AppointmentFileHandler

using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;

namespace FileHandler
{
   public class AppointmentFileHandler
   {
      private static readonly string filePath= "data/appointments.csv";

        public List<Appointment> Read()
      {


            List<Appointment> apList = new List<Appointment>();

            foreach (string line in File.ReadLines(filePath))
            {
                    

                    Regex regexObj = new Regex("(\\d+),(\\d+),(\\w+),(\\d+/\\d+/\\d+),(\\d+:\\d{2}),(\\d+),(\\d+),(Y|N)");
                    Match matchResult = regexObj.Match(line);
                    if (matchResult.Success)
                    {
                        Appointment ap = new Appointment();
                        ap.FromCSV(matchResult.Groups);
                        apList.Add(ap);
                    }
                    else
                    {
                        if (line.Equals("")) break;
                        throw new ArgumentException("Regex issue");
                    }
                
            }

            

            return apList;


        }
      
       // j:
       // 0 - add new appointment
       // 1 - update appointment
       // 2 - delete appointment
      public void Write(Appointment apt, int j)
      {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Appointment> apList = Read();
            string[] newLines=new string[lines.Length];

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
                        newLines[lines.Length] = apt.ToCSV();
                        
                        break;
                    }
                //update
                case 1:
                    { 
                        int i = 0;
                        foreach (Appointment newApt in apList)
                        {
                            if (newApt.Id == apt.Id) newLines[i] = apt.ToCSV(); 
                            else newLines[i] = newApt.ToCSV();
                            i++;
                        }
                        break;
                    }

                 //delete
                case 2:
                    {
                        newLines = new string[lines.Length - 1];
                        int i = 0;
                        foreach (Appointment newApt in apList)
                        {
                            if (newApt.Id != apt.Id)
                            {
                                newLines[i] = newApt.ToCSV();
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