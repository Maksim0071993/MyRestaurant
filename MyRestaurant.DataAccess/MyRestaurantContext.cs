using Microsoft.EntityFrameworkCore;
using MyRestaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.DataAccess
{
    public class MyRestaurantContext : DbContext
    {
        public MyRestaurantContext()
        {
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BMNM0ER;Database=MyRestaurant;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
