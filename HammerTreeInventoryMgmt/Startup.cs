using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HammerTreeInventoryMgmt.Startup))]
namespace HammerTreeInventoryMgmt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
