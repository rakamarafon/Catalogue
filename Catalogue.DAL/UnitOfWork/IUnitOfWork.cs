using Catalogue.DAL.Model;
using Catalogue.DAL.Repository;
using System;
using System.Threading.Tasks;

namespace Catalogue.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> UserRepository { get; }
        IRepository<Orders> OrderRepository { get; }
        IRepository<Items> ItemRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
