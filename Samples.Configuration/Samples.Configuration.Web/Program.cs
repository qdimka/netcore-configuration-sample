using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Samples.Configuration.Web.Configuration;

namespace Samples.Configuration.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((c, b) =>
                {
                    b.AddYaml("appsettings.yaml");
                    b.AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
