using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        public void Add(Order order);
        public List<Order> Get(Func<Order, bool> func);
    }
}
