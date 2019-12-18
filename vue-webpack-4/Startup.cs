using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace vue_webpack_4
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddLogging();

            services.Configure<CookiePolicyOptions>( options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            } );

            services.AddControllers()
                    .SetCompatibilityVersion( CompatibilityVersion.Version_3_0 );

            services.AddResponseCompression( options => options.EnableForHttps = true );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopment( IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger )
        {
            app.UseResponseCompression();

            app.UseCookiePolicy();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( routes =>
            {
                routes.MapDefaultControllerRoute();
                routes.MapControllerRoute( "spa-fallback", "{*url:regex(^(?!dist).*$)}", new { controller = "Home", action = "Index" } );
            } );

            app.UseSpa( spa =>
            {
                spa.Options.DefaultPage = "/index-dev.html";
                spa.UseProxyToSpaDevelopmentServer( "http://localhost:55555" );
            } );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureProduction( IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger )
        {
            app.UseResponseCompression();

            app.UseCookiePolicy();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( routes => routes.MapDefaultControllerRoute() );

            app.UseSpa( spa =>
            {
                spa.Options.DefaultPage = "/index.html";
            } );

            app.UseExceptionHandler( "/Error" );

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
    }
}
