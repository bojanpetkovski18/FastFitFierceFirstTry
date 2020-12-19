using FastFitFierce.DAL;
using FastFitFierce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(FastFitFierce.Startup))]
namespace FastFitFierce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
