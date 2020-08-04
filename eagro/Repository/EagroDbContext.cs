using eagro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eagro.Repository
{
    public class EagroDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public readonly static string ConnectionString =
           "Server =localhost; " +
           "Database = Eagro; " +
           "User Id = sa; " +
           "Password = admin!@#123;";

        public static DbContextOptionsBuilder<EagroDbContext> optionsBuilder =
               new DbContextOptionsBuilder<EagroDbContext>().UseSqlServer(EagroDbContext.ConnectionString);

        public EagroDbContext(DbContextOptions<EagroDbContext> options)
                : base(options)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public EagroDbContext()
        {

        }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
