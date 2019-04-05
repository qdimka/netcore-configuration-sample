using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Configuration.WebUI.Options;
using Samples.Configuration.WebUI.Services;

namespace Samples.Configuration.WebUI
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Options

            services
                .AddOptions<SettingsOptions>()
                .Bind(Configuration.GetSection("SettingsOptions"))
                .ValidateDataAnnotations();

            #endregion

            #region NamedOptions

            services.Configure<NamedOptions>("main", 
                Configuration.GetSection("FirstNamedOptions"));
            
            services.Configure<NamedOptions>("reserve", 
                Configuration.GetSection("SecondNamedOptions"));
            
            services.PostConfigure<NamedOptions>("main",
                opt => { opt.Name = "PostConfigureOptions";});
            
            #endregion

            #region Services

            services.AddSingleton<SampleSingletonService>();
            services.AddScoped<SampleScopedService>();
            services.AddScoped<SampleNamedOptionsService>();

            #endregion
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}