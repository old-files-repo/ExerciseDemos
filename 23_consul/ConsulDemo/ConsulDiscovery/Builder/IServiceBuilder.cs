using System;
using System.IO;
using System.Threading.Tasks;
using ConsulDiscovery.LoadBalancer;

namespace ConsulDiscovery.Builder
{
    public interface IServiceBuilder
    {
        IServiceProvider ServiceProvider { get; set; }
        string ServiceName { get; set; }
        string UriScheme { get; set; }
        ILoadBalancer LoadBalancer { get; set; }
        Task<Uri> BuilderAsync(string path);
    }
}