using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;

namespace Zdravo.FileHandler
{
    public class BasicRenovationFileHandler
    {
        private string filePath = "data/basicRenovations.txt";

        public ObservableCollection<BasicRenovation> Read() {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<BasicRenovation> renovations = new ObservableCollection<BasicRenovation>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                string[] ss = s.Split(','); 
                int id = Int32.Parse(ss[0]);
                int roomId = Int32.Parse(ss[1]);
                string description = ss[2];
                DateTime date = DateTime.Parse(ss[3]);
                BasicRenovation br = new BasicRenovation(id, roomId, description, date);
                renovations.Add(br);
            }

            return renovations;
        }

        public void Write(ObservableCollection<BasicRenovation> renovations) {
            string[] newLines = new string[renovations.Count];
            int i = 0;
            foreach (BasicRenovation r in renovations) { 
                string id = r.Id.ToString();
                string roomId  = r.RoomId.ToString();
                string date = r.Date.ToString();
                newLines[i] = id + "," + roomId + "," + r.Description + "," + date;
                i++;
            }
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
    }
}
