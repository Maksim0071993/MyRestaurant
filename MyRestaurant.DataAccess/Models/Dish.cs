using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Models
{
    public class Dish
    {
        public Dish()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Photo { get; set; }
        public string Ingridient { get; set; }
        public string PhotoPath { get; set; }
        public List<Order> Orders { get; set; }
    }
}
