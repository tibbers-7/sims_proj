using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace Zdravo.FileHandler
{
    internal class OrderFileHandler
    {
        private string filepath = "data/equipmentOrders.txt";


        public ObservableCollection<Order> Load()
        {
            // TODO: implement
            string[] lines = System.IO.File.ReadAllLines(filepath);
            ObservableCollection<Order> loadedOrders = new ObservableCollection<Order>();
            foreach (var line in lines)
            {
                if (line.Equals("")) break;
                string[] parameters = line.Split('|');
                int id=int.Parse(parameters[0]);
                string name=parameters[1];
                int quantity=int.Parse(parameters[2]);
                DateTime orderDateTime=Convert.ToDateTime(parameters[3]);
                string note=parameters[4];
                Order loadedOrder=new Order(id, name, quantity, orderDateTime, note);
                loadedOrders.Add(loadedOrder);
            }
            return loadedOrders;
        }
    }
}
