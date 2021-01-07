using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PogoWebCore;

[assembly: HostingStartup(typeof(PogoWebCore.Areas.Identity.IdentityHostingStartup))]
namespace PogoWebCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddIdentity<PogoUser, PogoRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<PogoRole>()
                    .AddDefaultTokenProviders()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<PogoContext>();
            });
        }
    }
}