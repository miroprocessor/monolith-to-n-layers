using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CustomerTreatments.WebAreas.Identity.IdentityHostingStartup))]
namespace CustomerTreatments.WebAreas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}