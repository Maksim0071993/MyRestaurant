using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Controllers
{
    public class ShopingBasketController : Controller
    {
        private readonly IOrderService _orderService;
        public ShopingBasketController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Basket()
        {
            int userId = int.Parse(User.Identity.Name);
            var order = _orderService.GetNotCompletedOrder(userId);
            if (order == null)
            {
                return RedirectToAction("EmptyBasket", "ShopingBasket");
            }
                foreach (var sum in order.Dishes)
                {
                    order.Sum = order.Sum + sum.Price;
                } 
            return View(order);
        }
        [HttpPost]
        public IActionResult Basket([FromForm] OrderModel model, DishModel dish)
        {   
            model.IsCompleted = true;
            //_orderService.DeleteDishFromOrder(dish.Id, model.Id);
            _orderService.ConfirmOrder(model);
            return RedirectToAction("OrderConfirmation", "ShopingBasket");
        }
        public IActionResult OrderConfirmation()
        {
            return View();
        }
        public IActionResult EmptyBasket()
        {
            return View();
        }
    }
}
