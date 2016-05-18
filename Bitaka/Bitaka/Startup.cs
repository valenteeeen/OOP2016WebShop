using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bitaka.Startup))]
namespace Bitaka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
