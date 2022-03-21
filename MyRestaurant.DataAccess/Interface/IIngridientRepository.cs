using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IIngridientRepository
    {
        public void Add(Ingridient ingridient);
        public List<Ingridient> Get(Func<Ingridient, bool> func);
        public List<Ingridient> GetAll();
    }
}
