using AutoMapper;
using Mapster;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;

namespace MyRestaurant.BusinessLogic.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdministratorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public int CreateDish(DishModel model)
        {
            var mapeedDish = _mapper.Map<MyRestaurant.DataAccess.Models.Dish>(model);
            _unitOfWork.Dish.Add(mapeedDish);
            _unitOfWork.Save();
            return model.Id;
        }
    }
}
