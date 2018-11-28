using PingYourPackage.Domain.IRepositories;
using PingYourPackage.Domain.Models;
using System;
using System.Collections.Generic;

namespace PingYourPackage.API.BusinessLogic.MembershipService
{
    public interface IMembershipService
    {
        ValidUserContext ValidateUser(string username, string password);

        OperationResult<UserWithRoles> CreateUser(string username, string password, string email);

        OperationResult<UserWithRoles> CreateUser(string username, string password, string email, string role);

        OperationResult<UserWithRoles> CreateUser(string username, string password, string email, string[] roles);

        UserWithRoles UpdateUser(User user, string username, string email);

        bool ChangePassword(string username, string oldPassword, string newPassword);

        bool AddToRole(Guid userKey, string role);

        bool AddToRole(string username, string role);

        bool RemoveFromRole(string username, string role);

        IEnumerable<Role> GetRoles();

        Role GetRole(Guid key);

        Role GetRole(string name);

        PaginatedList<UserWithRoles> GetUsers(int pageIndex, int pageSize);

        UserWithRoles GetUser(string username);

        UserWithRoles GetUser(Guid key);

    }
}
