using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using Repository;
using Zdravo.SecretaryWindows;

namespace ViewModel
{
    internal class OrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Order> orders;
        private Order order;
        private OrderRepository orderRepository;
        private OrdersWindow parentWindow;
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

        public OrderViewModel(OrdersWindow parentWindow)
        {
            orderRepository=new OrderRepository();
            orders = orderRepository.getAllOrders();
            this.parentWindow= parentWindow;
        }
        public OrderViewModel(OrdersWindow parentWindow,bool active)
        {
            
            orderRepository = new OrderRepository();
            if (active)
            {
                orders=orderRepository.getActiveOrders();
            }
            else
            {
                orders = orderRepository.getAllOrders();
            }
            this.parentWindow = parentWindow;
        }
        public void Refresh()
        {
            orderRepository = new OrderRepository();
            orders = orderRepository.getAllOrders();
            parentWindow.DataContext = null;
            parentWindow.DataContext = this;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
