using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Interfaces
{
    public interface IAdministratorService
    {
        public int CreateDish(DishModel model);
    }
}
