using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Models;
using MyRestaurant.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserProfileService _userProfile;
        public ProfileController(IUserProfileService userProfile)
        {
            _userProfile = userProfile;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Registration");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserProfileViewModel model)
        {
            model.UserId = int.Parse(User.Identity.Name);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserProfileViewModel, UserProfileModel>());
            var mapper = new Mapper(config);
            var mappedProfile = mapper.Map<UserProfileModel>(model);
            _userProfile.CreateProfile(mappedProfile);
            return RedirectToAction("Index", "Home");
        }
    }
}
