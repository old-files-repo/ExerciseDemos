using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyRestful.Api.Middlewares;
using MyRestful.Api.Valids;
using MyRestful.Infrastructure;
using MyRestful.Infrastructure.Repositories;
using MyRestful.Infrastructure.UnitOfWork;

namespace MyRestful.Api
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          

            services.AddDbContext<MyContext>(optipns =>
            {
                optipns.UseInMemoryDatabase("MyRestful");
            });

            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                options.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CountryAddValidator>());

            services.AddAutoMapper();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var serverSecret = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["JWT:ServerSecret"]));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = serverSecret,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"]
                    };
                });

            services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
                    options.HttpsPort = 5001;
                });

            services.AddCors();

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Limit = 10,
                        Period = "5m"
                    },
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Limit = 2,
                        Period = "10s"
                    }
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .WithOrigins("http://example.com")
                .AllowAnyHeader());

            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHsts();
            //app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMiddleware<CustomExceptionHandler>();

            app.UseIpRateLimiting();

            //else
            //{
            //    app.UseExceptionHandler(builder =>
            //    {
            //        builder.Run(async context =>
            //        {
            //            context.Response.StatusCode = 500;
            //            await context.Response.WriteAsync("An error occured");
            //        });
            //    });
            //}

            app.UseMvc();
        }
    }
}
