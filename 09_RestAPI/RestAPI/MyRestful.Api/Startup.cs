using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CustomExceptionHandler>();
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
