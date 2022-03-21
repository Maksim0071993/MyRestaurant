
using Mapster;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System.Linq;

namespace MyRestaurant.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Register(UserModel model)
        {
            
            var destObject = model.Adapt<MyRestaurant.DataAccess.Models.User>();
            _unitOfWork.User.Add(destObject);
            _unitOfWork.Save();
            return destObject.Id;
        }
        public UserModel SearchUser(UserModel model)
        {
            var destObject = model.Adapt<MyRestaurant.DataAccess.Models.User>();
            var user = _unitOfWork.User.Get(x => x.PhoneNumber == model.PhoneNumber && x.Password == model.Password).FirstOrDefault();
            UserModel result = null;
            if (user != null)
            {
                result = model;
            }
            return result;
        }
        public bool PhoneVerifaction(string phoneNumber)
        {
            var user = _unitOfWork.User.Get(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
            bool result;
            if (user != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
