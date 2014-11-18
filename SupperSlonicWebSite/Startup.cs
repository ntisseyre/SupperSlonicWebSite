using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SupperSlonicWebSite.Startup))]

namespace SupperSlonicWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}