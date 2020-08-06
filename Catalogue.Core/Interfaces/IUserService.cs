using Catalogue.DAL.Model;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IUserService
    {
        Task<Users> Authenticate(string login, string password);
    }
}
