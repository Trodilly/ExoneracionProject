using System;
using ExoneracionProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ExoneracionProject.Areas.Identity.IdentityHostingStartup))]
namespace ExoneracionProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ExoneracionProjectDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ExoneracionProjectDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ExoneracionProjectDbContext>();
            });
        }
    }
}