using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurSchool.Startup))]
namespace OurSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
