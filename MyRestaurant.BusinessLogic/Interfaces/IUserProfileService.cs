using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IUserProfileService
    {
        public int CreateProfile(UserProfileModel user);
        public UserProfileModel SearchUser(UserProfileModel model);
        public bool PhoneVerifaction(string phoneNumber);
    }
}
