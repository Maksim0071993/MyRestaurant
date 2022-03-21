using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
