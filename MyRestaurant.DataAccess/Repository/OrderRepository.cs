using Microsoft.EntityFrameworkCore;
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
            var dishes = _restaurantContext.Orders.Include(o => o.Dishes).Where(func).ToList();
            return dishes;
        }

        public void Add(Order order)
        {         
            _restaurantContext.Orders.Add(order);
        }
        public void Update(Order order)
        {
            _restaurantContext.Orders.Update(order);
        }

        public List<Order> GetAll()
        {
            var allOrders = _restaurantContext.Orders.ToList();
            return allOrders;
        }
        public Order GetOrderById(int id)
        {
            var order = _restaurantContext.Orders.Include(o => o.Dishes).Where(x => x.Id == id).FirstOrDefault();
                return order;
        }
    }
}
