using Catalogue.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.DAL.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);  
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
               new Users[]
               {
                    new Users { Id = 1, Login = "Manager", Password = "manager123", CustomerId = "manager" },
                    new Users { Id = 2, Login = "User1", Password = "usr1", CustomerId = "customer2usr" },
                    new Users { Id = 3, Login = "User2", Password = "usr2", CustomerId = "customer3usr" }
               });
            
            modelBuilder.Entity<Items>().HasData(
                new Items[]
                {
                    new Items { Id = 1, Name = "iPhone 6s", Price = 121.25M, UPC = 1001, OrdersId = 1 },
                    new Items { Id = 2, Name = "Lenovo ThinkPad", Price = 215M, UPC = 10010, OrdersId = 2 },
                    new Items { Id = 3, Name = "some", Price = 50M, UPC = 851205, OrdersId = 2 },
                    new Items { Id = 4, Name = "iPhone X", Price = 950.50M, UPC = 100101, OrdersId = 1 },
                    new Items { Id = 5, Name = "MacBook Pro 13", Price = 1200.50M, UPC = 20213, OrdersId = 2 }
                });            
            
            modelBuilder.Entity<Orders>().HasData(
                new Orders[]
                {
                    new Orders { Id = 1, UserId = 2 },
                    new Orders { Id = 2, UserId = 3 }
                });
                
        }
    }
}
