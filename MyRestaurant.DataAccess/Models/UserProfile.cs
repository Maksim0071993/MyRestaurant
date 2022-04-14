using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.DataAccess.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Id))]
        public User User { get; set; }
    }
}
