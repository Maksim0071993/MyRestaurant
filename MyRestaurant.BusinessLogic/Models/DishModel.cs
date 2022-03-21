using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingridients { get; set; }
        public int Weight { get; set; }
        public string Photo { get; set; }
    }
}
