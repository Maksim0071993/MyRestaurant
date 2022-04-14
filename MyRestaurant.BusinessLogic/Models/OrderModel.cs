using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public List<DishModel> Dishes { get; set; }
        public bool IsCompleted { get; set; }
    }
}
