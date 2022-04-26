using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    internal class PrescriptionRepository
    {
        private List<Prescription> prescriptions;
        private PrescriptionFileHandler fileHandler=new PrescriptionFileHandler();
        private PatientRepository patientRepo=new PatientRepository();

        public PrescriptionRepository()
        {
            prescriptions = fileHandler.Read();
            foreach (Prescription prescription in prescriptions)
            {
                patientRepo.GetById(prescription.PatientId).AddPrescription(prescription);
            }
        }
        public void AddReport(Prescription prescription)
        {
            fileHandler.Write(prescription, 0);
        }

    }
}
