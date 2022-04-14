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
        public decimal Weight { get; set; }
        public string Photo { get; set; }
        public string Ingridient { get; set; }
        public string PhotoPath { get; set; }
    }
}
