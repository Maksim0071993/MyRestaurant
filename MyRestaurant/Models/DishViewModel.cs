using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingridients { get; set; }
        public int Weight { get; set; }
        public string Photo { get; set; }
    }
}
