/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class FileHandler.Patient
 ***********************************************************************/

using System;
using Model;
using Controller;
using Service;
using FileHandler;
using Repository;
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
            string[] lines = System.IO.File.ReadAllLines(filepath);
            List<Patient> pacijenti = new List<Patient>();
            foreach(var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss=s.Split(',');
                //(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,int cardNumber)
                int id = Int32.Parse(ss[2]);
                DateTime datum;
                datum = Convert.ToDateTime(ss[6]);
                Gender pol;
                if (ss[7].Equals("M")) pol = Gender.male;
                else pol = Gender.female;
                bool guest=false;
                if (ss[9].Equals("true")) guest = true;
                Patient p = new Patient(ss[0],ss[1],id,ss[3],ss[4],ss[5],datum,pol,ss[8],guest,ss[10]);
                pacijenti.Add(p);
            }
            Console.WriteLine("ISPIIIIIIIIS");
            return pacijenti;
      }
      
        public ObservableCollection<Patient> read()
        {
            
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            foreach (var s in lines)
            {
                string[] ss = s.Split(',');
                //(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,int cardNumber)
                int id = Int32.Parse(ss[2]);
                DateTime datum;
                datum = Convert.ToDateTime(ss[6]);
                Gender pol;
                if (ss[7].Equals("M")) pol = Gender.male;
                else pol = Gender.female;
                bool guest = false;
                if (ss[9].Equals("true")) guest = true;
                Patient p = new Patient(ss[0], ss[1], id, ss[3], ss[4], ss[5], datum, pol, ss[8], guest, ss[10]);
                pacijenti.Add(p);
            }
            Console.WriteLine("ISPIIIIIIIIS");
            return pacijenti;

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
            string novaLinija = p.Ime + "," + p.Prezime + "," + p.Id.ToString() + "," + p.KorisnickoIme + "," + p.Lozinka + "," + p.BrojTelefona + "," + p.DatumRodjenja.ToString() + "," + pol + "," + p.Adresa + "," + guest + "," + p.Mail + ",";
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