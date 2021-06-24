using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THWEB_LAP23.Startup))]
namespace THWEB_LAP23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
