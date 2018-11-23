namespace PingYougPackage.Domain.Migrations
{
    using PingYougPackage.Domain.Models;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<PingYougPackage.Domain.EntitiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PingYougPackage.Domain.EntitiesContext context)
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
