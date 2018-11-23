using System.Web.Http;

namespace PingYourPackage.API.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            //config.Routes.Add(name: "DefaultApi",
            //    route:);
        }
    }
}
