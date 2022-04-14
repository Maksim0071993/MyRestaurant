using AutoMapper;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurant.Presentation.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DishViewModel, DishModel>().ReverseMap();
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<UserProfileViewModel, UserProfileModel>().ReverseMap();
        }
    }
}
