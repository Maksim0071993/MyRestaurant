using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IUserProfileRepository
    {
        public void Add(UserProfile userProfile);
        public List<UserProfile> Get(Func<UserProfile, bool> func);
        public List<UserProfile> GetAll();
    }
}
