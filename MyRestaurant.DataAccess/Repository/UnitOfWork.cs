using MyRestaurant.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyRestaurantContext restaurantContext;
        private readonly IDishRepository dishRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IIngridientRepository ingridientRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserProfileRepository userProfileRepository;

        public UnitOfWork(
            MyRestaurantContext restaurantContext,
            IDishRepository dishRepository,
            IOrderRepository orderRepository,
            IIngridientRepository ingridientRepository,
            IUserRepository userRepository,
            IUserProfileRepository userProfileRepository
            )
        {
            this.userProfileRepository = userProfileRepository;
            this.restaurantContext = restaurantContext;
            this.dishRepository = dishRepository;
            this.orderRepository = orderRepository;
            this.ingridientRepository = ingridientRepository;
            this.userRepository = userRepository;
        }
        public IDishRepository Dish
        {
            get
            {
                return this.dishRepository;
            }
        }
        public IIngridientRepository Ingridient
        {
            get
            {
                return this.ingridientRepository;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                return this.orderRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                return this.userRepository;
            }
        }
        public IUserProfileRepository UserProfile
        {
            get
            {
                return this.userProfileRepository;
            }
        }

        public void Save()
        {
            restaurantContext.SaveChanges();
        }
    }
}
