using System;
using Leave.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Leave
{
    public class LeaveWorkflow : IWorkflow<MyDataClass>
    {
        public string Id => "Leave";
        public int Version => 1;

        public void Build(IWorkflowBuilder<MyDataClass> builder)
        {
            builder
                .StartWith<SleepStep>()
                .Then<InputDay>(day =>
                {
                    day.When(Leader.主任)
                        .Then(context =>
                        {
                            Console.WriteLine($"主任审批通过");
                            return ExecutionResult.Next();
                        });
                    day.When(Leader.部长)
                        .Then(context =>
                        {
                            Console.WriteLine($"部长审批通过");
                            return ExecutionResult.Next();
                        });
                    day.When(Leader.人力资源部)
                        .Then(context =>
                        {
                            Console.WriteLine($"人力资源部审批通过");
                            return ExecutionResult.Next();
                        });
                })
                .Then(context =>
                {
                    Console.WriteLine("结束");
                    return ExecutionResult.Next();
                });
        }
    }

    public class InputDay : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("请输入请假天数");
            var input = Convert.ToInt32(Console.ReadLine());
            Leader output;
            if (input <= 2)
            {
                output = Leader.主任;
            }
            else if (input <= 3)
            {
                output = Leader.部长;
            }
            else
            {
                output = Leader.人力资源部;
            }
            return ExecutionResult.Outcome(output);
        }
    }
}