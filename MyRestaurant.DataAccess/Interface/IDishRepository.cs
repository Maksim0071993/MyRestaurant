using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IDishRepository
    {
        public List<Dish> Get(Func<Dish, bool> func);
        public void Add(Dish dish);
        public List<Dish> GetAll();
    }
}
