using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Models
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<Dish>();
        }

        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsCompleted { get; set; }
    }
}
