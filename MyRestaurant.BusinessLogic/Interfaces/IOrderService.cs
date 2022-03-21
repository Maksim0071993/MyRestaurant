using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public int CreateOrder(OrderModel order);
        public OrderModel GetOrderById(int id);
    }
}
