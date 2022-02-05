using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_.Startup))]
namespace Vidly_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
