using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.Models;
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
        private readonly IUserService _userService;

        public HomeController(IUserService userService, IDishService dishService)
        {
            _dishService = dishService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var dishes = _dishService.GetAll();
            return View("Index", dishes.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
