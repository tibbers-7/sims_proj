// File:    AppointmentFileHandler.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:35:07 PM
// Purpose: Definition of Class AppointmentFileHandler

using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Zdravo.FileHandler;

namespace FileHandler
{
    public class AppointmentFileHandler 
   {
      private static readonly string filePath= "data/appointments.csv";

        public List<Appointment> Read()
      {

            //                          INT id,INT patientId,INT room,DATEONLY date,TIMEONLY time,INT duration,INT doctorId,INT scheduledDoctorId,CHAR type,CHAR emergency,CHAR status
            Regex regexObj = new Regex("(\\d+),(\\d+),(\\d*),(\\d*/\\d*/\\d*),(\\d*:\\d*),(\\d+),(\\d*),(\\d+),(O|A),(Y|N),(A|D|W)");
            List<Appointment> list = new List<Appointment>();

            foreach (string line in File.ReadLines(filePath))
            {
                
                    Match matchResult = regexObj.Match(line);
                    if (matchResult.Success)
                    {
                        Appointment ap = new Appointment();
                        ap.FromCSV(matchResult.Groups);
                        list.Add(ap);
                    }
                    else
                    {
                        if (line.Equals("")) break;
                        throw new ArgumentException("Regex issue");
                    }
            }
            return list;
        }
      
       // j:
       // 0 - add new appointment
       // 1 - update appointment
       // 2 - delete appointment
      public void Write(Appointment apt, int j)
      {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Appointment> list = Read();
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
                        foreach (Appointment newApt in list)
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
                        foreach (Appointment newApt in list)
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