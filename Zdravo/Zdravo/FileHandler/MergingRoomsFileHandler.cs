using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;

namespace Zdravo.FileHandler
{
    public class MergingRoomsFileHandler
    {
        private string filePath = "data/roomsMergings.txt";
        public ObservableCollection<MergingRooms> Read()
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<MergingRooms> roomsMergings = new ObservableCollection<MergingRooms>();
            foreach (var line in lines)
            {
                if (line.Equals("")) break;
                string[] parameters = line.Split(',');
                int firstSelectedRoomId = Int32.Parse(parameters[0]);
                int secondSelectedRoomId = Int32.Parse(parameters[1]);
                DateTime startDate = DateTime.Parse(parameters[2]);
                DateTime endDate = DateTime.Parse(parameters[3]);
                int newRoomId = Int32.Parse(parameters[5]);
                RoomType newRoomType;
                switch (parameters[6])
                {
                    case "operatingRoom":
                        newRoomType = RoomType.operatingRoom;
                        break;
                    case "laboratory":
                        newRoomType = RoomType.laboratory;
                        break;
                    default:
                        newRoomType = RoomType.operatingRoom;
                        break;
                }
                MergingRooms mergingRooms = new MergingRooms(firstSelectedRoomId, secondSelectedRoomId, startDate, endDate, parameters[4], newRoomId, newRoomType);
                roomsMergings.Add(mergingRooms);
            }

            return roomsMergings;
        }

        public void Write(ObservableCollection<MergingRooms> roomsMergings)
        {
            string[] newLines = new string[roomsMergings.Count];
            int i = 0;
            foreach (MergingRooms mergingRooms in roomsMergings)
            {
                string firstSelectedRoomId = mergingRooms.FirstSelectedRoomId.ToString();
                string secondSelectedRoomId = mergingRooms.SecondSelectedRoomId.ToString();
                string startDate = mergingRooms.StartDate.ToString();
                string endDate = mergingRooms.EndDate.ToString();
                string newRoomId = mergingRooms.NewRoomId.ToString();
                string newRoomType = "";
                switch (mergingRooms.NewRoomType)
                {
                    case RoomType.operatingRoom:
                        newRoomType = "operatingRoom";
                        break;
                    case RoomType.laboratory:
                        newRoomType = "laboratory";
                        break;
                    default:
                        newRoomType = "operatingRoom";
                        break;
                }
                newLines[i] = firstSelectedRoomId + "," + secondSelectedRoomId + "," + startDate + "," + endDate + "," + mergingRooms.Description + "," + newRoomId + "," + newRoomType;
                i++;
            }
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
    }
}
