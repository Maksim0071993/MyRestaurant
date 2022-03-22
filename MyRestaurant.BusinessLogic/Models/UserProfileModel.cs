using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
