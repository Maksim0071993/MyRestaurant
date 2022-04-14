using AutoMapper;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MyRestaurant.BusinessLogic.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DishService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<DishModel> GetAll()
        {
            var dishModels = _unitOfWork.Dish.GetAll().ToList();
            var result = dishModels.Select(p => _mapper.Map<DishModel>(p)).ToList();
            return result;
        }

        public DishModel GetById(int id)
        {
            var dish = _unitOfWork.Dish.GetDishById(id);
            if (dish != null)
                return _mapper.Map<DishModel>(dish);
            else
                return null;
        }
    }
}
