using PingYourPackage.Domain.IRepositories;
using PingYourPackage.Domain.Models;
using System.Linq;

namespace PingYourPackage.Domain.Repository.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static User GetUserByName(this IEntityRepository<User> repository, string userName)
        {
            return repository.GetAll().FirstOrDefault(x => x.Name == userName);
        }
    }

}
