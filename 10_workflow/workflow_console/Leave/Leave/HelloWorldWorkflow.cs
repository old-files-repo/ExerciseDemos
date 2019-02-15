using System;
using Leave.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Leave
{
    public class HelloWorldWorkflow : IWorkflow
    {
        public string Id => "HelloWorld";
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<SleepStep>()
                .Then<HelloWorld>()
                .Then(context =>
                {
                    Console.WriteLine("Goodbye world");
                    return ExecutionResult.Next();
                });
        }
    }

    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world");
            return ExecutionResult.Next();
        }
    }
}