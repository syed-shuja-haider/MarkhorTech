using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarkhorTech.Web.Startup))]
namespace MarkhorTech.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
