using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IDishService
    {
        public List<DishModel> GetAll();
        public DishModel GetById(int id);
    }
}
