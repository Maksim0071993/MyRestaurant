using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public string Photo { get; set; }
        public List<Order> Orders { get; set; }
        public List<Ingridient> Ingridients { get; set; }
    }
}
