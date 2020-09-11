using System.Net.NetworkInformation;

namespace ConsulDiscovery.LoadBalancer
{
    public static class TypeLoadBalancer
    {
        public static ILoadBalancer Random = new RandomLoadBalancer();
        public static ILoadBalancer RoundRob = new RoundRobLoadBalancer();
    }
}