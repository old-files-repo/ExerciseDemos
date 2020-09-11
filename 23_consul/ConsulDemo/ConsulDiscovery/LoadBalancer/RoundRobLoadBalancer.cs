using System.Collections.Generic;

namespace ConsulDiscovery.LoadBalancer
{
    public class RoundRobLoadBalancer : ILoadBalancer
    {
        private readonly object _lock = new object();
        private int _index = 0;

        public string Resolve(IList<string> services)
        {
            lock (_lock)
            {
                if (_index >= services.Count)
                {
                    _index = 0;
                }

                return services[_index++];
            }
        }
    }
}