using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurantes2.Startup))]
namespace Restaurantes2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
