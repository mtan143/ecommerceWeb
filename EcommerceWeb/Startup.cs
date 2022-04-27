using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceWeb.Startup))]
namespace EcommerceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
