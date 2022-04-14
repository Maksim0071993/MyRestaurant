using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess.Interface
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IDishRepository Dish { get; }
        IUserRepository User { get; }
        IUserProfileRepository UserProfile { get; }
        void Save();
    }
}
