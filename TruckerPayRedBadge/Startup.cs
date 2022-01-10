using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TruckerPayRedBadge.Startup))]
namespace TruckerPayRedBadge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
