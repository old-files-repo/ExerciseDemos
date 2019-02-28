using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCoreTestWebAPI.Steps
{
    public class InitWorkFlow : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }

    public class ProcessWorkFlow : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}