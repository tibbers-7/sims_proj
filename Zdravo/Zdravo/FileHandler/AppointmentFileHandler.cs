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
      private static readonly string filePath= "appointments.csv";
        private static char DELIMITER = ',';

        public ObservableCollection<Appointment> Read()
      {

            
            ObservableCollection<Appointment> apList = new ObservableCollection<Appointment>();

            foreach (string line in File.ReadLines(filePath))
            {
                    Regex regexObj = new Regex("(\\d+),(\\w+),(\\d+/\\d+/\\d+),(\\d{2}:\\d{2}),(\\d+),(\\d+)");
                    Match matchResult = regexObj.Match(line);
                    if (matchResult.Success)
                    {
                        Appointment ap = new Appointment();
                        ap.fromCSV(matchResult.Groups);
                        apList.Add(ap);
                    }
                    else
                    {
                     
                        throw new ArgumentException("Regex issue");
                    }
                
            }

            

            return apList;


        }
      
      public void Write(Appointment apt, int j)
      {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            string[] newLines = new string[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            switch (j)
            {
                //add new
                case 0:
                    {
                        newLines[lines.Length] = apt.toCSV();
                        

                        System.IO.File.WriteAllText(filePath, "");
                        System.IO.File.WriteAllLines(filePath, newLines);
                        break;
                    }
                //update
                case 1:
                    {
                        break;
                    }
            }

            
      }
   
   }
}