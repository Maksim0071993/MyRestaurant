using AutoMapper;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.Models;
using MyRestaurant.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;

        public HomeController(IDishService dishService, IOrderService orderService)
        {
            _dishService = dishService;
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var dishes = _dishService.GetAll();
            return View("Index", dishes.ToList());
        }
        [HttpPost]
        public IActionResult Index([FromForm] DishModel dish)
        {
            if(User.Identity.IsAuthenticated)
            {
                int userId = int.Parse(User.Identity.Name);
                var dishToOrder = _dishService.GetById(dish.Id);
                var order = _orderService.GetNotCompletedOrder(userId);
                if (order == null)
                {
                    order = _orderService.CreateOrder(userId);
                }         
                _orderService.AddDishToOrder(order.Id,dishToOrder.Id);
                ViewBag.Message = "Товар добавлен в корзину";
            }

            else
            {
                return RedirectToAction("Index", "Registration");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
