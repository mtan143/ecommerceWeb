using EcommerceWeb.Hubs;
using EcommerceWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(EcommerceWeb.Startup))]
namespace EcommerceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
