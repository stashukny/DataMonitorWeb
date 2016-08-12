using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataMonitorWeb.Startup))]
namespace DataMonitorWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
