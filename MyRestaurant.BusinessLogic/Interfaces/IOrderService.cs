using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public OrderModel CreateOrder(int userId);
        public OrderModel GetOrderById(int id);
        public OrderModel GetNotCompletedOrder(int userId);
        public bool AddDishToOrder(int orderId, int dishId);
        public List<DishModel> GetDishesFromNotComletedOrder(int id);
        public void ConfirmOrder(OrderModel model);
        public OrderModel DeleteDishFromOrder(int dishId, int userId);
    }
}
