using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(startravel_web.Startup))]
namespace startravel_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
