using AutoMapper;
using Mapster;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Interface;
using System.Linq;

namespace MyRestaurant.BusinessLogic.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int CreateProfile(UserProfileModel user)
        {
            var mapeedUser = _mapper.Map<MyRestaurant.DataAccess.Models.UserProfile>(user);
            _unitOfWork.UserProfile.Add(mapeedUser);
            _unitOfWork.Save();
            return mapeedUser.Id;
        }
        public UserProfileModel SearchUser(int id)
        { 
            var user = _unitOfWork.UserProfile.Get(x => x.Id == id).FirstOrDefault();
            var mapeedUser = _mapper.Map<UserProfileModel>(user);
            return mapeedUser;
        }
    }
}
