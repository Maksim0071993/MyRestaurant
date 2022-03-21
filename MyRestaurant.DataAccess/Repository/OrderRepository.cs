using MyRestaurant.DataAccess;
using MyRestaurant.DataAccess.Interface;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurant.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly  MyRestaurantContext _restaurantContext;
        public OrderRepository(MyRestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public List<Order> Get(Func<Order, bool> func)
        {
            var dishes = _restaurantContext.Orders.Where(func).ToList();
            return dishes;
        }

        public void Add(Order order)
        {         
            _restaurantContext.Orders.Add(order);
        }

        public List<Order> GetAll()
        {
            var allOrders = _restaurantContext.Orders.ToList();
            return allOrders;
        }
    }
}
