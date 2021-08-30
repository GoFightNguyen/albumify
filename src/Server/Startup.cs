using Albumify.Server.Services;
using AspNet.Security.OAuth.Spotify;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Albumify.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: when using real data, consider compression

            services.AddSingleton<LocalArtistDataManager>();

            services.AddAuthorization(options => {
                options.AddPolicy(SpotifyAuthenticationDefaults.AuthenticationScheme, policy => {
                    policy.AddAuthenticationSchemes(SpotifyAuthenticationDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });
            services
                .AddAuthentication(options => {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = SpotifyAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddSpotify(SpotifyAuthenticationDefaults.AuthenticationScheme, options => {
                    //https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src/AspNet.Security.OAuth.Spotify

                    // TODO: continue here
                    // Currently, auth flow does not work. There is an Authorize attribute on the artist api
                    // There are not authorizations set up client-side
                    options.ClientId = "";
                    options.ClientSecret = "";
                });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
