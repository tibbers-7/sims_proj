using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using FileHandler;

namespace Repository
{
    public class OrderRepository
    {
        private OrderFileHandler filehandler;

        public OrderRepository()
        {
            filehandler = new OrderFileHandler();
        }
        public ObservableCollection<Order> getAllOrders()
        {
            ObservableCollection<Order> loadedOrders = new ObservableCollection<Order>();
            loadedOrders = filehandler.Load();
            return loadedOrders;
        }
        public void addNewOrder(Order newOrder)
        {
            filehandler.addNewOrder(newOrder);
        }
    }
}
