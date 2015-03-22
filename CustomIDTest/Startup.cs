using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomIDTest.Startup))]
namespace CustomIDTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
