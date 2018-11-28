using PingYourPackage.API.BusinessLogic.CryptoService;
using PingYourPackage.Domain.IRepositories;
using PingYourPackage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace PingYourPackage.API.BusinessLogic.MembershipService
{
    public class MembershipService : IMembershipService
    {
        private readonly IEntityRepository<User> userRepo;
        private readonly IEntityRepository<Role> roleRepo;
        private readonly IEntityRepository<UserInRole> userInRoleRepo;
        private readonly ICryptoService cryptoService;

        public MembershipService(IEntityRepository<User> _userRepo,
            IEntityRepository<Role> _roleRepo,
            IEntityRepository<UserInRole> _userInRoleRepo,
            ICryptoService _cryptoService)
        {
            userRepo = _userRepo;
            roleRepo = _roleRepo;
            userInRoleRepo = _userInRoleRepo;
            cryptoService = _cryptoService;
        }


        public bool AddToRole(Guid userKey, string role)
        {
            throw new NotImplementedException();
        }

        public bool AddToRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public OperationResult<UserWithRoles> CreateUser(string username, string password, string email)
        {
            return CreateUser(username, password, email, roles: null);
        }

        public OperationResult<UserWithRoles> CreateUser(string username, string password, string email, string role)
        {
            return CreateUser(username, password, email, roles: new[] { role });
        }

        public OperationResult<UserWithRoles> CreateUser(string username, string password, string email, string[] roles)
        {
            var existingUser = userRepo.GetAll().Any(x => x.Name == username);

            if (existingUser)
            {
                return new OperationResult<UserWithRoles>(false);
            }

            string passwordSalt = cryptoService.GenerateSalt();
            User user = new User()
            {
                Name = username,
                Email = email,
                Salt = passwordSalt,
                IsLocked = false,
                HashedPassword = cryptoService.EncryptPassword(password, salt: passwordSalt),
                CreatedOn = DateTime.Now
            };

            userRepo.Add(user);
            userRepo.Save();

            if (roles != null && roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            return new OperationResult<UserWithRoles>(true)
            {
                Entity = GetuserWithRoles(user)
            };
        }

        private void addUserToRole(User user, string roleName)
        {
            var role = roleRepo.GetSingleRoleByName(x => x.Name == roleName);

            if(role == null)
            {
                var tempRole = new Role()
                {
                    Name = roleName
                };
                roleRepo.Add(role);
                roleRepo.Save();
                role = tempRole;
            }

            var userInRole = new UserInRole()
            {
                UserKey = user.Key,
                RoleKey = role.Key
            };

            userInRoleRepo.Add(userInRole);
            userInRoleRepo.Save();
        }

        public Role GetRole(Guid key)
        {
            throw new NotImplementedException();
        }

        public Role GetRole(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public UserWithRoles GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public UserWithRoles GetUser(Guid key)
        {
            throw new NotImplementedException();
        }

        public PaginatedList<UserWithRoles> GetUsers(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public UserWithRoles UpdateUser(User user, string username, string email)
        {
            throw new NotImplementedException();
        }

        public ValidUserContext ValidateUser(string username, string password)
        {
            ValidUserContext validUserContext = new ValidUserContext();

            User user = userRepo.GetSingleByUsername(username);

            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Key);
                validUserContext.User = new UserWithRoles()
                {
                    User = user,
                    Roles = userRoles
                };

                var identity = new GenericIdentity(user.Name);
                validUserContext.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
            }
            return validUserContext;
        }

        private IEnumerable<Role> GetUserRoles(Guid key)
        {
            var userInRoles = userInRoleRepo.FindBy(x => x.UserKey == key).ToList();

            if (userInRoles != null && userInRoles.Count > 0)
            {
                var roleKeys = userInRoles.Select(x => x.RoleKey).ToArray();
                var userRoles = roleRepo.FindBy(x => roleKeys.Contains(x.Key)).ToList();
                return userRoles;
            }
            return Enumerable.Empty<Role>();
        }

        private bool isUserValid(User user, string password)
        {
            if (isValidPassword(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }

        private bool isValidPassword(User user, string password)
        {
            return string.Equals(user.HashedPassword,
                cryptoService.EncryptPassword(password, user.Salt));
        }
    }
}
