[assembly: Microsoft.Owin.OwinStartup(typeof(Service.Web.Startup))]

namespace Service.Web
{
    using System;
    using System.IO;
    using System.Web.Http;
    using System.Web.Routing;

    using Owin;

    using Service.Configs;

    public class Startup
    {
        public static void Configure(IAppBuilder app, HttpConfiguration configuration)
        {
            WebApiConfig.Register(configuration);

            app.UseWebApi(configuration);
        }

        public void Configuration(IAppBuilder app)
        {
            Configure(app, new HttpConfiguration());
        }
    }
}