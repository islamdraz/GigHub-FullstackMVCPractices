using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FullStackCourse1.Startup))]
namespace FullStackCourse1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
