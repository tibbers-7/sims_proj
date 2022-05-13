using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using Model;
using FileHandler;

namespace Repository
{
    public class PrescriptionRepository
    {
        public List<Prescription> prescriptions;
        private PrescriptionFileHandler fileHandler=new PrescriptionFileHandler();

        public PrescriptionRepository()
        {
            prescriptions = fileHandler.Read();
        }
        public void AddPrescription(Prescription prescription)
        {
            prescription.Id=prescriptions.Count+1;
            fileHandler.Write(prescription, 1);
        }

    }
}
