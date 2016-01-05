using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(point3ri.Startup))]
namespace point3ri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
