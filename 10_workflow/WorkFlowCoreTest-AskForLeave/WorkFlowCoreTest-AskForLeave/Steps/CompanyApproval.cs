using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCoreTest_AskForLeave.Models;

namespace WorkFlowCoreTest_AskForLeave.Steps
{
    public class CompanyApproval : StepBody
    {
        public ApprovalInfo CompanyApprovalInfo { get; set; }
        public AskForLeaveState AskForLeaveState { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            AskForLeaveState = CompanyApprovalInfo.ApprovalState == ApprovalState.Approved
                ? AskForLeaveState.Approved
                : AskForLeaveState.Denied;

            return ExecutionResult.Next();
        }
    }
}