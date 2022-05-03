using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace Zdravo.FileHandler
{
    public class DoctorFileHandler
    {
        public string filepath = "data/Doctors.txt";

        public ObservableCollection<Doctor> Load()
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
            foreach (var s in lines)
            { 
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int id = Int32.Parse(ss[0]);
                Doctor d = new Doctor(id, ss[1], ss[2], ss[3]);
                doctors.Add(d);
            }
            return doctors;
        }
    }
}
