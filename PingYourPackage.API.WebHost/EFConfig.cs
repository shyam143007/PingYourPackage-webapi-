using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingYourPackage.API.WebHost
{
    public class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }

        private static void RunMigrations()
        {
           //var efMigrations = new PingYourPackage.Domain
        }
    }
}