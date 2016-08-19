using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cerberus.Startup))]
namespace Cerberus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
