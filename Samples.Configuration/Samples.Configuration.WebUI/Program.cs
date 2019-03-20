using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Samples.Configuration.WebUI.Configuration;

namespace Samples.Configuration.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddYaml("appsettings.yaml");
                })
                .UseStartup<Startup>();
    }
}