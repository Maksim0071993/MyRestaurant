using AutoMapper;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.Common;
using MyRestaurant.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegistrationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] UserViewModel model)
        {
            model.Role = Common.Roles.User;
            var userModel = _mapper.Map<UserModel>(model);
            var resultVerivicationEmail = _userService.PhoneVerifaction(model.PhoneNumber);
            if (resultVerivicationEmail == true)
            {
                ModelState.AddModelError("", "Пользователь с таким телефоном существует");
            }
            else if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Пароли должны совпадать");
            }
            else
            {
                var result = _userService.Register(userModel);
                await Authenticate(result,userModel.Role);
                return RedirectToAction("Create", "Profile");
            }
            return View();
        }
        private async Task Authenticate(int userId, Roles role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString()),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
