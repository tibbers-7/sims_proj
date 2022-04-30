using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.FileHandler
{
    public class EquipmentFileHandler
    {
        private String filePath = "data/sEquipment.txt";

        public ObservableCollection<StaticEquipment> Read() {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<StaticEquipment> equipment = new ObservableCollection<StaticEquipment>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int id = Int32.Parse(ss[0]);
                int amount = Int32.Parse(ss[2]);
                int roomId = Int32.Parse(ss[3]);
                StaticEquipment seq = new StaticEquipment(id, ss[1], amount, roomId);
                equipment.Add(seq);
            }
            return equipment;
        }

        public void Write(ObservableCollection<StaticEquipment> equipment) { 
        
        }
    }
}
