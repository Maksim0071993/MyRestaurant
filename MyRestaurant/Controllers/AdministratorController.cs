using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.BusinessLogic.Interfaces;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.Presentation.Models;
using System.IO;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorService _administratorService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMapper _mapper;

        public AdministratorController(IAdministratorService administratorService, IWebHostEnvironment appEnvironment, IMapper mapper)
        {
            _administratorService = administratorService;
            _appEnvironment = appEnvironment;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateDish()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromForm] DishViewModel model, IFormFile uploadedFile)
        {
            var dishModel = _mapper.Map<DishModel>(model);
            if (uploadedFile != null)
            {  
                string path = "/Photo/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                dishModel.Photo = uploadedFile.FileName;
                dishModel.PhotoPath = path;      
            }
            
            _administratorService.CreateDish(dishModel);
            return View();
        }
    }
}
