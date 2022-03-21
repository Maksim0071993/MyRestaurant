using MyRestaurant.DataAccess.Interface;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyRestaurant.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyRestaurantContext _restaurantContext;
        public UserRepository(MyRestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public void Add(User user)
        {
            _restaurantContext.Users.Add(user);
        }

        public List<User> Get(Func<User, bool> func)
        {
            var users = _restaurantContext.Users.Where(func).ToList();

            return users;
        }
        public List<User> GetAll()
        {
            var allUsers = _restaurantContext.Users.ToList();
            return allUsers;
        }
    }
}
