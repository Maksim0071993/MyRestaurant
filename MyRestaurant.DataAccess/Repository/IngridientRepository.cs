using MyRestaurant.DataAccess;
using MyRestaurant.DataAccess.Interface;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRestaurant.DataAccess.Repository
{
    public class IngridientRepository : IIngridientRepository
    {
        private readonly MyRestaurantContext _restaurantContext;
        public IngridientRepository(MyRestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }

        public void Add(Ingridient ingridient)
        {
            _restaurantContext.Ingridients.Add(ingridient);
        }

        public List<Ingridient> Get(Func<Ingridient, bool> func)
        {
            var ingridients = _restaurantContext.Ingridients.Where(func).ToList();
            return ingridients;
        }
        public List<Ingridient> GetAll()
        {
            var ingridients = _restaurantContext.Ingridients.ToList();
            return ingridients;
        }
    }
}
