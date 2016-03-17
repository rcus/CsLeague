using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CsLeague.Startup))]
namespace CsLeague
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
