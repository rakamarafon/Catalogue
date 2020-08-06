using Catalogue.Core.Interfaces;
using Catalogue.DAL.Model;
using Catalogue.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Users> Authenticate(string login, string password)
        {
            var user = await unitOfWork.UserRepository
                .Get(x => x.Login == login && x.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
                return null;

            user.Password = null;
            return user;
        }
    }
}
