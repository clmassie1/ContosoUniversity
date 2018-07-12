using System;
using ContosoUniversity.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ContosoUniversity.Areas.Identity.IdentityHostingStartup))]
namespace ContosoUniversity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ContosoUniversityIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ContosoUniversityIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<ContosoUniversityIdentityDbContext>();
            });
        }
    }
}