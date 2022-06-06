/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class FileHandler.Patient
 ***********************************************************************/

using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zdravo;
namespace FileHandler
{
    public class PatientFileHandler
   {
        public List<Patient> Load()
        {
            // TODO: implement
            List<Patient> patients = new List<Patient>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                string[] parameters = line.Split(',');
                int id = Int32.Parse(parameters[2]);
                DateTime dateOfBirth;
                dateOfBirth = Convert.ToDateTime(parameters[6]);
                Gender gender;
                if (parameters[7].Equals("M")) gender = Gender.male;
                else gender = Gender.female;
                bool guest = false;
                if (parameters[9].Equals("true")) guest = true;
                List<int> allergenIds = new List<int>();
                if (parameters.Length == 12)
                {
                    String[] idList = parameters[11].Split('.');
                    int idInteger;
                    foreach (string idString in idList)
                    {
                        if (!idString.Equals(""))
                        {
                            idInteger = Int32.Parse(idString);
                            allergenIds.Add(idInteger);
                        }
                    }
                }

                Patient patient = new Patient(parameters[0], parameters[1], id, parameters[3], parameters[4], parameters[5], dateOfBirth, gender, parameters[8], guest, parameters[10], allergenIds);
                patients.Add(patient);
            }
            return patients;
        }


        public ObservableCollection<Patient> read()
        {

            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                string[] parameters = line.Split(',');
                int id = Int32.Parse(parameters[2]);
                DateTime dateOfBirth;
                dateOfBirth = Convert.ToDateTime(parameters[6]);
                Gender gender;
                if (parameters[7].Equals("M")) gender = Gender.male;
                else gender = Gender.female;
                bool guest = false;
                if (parameters[9].Equals("true")) guest = true;
                List<int> allergenIds = new List<int>();
                if (parameters.Length == 12)
                {
                    String[] idList = parameters[11].Split('.');
                    int idInteger;
                    foreach (string idString in idList)
                    {
                        if (!idString.Equals(""))
                        {
                            idInteger = Int32.Parse(idString);
                            allergenIds.Add(idInteger);
                        }
                    }
                }

                Patient patient = new Patient(parameters[0], parameters[1], id, parameters[3], parameters[4], parameters[5], dateOfBirth, gender, parameters[8], guest, parameters[10], allergenIds);
                patients.Add(patient);
            }
            return patients;

        }
        public void deleteById(int id)
        {
            
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length - 1];
            int i = 0;
            foreach(var s in lines)
            {
                string[] ss = s.Split(',');
                int idd = Int32.Parse(ss[2]);
                if (idd != id)
                {
                    newLines[i] = s;
                    i++;
                }
                
            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
      public void addPatient(Patient p)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] newLines = new string[lines.Length + 1];
            for(int i = 0; i < lines.Length; i++)
            {
                newLines[i] = lines[i];
            }
            string pol = "M";
            string guest = "false";
            if (p.GuestNalog == true) guest = "true";
            if (p.pol == Gender.female) pol = "F";
            newLines[lines.Length] = p.Ime + "," + p.Prezime + "," + p.Id.ToString() + "," + p.KorisnickoIme + "," + p.Lozinka + "," + p.BrojTelefona + "," + p.DatumRodjenja.ToString() + "," + pol + "," + p.Adresa + "," + guest + "," + p.Mail + "," ;
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, newLines);
        }
        public void updatePatient(Patient p)
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string pol = "M";
            string guest = "false";
            if (p.GuestNalog == true) guest = "true";
            if (p.pol == Gender.female) pol = "F";
            String allergenIds="";
            for(int i = 0; i < p.Allergens.Count; i++)
            {
                if (i != p.Allergens.Count - 1)
                {
                    allergenIds += p.Allergens[i].Id.ToString() + '.';

                }
                else allergenIds += p.Allergens[i].Id.ToString();
            }
            string novaLinija = p.Ime + "," + p.Prezime + "," + p.Id.ToString() + "," + p.KorisnickoIme + "," + p.Lozinka + "," + p.BrojTelefona + "," + p.DatumRodjenja.ToString() + "," + pol + "," + p.Adresa + "," + guest + "," + p.Mail + "," + allergenIds;
            for (int i = 0; i < lines.Length; i++)
            {
               
                string[] ss = lines[i].Split(',');
                int idd = Int32.Parse(ss[2]);
                if (idd == p.Id)
                {
                    lines[i] = novaLinija;
                }

            }
            System.IO.File.WriteAllText(filepath, "");
            System.IO.File.WriteAllLines(filepath, lines);
        }
        public string filepath= "data/Patients.txt";
   
   }
}