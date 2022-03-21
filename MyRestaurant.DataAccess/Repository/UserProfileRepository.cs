using MyRestaurant.DataAccess.Interface;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRestaurant.DataAccess.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly MyRestaurantContext _context;
        public UserProfileRepository(MyRestaurantContext context)
        {
            _context = context;
        }
        public void Add(UserProfile userProfile)
        {
            _context.Add(userProfile);
        }
        public List<UserProfile> Get(Func<UserProfile, bool> func)
        {
            var profile = _context.UserProfiles.Where(func).ToList();
            return profile;
        }
        public List<UserProfile> GetAll()
        {
            var allUsers = _context.UserProfiles.ToList();
            return allUsers;
        }
    }
}
