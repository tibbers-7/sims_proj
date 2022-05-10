using System;
using System.Collections.ObjectModel;
using Model;

namespace FileHandler
{
    public class RelocationFileHandler
    {
        private string _filePath = "data/relocations.txt";
        public ObservableCollection<Relocation> Read() {
            string[] lines = System.IO.File.ReadAllLines(_filePath);
            ObservableCollection<Relocation> relocations = new ObservableCollection<Relocation>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(',');
                int _equipmentId = Int32.Parse(ss[0]);
                int _roomId = Int32.Parse(ss[1]);
                DateTime date = DateTime.Parse(ss[2]);
                int _amount = Int32.Parse(ss[3]);
                Relocation r = new Relocation(_equipmentId, _roomId, date, _amount);
                relocations.Add(r);
            }

            return relocations;
        }

        public void Write(ObservableCollection<Relocation> relocations) {
            string[] newLines = new string[relocations.Count];
            int i = 0;
            foreach (Relocation r in relocations)
            {
                string _equipmentId = r.EquipmentId.ToString();
                string _roomId = r.RoomId.ToString();
                string _date = r.Date.ToString();
                string _amount = r.Amount.ToString();
                newLines[i] = _equipmentId + "," + _roomId + "," + _date + "," + _amount;
                i++;
            }
            System.IO.File.WriteAllText(_filePath, "");
            System.IO.File.WriteAllLines(_filePath, newLines);
        }
    }
}
