using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulDiscovery
{
    public interface IServiceProvider
    {
        Task<IList<string>> GetServicesAsync(string serviceName);
    }
}