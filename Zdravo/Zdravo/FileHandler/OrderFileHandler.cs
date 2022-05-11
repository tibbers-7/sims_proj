﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;

namespace FileHandler
{
    public class OrderFileHandler
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
                string name=parameters[0];
                int quantity=int.Parse(parameters[1]);
                DateTime orderDateTime=Convert.ToDateTime(parameters[2]);
                string note=parameters[3];
                Order loadedOrder=new Order(name, quantity, orderDateTime, note);
                loadedOrders.Add(loadedOrder);
            }
            return loadedOrders;
        }
    }
}
