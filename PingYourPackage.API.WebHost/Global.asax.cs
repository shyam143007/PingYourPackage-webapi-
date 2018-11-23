using PingYourPackage.API.Config;
using System;
using System.Web.Http;

namespace PingYourPackage.API.WebHost
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
            var config = GlobalConfiguration.Configuration;

            WebApiConfig.Configure(config);
            RouteConfig.RegisterRoutes(config);
            AutofacWebAPI.Initialize(config);
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}