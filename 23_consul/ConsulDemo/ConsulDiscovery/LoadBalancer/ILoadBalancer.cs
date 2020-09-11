using System.Collections;
using System.Collections.Generic;

namespace ConsulDiscovery.LoadBalancer
{
    public interface ILoadBalancer
    {
        string Resolve(IList<string> services);
    }
}