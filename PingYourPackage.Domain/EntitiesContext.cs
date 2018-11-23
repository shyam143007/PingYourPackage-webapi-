﻿using PingYougPackage.Domain.Models;
using System.Data.Entity;

namespace PingYougPackage.Domain
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("PingYourPackage")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserInRole> UserInRoles { get; set; }

    }
}
