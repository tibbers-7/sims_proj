using Controller;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
namespace Zdravo.ViewModel
{
    internal class PatientChartViewModel
    {
        private int appId;
        private PatientRepository pRepo = new PatientRepository();
        private AppointmentController appointmentController = new AppointmentController();
        private int idPatient;
        public int IdPatient { get { return idPatient; } set { idPatient = value; } }
        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }
        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }
        private string birthDate;
        public string BirthDate { get { return birthDate; } set { birthDate = value; } }
        private string workPlace;
        public string WorkPlace { get { return workPlace; } set { workPlace = value; } }
        private string address;
        public string Address { get { return address; } set { address = value; } } 
        private char gender;
        public char Gender { get { return gender; } set { gender = value; } }
        private char marriageStatus;
        public char MarriageStatus { get { return marriageStatus; } set { marriageStatus = value; } }
        
        private ObservableCollection<Allergen> allergens;
        public ObservableCollection<Allergen> Allergens { get { return allergens; } set { allergens = value; } }


        public PatientChartViewModel(int id)
        {
            appId = id;
            Appointment appt=appointmentController.GetAppointment(id);
            Patient p=pRepo.GetById(appt.Patient);
            if (p != null)
            {
                idPatient = p.Id;
                firstName = p.Ime;
                lastName = p.Prezime;
                allergens = new ObservableCollection<Allergen>() { new Allergen(1, "ime alergena", "Opis alergena") };
                birthDate = p.DatumRodjenja.ToString("mm.dd.yyyy.");
                address = p.Adresa;
                if (p.pol == Zdravo.Gender.male)
                {
                    gender = 'M';
                }
                else gender = 'F';
                switch (p.Status)
                {
                    case Zdravo.MarriageStatus.married:
                        marriageStatus = 'm';
                        break;
                    case Zdravo.MarriageStatus.widow:
                        marriageStatus = 'w';
                        break;
                    case Zdravo.MarriageStatus.divorced:
                        marriageStatus = 'd';
                        break;
                    case Zdravo.MarriageStatus.single:
                        marriageStatus = 's';
                        break;
                }
                
            }
        }
    }

    
}
