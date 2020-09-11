using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsulDiscovery;
using ConsulDiscovery.LoadBalancer;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ConsulServiceProvider(new Uri("http://127.0.0.1:8500"));
            var myServiceA = serviceProvider.CreateServiceBuilder(build =>
            {
                build.ServiceName = "ServerA";
                build.LoadBalancer = TypeLoadBalancer.RoundRob;
                build.UriScheme = Uri.UriSchemeHttp;
            });

            var httpClient = new HttpClient();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"第{i}次");
                try
                {
                    var uri = myServiceA.BuilderAsync("health").Result;
                    var content = httpClient.GetStringAsync(uri).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                Task.Delay(100).Wait();
            }
        }
    }
}