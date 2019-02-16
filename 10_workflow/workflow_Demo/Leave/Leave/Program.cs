using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace Leave
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //start the workflow host
            var host = serviceProvider.GetService<IWorkflowHost>();
            //host.RegisterWorkflow<HelloWorldWorkflow>();
            host.RegisterWorkflow<LeaveWorkflow, MyDataClass>();
            host.Start();

            string workflowId = host.StartWorkflow("Leave").Result;

            var openItems = host.GetOpenUserActions(workflowId);
            //foreach (var item in openItems)
            //{
            //    Console.ReadLine();
            //}

            for (int i = 0; i < 2; i++)
            {
                Console.ReadLine();
            }

            host.Stop();
        }

        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            //services.AddTransient<GoodbyeWorld>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
