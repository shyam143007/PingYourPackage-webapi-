using PingYourPackage.Domain.Models;
using System.Data.Entity;

namespace PingYourPackage.Domain
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("PingYourPackage")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserInRole> UserInRoles { get; set; }
        public IDbSet<Affiliate> Affiliates { get; set; }
        public IDbSet<Shipment> Shipments { get; set; }
        public IDbSet<ShipmentState> ShipmentStates { get; set; }
        public IDbSet<ShipmentType> PackageTypes { get; set; }

    }
}
