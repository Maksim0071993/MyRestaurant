using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
