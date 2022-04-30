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
            return null;
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
