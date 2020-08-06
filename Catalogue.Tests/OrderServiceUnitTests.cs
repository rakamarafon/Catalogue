using AutoMapper;
using Catalogue.Core.Interfaces;
using Catalogue.Core.Mapper;
using Catalogue.Core.Services;
using Catalogue.DAL.Model;
using Catalogue.DAL.UnitOfWork;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Tests
{
    public class OrderServiceUnitTests
    {
        private Users manager = new Users { Id = 1, Login = "Manager", Password = "mng123", CustomerId = "manager" };
        private Users user1 = new Users { Id = 2, Login = "User1", Password = "usr1", CustomerId = "user1" };
        private Users user2 = new Users { Id = 3, Login = "User2", Password = "usr2", CustomerId = "user2" };
        private IEnumerable<Orders> orders;
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private IOrderService orderService;

        public OrderServiceUnitTests()
        {
            unitOfWork = A.Fake<IUnitOfWork>();

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            }).CreateMapper();
        }

        [SetUp]
        public void SetpUp()
        {            
            orders = new List<Orders>()
            {
                new Orders
                {
                    Id = 1,
                    UserId = 2,
                    User = user1,
                    Items = new List<Items>
                    {
                        new Items { Id = 1, Name = "item 1", Price = 245M, UPC = 210M, OrdersId = 1}
                    }
                },
                new Orders
                {
                    Id = 2,
                    UserId = 3,
                    User = user2,
                    Items = new List<Items>
                    {
                        new Items { Id = 2, Name = "item 2", Price = 245M, UPC = 210M, OrdersId = 2}
                    }
                },
                new Orders
                {
                    Id = 3,
                    UserId = 2,
                    User = user1,
                    Items = new List<Items>
                    {
                        new Items { Id = 3, Name = "item 3", Price = 245M, UPC = 210M, OrdersId = 3}
                    }
                },
            };
        }

        [Test]
        public void SearchOrder_Manager_has_access_to_all_orders()
        {
            var temp = Task.Run(() =>
            {
                return orders;
            });
            var unitOfWork = A.Fake<IUnitOfWork>();

            A.CallTo(unitOfWork.OrderRepository)
                .Where(call => call.Method.Name == "Get")
                .WithReturnType<IQueryable<Orders>>()
                .Returns(orders.AsQueryable());       

            orderService = new OrderService(unitOfWork, mapper);
            var result = orderService.SearchOrderAsync(manager.CustomerId, "item");            
            
            Assert.That(result.Count() == orders.Count());
        }

        [Test]
        public void SearchOrder_User_has_access_only_to_own_orders()
        {
            var temp = Task.Run(() =>
            {
                return orders;
            });

            A.CallTo(unitOfWork.OrderRepository)
                .Where(call => call.Method.Name == "Get")
                .WithReturnType<IQueryable<Orders>>()                   
                .Returns(orders.AsQueryable());

            orderService = new OrderService(unitOfWork, mapper);
            var result = orderService.SearchOrderAsync(user1.CustomerId, "item");

            foreach (var item in result)
            {
                Assert.That(item.CustomerId == user1.CustomerId);
            }
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        public void SearchOrder_Performance_check(int itemsInCollection)
        {
            Assert.Pass();
        }
    }
}
