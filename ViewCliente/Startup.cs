using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViewCliente.Startup))]
namespace ViewCliente
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
