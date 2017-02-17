using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppUI.Startup))]
namespace WebAppUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
