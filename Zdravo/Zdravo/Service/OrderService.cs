using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class OrderService
    {
        private OrderRepository orderRepository;

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }
        public void addNewOrder(Order newOrder)
        {
            orderRepository.addNewOrder(newOrder);
        }
    }
}
