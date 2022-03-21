using Mapster;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;

namespace MyRestaurant.BusinessLogic.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdministratorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateDish(DishModel model)
        {
            var destObject = model.Adapt<MyRestaurant.DataAccess.Models.Dish>();
            _unitOfWork.Dish.Add(destObject);
            _unitOfWork.Save();
            return model.Id;
        }
      
        public void AddIngridient(IngridientModel model)
        {
            var destObject = model.Adapt<MyRestaurant.DataAccess.Models.Ingridient>();
            _unitOfWork.Ingridient.Add(destObject);
            _unitOfWork.Save();
        }
    }
}
