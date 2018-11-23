using PingYourPackage.Domain.IRepositories;
using PingYourPackage.Domain.Models;
using System.Linq;

namespace PingYourPackage.Domain.Repository.Extensions
{
    public static class RoleExtensions
    {
        public static Role GetRoleByName(this IEntityRepository<Role> repo, string roleName)
        {
            return repo.GetAll().FirstOrDefault(x => x.Name == roleName);
        }
    }
}
