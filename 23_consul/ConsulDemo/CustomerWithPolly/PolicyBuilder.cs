using System;
using Polly;

namespace CustomerWithPolly
{
    public static class PolicyBuilder
    {
        public static ISyncPolicy CreatePolicy()
        {
            //more than 1 minute
            var timeoutPolicy = Policy.Timeout(1,
                (context, span, arg3) => { Console.WriteLine("执行超时，抛出TimeoutRejectedException"); });

            //retry 2 times
            var retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetry(
                    2,
                    retryAttempt => TimeSpan.FromSeconds(2),
                    (exception, span, retryCount, arg4) =>
                    {
                        Console.WriteLine($"{DateTime.Now}-重试{retryCount}-throw{exception.GetType()}");
                    });

            var circuitBreakerPolicy = Policy.Handle<Exception>()
                .CircuitBreaker(
                    2,
                    TimeSpan.FromSeconds(5),
                    onBreak: (exception, state, arg3, arg4) => { Console.WriteLine($"{DateTime.Now}-break"); },
                    onReset: (context => { Console.WriteLine($"{DateTime.Now}-reset"); }),
                    onHalfOpen: (() => { Console.WriteLine($"{DateTime.Now}-halfopen"); }));

            var fallBack = Policy.Handle<Exception>()
                .Fallback(() => { Console.WriteLine("fallback"); },
                    exception => { Console.WriteLine($"fallback {exception.GetType()}"); });

            return Policy.Wrap(fallBack, circuitBreakerPolicy, retryPolicy, timeoutPolicy);
        }
    }
}