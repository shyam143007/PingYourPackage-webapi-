namespace PingYourPackage.Domain.Migrations
{
    using PingYourPackage.Domain.Models;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<PingYourPackage.Domain.EntitiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PingYourPackage.Domain.EntitiesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.AddOrUpdate(role => role.Name,
                new Role() { Key = Guid.NewGuid(), Name = "Admin" },
                new Role() { Key = Guid.NewGuid(), Name = "Employee" },
                new Role() { Key = Guid.NewGuid(), Name = "Affiliate" });
        }
    }
}
