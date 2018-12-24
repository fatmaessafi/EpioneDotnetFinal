using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEpione.Startup))]
namespace WebEpione
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
