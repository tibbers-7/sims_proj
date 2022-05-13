/***********************************************************************
 * Module:  PatientController.cs
 * Author:  Darko
 * Purpose: Definition of the Class Controller.PatientController
 ***********************************************************************/

using System;
using Model;
using Service;
using Repository;
using System.Windows.Controls;
using Zdravo;
using System.Collections.ObjectModel;

namespace Controller
{
    public class PatientController
   {
        private PatientService service=new PatientService();
        private PatientRepository p;
      public Patient CreatePatient(TextBox tbIme, TextBox tbPrezime, int tbId, TextBox tbUsername, TextBox tbSifra, TextBox tbTelefon, TextBox tbDatum,ComboBox cbPol, TextBox tbAdresa,CheckBox checkBoxGuest, TextBox tbMail)
        {
            // TODO: implement
            string ime = tbIme.Text;
            string prezime = tbPrezime.Text;
         //   int id = Int16.Parse(tbId.Text);
            string username = tbUsername.Text;
            string sifra = tbSifra.Text;
            string telefon = tbTelefon.Text;
            string datumString = tbDatum.Text;
            DateTime datumRodjenja = Convert.ToDateTime(datumString);
            Gender pol;
            if (cbPol.SelectedItem.Equals("Muski")) pol = Gender.male;
            else pol = Gender.female;
            string adresa = tbAdresa.Text;
            bool guest;
            if (checkBoxGuest.IsChecked == true) guest = true;
            else guest = false;
            string email = tbMail.Text;
            Patient p = new Patient(ime, prezime, tbId, username, sifra, telefon, datumRodjenja, pol, adresa, guest, email,null);
            return p;
      }

        internal ObservableCollection<Patient> GetAll()
        {
            return service.GetAll();
        }

        internal Patient GetById(int patientId)
        {
            return service.GetById(patientId);
        }

        public bool DeletePatient(Patient izabran)
      {
            // TODO: implement
            p = new PatientRepository();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>(p.GetAll());
            
            if (izabran != null)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    if (patients[i].Id == izabran.Id)
                    {
                        p.DeleteById(patients[i].Id);
                    }

                }
                return true;
         
            }
            return false;
      }

      public ObservableCollection<Prescription> GetPrescriptions(int patientId)
        {
            return service.GetPrescriptions(patientId);
        }

        public ObservableCollection<Report> GetReports(int patientId)
        {
            return service.GetReports(patientId);
        }


    }
}