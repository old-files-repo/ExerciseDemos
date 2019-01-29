using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.Api.Data;
using CoreBackend.Api.Dtos;
using CoreBackend.Api.Entities;
using CoreBackend.Api.Filters;
using CoreBackend.Api.Middlwares;
using CoreBackend.Api.Repositories;
using CoreBackend.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CoreBackend.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Main -> ConfigureServices -> Configure
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options =>
                {
                    options.Filters.Add<DefaultUserNameFilterAttribute>();

                    options.RespectBrowserAcceptHeader = true;
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                }) // 注册MVC到Container
                .AddJsonOptions(options =>
                {
                    //去掉camel case
                    if (options.SerializerSettings.ContractResolver is DefaultContractResolver resolver)
                    {
                        resolver.NamingStrategy = null;
                    }

                })
                .AddMvcOptions(options =>//添加xml格式
                {
                    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                });

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
            services.AddRouting();

            //开发环境
            var connectionString = Configuration["connectionStrings:productionInfoDbConnectionString"];
            services.AddDbContext<MyContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductWithoutMaterialDto>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<Material, MaterialDto>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, MyContext myContext)
        {
            loggerFactory.AddNLog();//等同于 loggerFactory.AddProvider(new NLogLoggerProvider());

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage(); 就是一个middleware, 当exception发生的时候, 这段程序就会处理它.
                //而判断env.isDevelopment() 表示, 这个middleware只会在Development环境下被调用.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseRouter(builder =>
                {
                    builder.MapRoute(string.Empty, context => context.Response.WriteAsync("Returned"));
                    builder.MapGet("user/{name}", (req, res, routeData) => res.WriteAsync($"hi {routeData.Values["name"]}"));
                    builder.MapPost("user/{name}", (req, res, routeData) => res.WriteAsync($"hi,post name is {routeData.Values["name"]}"));
                });

            app.Map("/return",
                (skipApp) => skipApp.Run(async (context) => await context.Response.WriteAsync("Returned")));

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/end")
                {
                    await context.Response.WriteAsync("The End");
                }
                else
                {
                    await next();
                }
            });

            //app.Use(async (context, next) =>
            //{
            //    var value = context.Request.Query["value"].ToString();
            //    if (int.TryParse(value, out int number))
            //    {
            //        await context.Response.WriteAsync($"the number is {number}");
            //    }
            //    else
            //    {
            //        context.Items["value"] = value;
            //        await next();
            //    }
            //});

            app.UseMiddleware<NumberMiddleware>();

            myContext.EnsureSeedDataForContext();

            app.UseStatusCodePages(); // !!!

            app.UseMvc();
        }
    }
}
