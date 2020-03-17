using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAGEWebsite.Data;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Web.Helpers;

[assembly: HostingStartup(typeof(SAGEWebsite.Areas.Identity.IdentityHostingStartup))]
namespace SAGEWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}