using Catalogue.DAL.Context;
using Catalogue.DAL.Model;
using Catalogue.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Catalogue.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Users> userRepository;
        private IRepository<Orders> orderRepository;
        private IRepository<Items> itemRepository;

        private readonly IServiceProvider serviceProvider;
        private readonly IDataContext context;

        public UnitOfWork(IServiceProvider serviceProvider, IDataContext context)
        {
            this.serviceProvider = serviceProvider;
            this.context = context;
        }

        public IRepository<Users> UserRepository
        {
            get
            {
                if(userRepository == null)
                   userRepository = serviceProvider.GetRequiredService<IRepository<Users>>();
                return userRepository;
            }
        }

        public IRepository<Orders> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = serviceProvider.GetRequiredService<IRepository<Orders>>();
                return orderRepository;
            }
        }

        public IRepository<Items> ItemRepository
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = serviceProvider.GetRequiredService<IRepository<Items>>();
                return itemRepository;
            }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
