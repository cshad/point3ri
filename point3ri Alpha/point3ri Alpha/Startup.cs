using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(point3ri_Alpha_0._51.Startup))]
namespace point3ri_Alpha_0._51
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
