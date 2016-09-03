using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Refactoring.Startup))]
namespace Refactoring
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
