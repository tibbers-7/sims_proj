using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Collections.ObjectModel;
using Zdravo.Model;
using Service;
using Model;
using System.ComponentModel;
using Repository;

namespace ViewModel
{
    internal class OrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Order> orders;
        private Order order;
        private OrderRepository orderRepository;
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                if (orders == value)
                    return;
                orders = orderRepository.getAllOrders();
                NotifyPropertyChanged("Orders");
            }
        }

        public OrderViewModel()
        {
            orderRepository=new OrderRepository();
            orders = orderRepository.getAllOrders();
        }
        public void Refresh()
        {
            orderRepository = new OrderRepository();
            orders = orderRepository.getAllOrders();
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
