using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //start the workflow host
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<PassingDataWorkflow, MyDataClass>();
            host.Start();
            var initialData = new MyDataClass
            {
                Value1 = 2,
                Value2 = 3
            };
            host.StartWorkflow("PassingDataWorkflow", 1, initialData);
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            //services.AddWorkflow(x => x.UseSqlServer(@"Server=.\SQLEXPRESS;Database=WorkflowCore;Trusted_Connection=True;", true, true));
            var serviceProvider = services.BuildServiceProvider();

            //config logging
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.CreateLogger<Program>();
            return serviceProvider;
        }
    }

    public class PassingDataWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => "PassingDataWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<AddNumbers>()
                .Input(step => step.Input1, data => data.Value1)
                .Input(step => step.Input2, data => data.Value2)
                .Output(data => data.Value3, step => step.Output)
                .Then<CustomMessage>()
                .Input(step => step.Message, data => "The answer is " + data.Value3.ToString());
        }
    }

    public class CustomMessage : StepBody
    {

        public string Message { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(Message);
            return ExecutionResult.Next();
        }
    }

    public class AddNumbers : StepBody
    {
        public int Input1 { get; set; }

        public int Input2 { get; set; }

        public int Output { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Output = (Input1 + Input2);
            return ExecutionResult.Next();
        }
    }
    public class MyDataClass
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
    }

}
