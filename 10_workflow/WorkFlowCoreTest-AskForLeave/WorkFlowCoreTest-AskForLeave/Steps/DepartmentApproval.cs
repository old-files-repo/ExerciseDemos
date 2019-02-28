using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCoreTest_AskForLeave.Models;

namespace WorkFlowCoreTest_AskForLeave.Steps
{
    public class DepartmentApproval : StepBody
    {
        public AskForLeaveInfo AskForLeaveInfo { get; set; }
        public ApprovalInfo DepartmentApprovalInfo { get; set; }
        public AskForLeaveState AskForLeaveState { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            if (DepartmentApprovalInfo.ApprovalState == ApprovalState.Approved)
            {
                var timeDiff = AskForLeaveInfo.EndTime - AskForLeaveInfo.StartTime;
                var totalDays = timeDiff.TotalDays;

                AskForLeaveState = totalDays > 3 
                    ? AskForLeaveState.CompanyWaited 
                    : AskForLeaveState.Approved;
            }
            else
            {
                AskForLeaveState = AskForLeaveState.Denied;
            }
            
            return ExecutionResult.Next();
        }
    }
}