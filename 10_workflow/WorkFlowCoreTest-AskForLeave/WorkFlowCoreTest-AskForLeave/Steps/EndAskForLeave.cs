using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkFlowCoreTest_AskForLeave.Steps
{
    public class EndAskForLeave : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}