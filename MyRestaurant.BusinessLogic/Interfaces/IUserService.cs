using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        public int Register(UserModel model);
        public bool PhoneVerifaction(string phoneNumber);
        public UserModel SearchUser(UserModel model);
    }
}
