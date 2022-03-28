using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Controllers
{
    //[Authorize(Roles = typeof (Common.Roles.Administrator))]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDish()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDish([FromForm] DishViewModel model, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    uploadedFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    model.Photo = Convert.ToBase64String(fileBytes);
                }
            }
            var dishModel = model.Adapt<MyRestaurant.BusinessLogic.Models.DishModel>();
            _administratorService.CreateDish(dishModel);
            return View();
        }
    }
}
