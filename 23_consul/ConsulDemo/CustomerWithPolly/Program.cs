using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsulDiscovery;
using ConsulDiscovery.LoadBalancer;
using Polly;
using Polly.CircuitBreaker;

namespace CustomerWithPolly
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
            var policy = PolicyBuilder.CreatePolicy();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"第{i}次");
                policy.Execute(() =>
                {
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
                });
            }

//            var fallback = Policy.Handle<Exception>()
//                .Fallback(() => { Console.WriteLine("fall back"); });
//
//            var retry = Policy.Handle<Exception>()
//                .Retry(3, (exception, i) => { Console.WriteLine("retry" + i); });
//
//            var policy = Policy.Wrap(fallback, retry);
//
//            policy.Execute(() =>
//            {
//                Console.WriteLine("begin");
//                throw new Exception();
//            });
        }
    }
}