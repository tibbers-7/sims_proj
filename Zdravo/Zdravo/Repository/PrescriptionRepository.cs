using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using Model;
using Zdravo.FileHandler;

namespace Repository
{
    public class PrescriptionRepository
    {
        public List<Prescription> prescriptions;
        private PrescriptionFileHandler fileHandler=new PrescriptionFileHandler();

        public PrescriptionRepository()
        {
            InitPrescription();
        }

        private void InitPrescription()
        {
            List<object> list = fileHandler.Read();
            prescriptions = new List<Prescription>();
            foreach (object prescObj in list)
            {
                Prescription presc=(Prescription) prescObj;
                prescriptions.Add(presc);
            }
        }
        public void AddNew(Prescription prescription)
        {
            prescription.Id=prescriptions.Count+1;
            int listCount = prescriptions.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = prescriptions[i].ToCSV();
            }
            newLines[listCount] = prescription.ToCSV();
            fileHandler.Write(newLines);
            InitPrescription();
        }

    }
}
