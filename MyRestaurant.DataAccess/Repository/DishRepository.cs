using AutoMapper;
using MyRestaurant.DataAccess;
using MyRestaurant.DataAccess.Interface;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRestaurant.DataAccess.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly MyRestaurantContext _restaurantContext;
        public DishRepository(MyRestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public List<Dish> Get(Func<Dish, bool> func)
        {   
            var dishes = _restaurantContext.Dishes.Where(func).ToList();
            return dishes;
        }

        public void Add(Dish dish)
        {
            _restaurantContext.Dishes.Add(dish);
        }

        public List<Dish> GetAll()
        {
            var dishes = _restaurantContext.Dishes.ToList();
            return dishes;
        }
        public Dish GetDishById(int id)
        {
            var dish = _restaurantContext.Dishes.Where(x => x.Id == id).FirstOrDefault();

            return dish;
        }
    }
}
