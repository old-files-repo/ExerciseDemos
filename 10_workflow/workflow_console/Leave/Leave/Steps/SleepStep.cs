using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Leave.Steps
{
    public class SleepStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            if (context.PersistenceData == null)
            {
                Console.WriteLine("请假流程3s后开始。");
                return ExecutionResult.Sleep(TimeSpan.FromSeconds(10), new Object());
            }
            Console.WriteLine("请假流程开始。");
            return ExecutionResult.Next();
        }
    }
}