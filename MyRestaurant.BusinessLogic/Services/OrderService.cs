using AutoMapper;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System.Linq;

namespace MyRestaurant.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateOrder(OrderModel order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, MyRestaurant.DataAccess.Models.Order>());
            var mapper = new Mapper(config);
            var mappedOrder = mapper.Map<MyRestaurant.DataAccess.Models.Order>(order);
            _unitOfWork.Order.Add(mappedOrder);
            _unitOfWork.Save();
            return order.Id;
        }
        public OrderModel GetOrderById (int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyRestaurant.DataAccess.Models.Order, OrderModel>());
            var mapper = new Mapper(config);
            var order = _unitOfWork.Order.Get(x => x.Id == id).FirstOrDefault();
            if (order != null)
                return mapper.Map<OrderModel>(order);
            else
                return null;
        }
    }
}
