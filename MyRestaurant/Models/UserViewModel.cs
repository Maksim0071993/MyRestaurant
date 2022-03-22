using MyRestaurant.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Roles Role { get; set; }
    }
}
