using AutoMapper;
using MyRestaurant.BusinessLogic.Models;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.BusinessLogic.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<DishModel, Dish>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserProfileModel, UserProfile>().ReverseMap();
        }
    }
}
