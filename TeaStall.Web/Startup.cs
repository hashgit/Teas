using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeaStall.Web.Startup))]
namespace TeaStall.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
