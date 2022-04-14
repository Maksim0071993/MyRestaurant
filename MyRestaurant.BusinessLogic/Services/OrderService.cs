using AutoMapper;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurant.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDishService _dishService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IDishService dishService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dishService = dishService;
        }
        public OrderModel CreateOrder(int userId)
        {
            OrderModel order = new OrderModel();
            
            var mappedOrder = _mapper.Map<MyRestaurant.DataAccess.Models.Order>(order);
            mappedOrder.UserId = userId;
            _unitOfWork.Order.Add(mappedOrder);
            _unitOfWork.Save();
            return order;
        }
        public OrderModel GetOrderById (int id)
        {

            var order = _unitOfWork.Order.GetOrderById(id);
            if (order != null)
                return _mapper.Map<OrderModel>(order);
            else
                return null;
        }
        public OrderModel GetNotCompletedOrder(int userId)
        {
            var order = _unitOfWork.Order.Get(o => !o.IsCompleted && o.UserId == userId).FirstOrDefault();
            var mappedOrder = _mapper.Map<OrderModel>(order);
            return mappedOrder;
        }
        public bool AddDishToOrder(int orderId,int dishId)
        {
            var order = _unitOfWork.Order.GetOrderById(orderId);
            if (order == null)
            {
                return false;
            }
            var dish = _unitOfWork.Dish.GetDishById(dishId);
            if (dish == null)
            {
                return false;
            }
            order.Dishes.Add(dish);
            _unitOfWork.Save();
            return true;
        }
        public List<DishModel> GetDishesFromNotComletedOrder(int id)
        {
            var order = GetNotCompletedOrder(id);
            var dishes = order.Dishes;           
            return dishes;
        }
        public void ConfirmOrder(OrderModel model)
        {
           var order = _unitOfWork.Order.GetOrderById(model.Id);
            order.IsCompleted = model.IsCompleted;
            order.Address = model.Address;
            order.Sum = model.Sum;
            order.Date = DateTime.UtcNow;
            _unitOfWork.Order.Update(order);

            _unitOfWork.Save();
        }
        public OrderModel DeleteDishFromOrder(int dishId, int userId)
        {
            var order = GetNotCompletedOrder(userId);
            DishModel dish = _dishService.GetById(dishId);
            order.Dishes.Remove(dish);
            return order;
        }
    }
}
