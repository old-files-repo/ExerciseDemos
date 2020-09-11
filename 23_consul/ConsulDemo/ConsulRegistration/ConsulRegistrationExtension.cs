using System;
using System.Linq;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ConsulHelper
{
    public static class ConsulRegistrationExtension
    {
        public static void AddConsul(this IServiceCollection service)
        {
            var config = new ConfigurationBuilder().AddJsonFile("service.config.json").Build();
            service.Configure<ConsulServiceOptions>(config);
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            //获取主机生命周期
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            var serviceOptions = app.ApplicationServices.GetRequiredService<IOptions<ConsulServiceOptions>>().Value;
            serviceOptions.ServiceId = Guid.NewGuid().ToString();

            var consulClient = new ConsulClient(configure =>
            {
                configure.Address = new Uri(serviceOptions.ConsulAddress);
            });

            //获取当前服务器端口和地址
            var features = app.Properties["server.Features"] as FeatureCollection;
            var address = features.Get<IServerAddressesFeature>().Addresses.First();
            var uri = new Uri(address);

            var registration = new AgentServiceRegistration
            {
                ID = serviceOptions.ServiceId,
                Name = serviceOptions.ServiceName,
                Address = uri.Host,
                Port = uri.Port,
                Check = new AgentServiceCheck
                {
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    HTTP = $"{uri.Scheme}://{uri.Host}:{uri.Port}{serviceOptions.HealthCheck}",
                    Interval = TimeSpan.FromSeconds(10)
                }
            };

            consulClient.Agent.ServiceRegister(registration);
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceOptions.ServiceId);
            });
            return app;
        }
    }
}