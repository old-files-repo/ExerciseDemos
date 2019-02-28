using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCoreTestWebAPI.Steps
{
    public class EndWorkFlow : StepBody
    {
        public Guid AggregateRootId { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}