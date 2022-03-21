using AutoMapper;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurant.BusinessLogic.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DishModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyRestaurant.DataAccess.Models.Dish, DishModel>());
            var mapper = new Mapper(config);
            var dishModels = _unitOfWork.Dish.GetAll().ToList();
            var result = dishModels.Select(p => mapper.Map<DishModel>(p)).ToList();
            return result;
        }

        public DishModel GetById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyRestaurant.DataAccess.Models.Dish, DishModel>());
            var mapper = new Mapper(config);
            var dish = _unitOfWork.Dish.Get(x => x.Id == id).FirstOrDefault();
            if (dish != null)
                return mapper.Map<DishModel>(dish);
            else
                return null;
        }
    }
}
