using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
