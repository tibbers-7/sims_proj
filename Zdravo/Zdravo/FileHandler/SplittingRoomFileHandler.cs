using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;

namespace Zdravo.FileHandler
{
    public class SplittingRoomFileHandler
    {
        private string filePath = "data/roomsSplittings.txt";

        public ObservableCollection<SplittingRoom> Read()
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<SplittingRoom> roomsSplittings = new ObservableCollection<SplittingRoom>();
            foreach (var line in lines)
            {
                if (line.Equals("")) break;
                string[] parameters = line.Split(',');
                int selectedRoomId = Int32.Parse(parameters[0]);
                DateTime startDate = DateTime.Parse(parameters[2]);
                DateTime endDate = DateTime.Parse(parameters[3]);
                int firstRoomId = Int32.Parse(parameters[4]);
                int secondRoomId = Int32.Parse(parameters[5]);
                RoomType firstRoomType;
                switch (parameters[6])
                {
                    case "operatingRoom":
                        firstRoomType = RoomType.operatingRoom;
                        break;
                    case "laboratory":
                        firstRoomType = RoomType.laboratory;
                        break;
                    default:
                        firstRoomType = RoomType.operatingRoom;
                        break;
                }

                RoomType secondRoomType;
                switch (parameters[7])
                {
                    case "operatingRoom":
                        secondRoomType = RoomType.operatingRoom;
                        break;
                    case "laboratory":
                        secondRoomType = RoomType.laboratory;
                        break;
                    default:
                        secondRoomType = RoomType.operatingRoom;
                        break;
                }
                SplittingRoom splittingRoom = new SplittingRoom(selectedRoomId, parameters[1], startDate, endDate, firstRoomId, firstRoomType, secondRoomId, secondRoomType);
                roomsSplittings.Add(splittingRoom);
            }

            return roomsSplittings;
        }

        public void Write(ObservableCollection<SplittingRoom> roomsSplittings)
        {
            string[] newLines = new string[roomsSplittings.Count];
            int i = 0;
            foreach (SplittingRoom splittingRoom in roomsSplittings)
            {
                string selectedRoomId = splittingRoom.SelectedRoomId.ToString();
                string startDate = splittingRoom.StartDate.ToString();
                string endDate = splittingRoom.EndDate.ToString();
                string firstRoomId = splittingRoom.FirstRoomId.ToString();
                string secondRoomId = splittingRoom.SecondRoomId.ToString();
                string firstRoomType = "";
                string secondRoomType = "";
                switch (splittingRoom.FirstRoomType)
                {
                    case RoomType.operatingRoom:
                        firstRoomType = "operatingRoom";
                        break;
                    case RoomType.laboratory:
                        firstRoomType = "laboratory";
                        break;
                    default:
                        firstRoomType = "operatingRoom";
                        break;
                }
                switch (splittingRoom.SecondRoomType)
                {
                    case RoomType.operatingRoom:
                        secondRoomType = "operatingRoom";
                        break;
                    case RoomType.laboratory:
                        secondRoomType = "laboratory";
                        break;
                    default:
                        secondRoomType = "operatingRoom";
                        break;
                }
                newLines[i] = selectedRoomId + "," + splittingRoom.Description + "," + startDate + "," + endDate + "," + firstRoomId + "," + secondRoomId + "," + firstRoomType + "," + secondRoomType;
                i++;
            }
            System.IO.File.WriteAllText(filePath, "");
            System.IO.File.WriteAllLines(filePath, newLines);
        }
    }
}
