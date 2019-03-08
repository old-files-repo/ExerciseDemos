using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;

namespace MvcCLient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            IdentityModelEventSource.ShowPII = true;

            services.AddMvc();

         

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); //这句话是指, 我们关闭了JWT的Claim 类型映射, 以便允许well-known claims.

            services.AddAuthentication(opts =>
                {
                    opts.DefaultScheme = "Cookies";
                    opts.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", opts =>
                {
                    opts.SignInScheme = "Cookies";
                    opts.Authority = "https://localhost:5001";
                    opts.RequireHttpsMetadata = true;
                    opts.ClientId = "mvcclient";
                    opts.ResponseType = "code id_token";
                    opts.Scope.Clear();
                    opts.Scope.Add("openid");
                    opts.Scope.Add("restapi");


                    opts.SaveTokens = true;
                    opts.ClientSecret = "secret";

                });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
