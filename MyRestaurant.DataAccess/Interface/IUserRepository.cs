using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IUserRepository
    {
        public void Add(User user);
        public List<User> Get(Func<User, bool> func);
        public List<User> GetAll();
    }
}
