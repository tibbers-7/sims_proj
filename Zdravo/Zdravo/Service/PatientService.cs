/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using System;
using Model;
using Controller;
using Service;
using FileHandler;
using Repository;
using System.Collections.Generic;
using Zdravo.Model;
namespace Service
{
   public class PatientService
   {
     public string checkId()
        {
            p = new PatientRepository();
            List<Patient> patients = p.GetAll();
            int sifra = 0;
            for(int i = 0; i < patients.Count; i++)
            {
                if (i == patients.Count - 1) sifra = i+2;
            }
            return sifra.ToString();
        }

        public void removeAllergen(Patient patient,Allergen allergen)
        {
            p = new PatientRepository();
            p.removeAllergen(patient,allergen);
        }
        private PatientRepository p;
   
   }
}