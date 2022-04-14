
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public int Register(UserModel model)
        {
            var mappedUser = _mapper.Map<MyRestaurant.DataAccess.Models.User>(model);
            _unitOfWork.User.Add(mappedUser);
            _unitOfWork.Save();
            return mappedUser.Id;
        }
        public UserModel SearchUser(UserModel model)
        {
            var user = _unitOfWork.User.Get(x => x.PhoneNumber == model.PhoneNumber && x.Password == model.Password).FirstOrDefault();
            UserModel result = null;
            if (user != null)
            {
                result = _mapper.Map<UserModel>(user);
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
