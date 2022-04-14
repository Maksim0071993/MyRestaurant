using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.Presentation.Models;

namespace MyRestaurant.Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserProfileService _userProfile;
        private readonly IMapper _mapper;

        public ProfileController(IUserProfileService userProfile, IMapper mapper)
        {
            _userProfile = userProfile;
            _mapper = mapper;
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
            var userId = int.Parse(User.Identity.Name);
            var mappedProfile = _mapper.Map<UserProfileModel>(model);
            mappedProfile.Id = userId;
            _userProfile.CreateProfile(mappedProfile);
            return RedirectToAction("Index", "Home");
        }
    }
}
