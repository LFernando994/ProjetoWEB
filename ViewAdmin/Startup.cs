using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViewAdmin.Startup))]
namespace ViewAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
