using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCoreTest_AskForLeave.Models;
using WorkFlowCoreTest_AskForLeave.Steps;

namespace WorkFlowCoreTest_AskForLeave.WorkFlows
{
    public class AskForLeaveWorkflow : IWorkflow<AskForLeaveData>
    {
        public string Id => "AskForLeave";
        public int Version => 1;

        public void Build(IWorkflowBuilder<AskForLeaveData> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                .While(data => data.AskForLeaveState == AskForLeaveState.DepartmentWaited).Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("DepartmentApprovalEvent", data => data.DepartmentApprovalEventKey)
                        .Output(data => data.DepartmentApprovalInfo, step => ((DepartmentApprovalEventModel)step.EventData).DepartmentApprovalInfo)
                        .Output(data => data.DepartmentApprovalEventKey, step => ((DepartmentApprovalEventModel)step.EventData).DepartmentApprovalEventKey)
                    .Then<DepartmentApproval>()
                        .Input(step => step.AskForLeaveInfo, data => data.AskForLeaveInfo)
                        .Input(step => step.DepartmentApprovalInfo, data => data.DepartmentApprovalInfo)
                        .Output(data => data.AskForLeaveState, step => step.AskForLeaveState)
                    .If(data => data.AskForLeaveState == AskForLeaveState.CompanyWaited).Do(next => next
                        .StartWith(context => ExecutionResult.Next())
                        .WaitFor("CompanyApprovalEvent", data => data.CompanyApprovalEventKey)
                            .Output(data => data.CompanyApprovalInfo, step => ((CompanyApprovalEventModel)step.EventData).CompanyApprovalInfo)
                            .Output(data => data.CompanyApprovalEventKey, step => ((CompanyApprovalEventModel)step.EventData).CompanyApprovalEventKey)
                        .Then<CompanyApproval>()
                            .Input(step => step.CompanyApprovalInfo, data => data.CompanyApprovalInfo)
                            .Output(data => data.AskForLeaveState, step => step.AskForLeaveState)
                    )
                    .If(data => data.AskForLeaveState == AskForLeaveState.Denied).Do(next => next
                        .StartWith(context => ExecutionResult.Next())
                        .WaitFor("UserEditEvent", data => data.UserEditEventKey)
                            .Output(data => data.AskForLeaveInfo, step => ((UserEditEventModel)step.EventData).AskForLeaveInfo)
                            .Output(data => data.AskForLeaveState, step => ((UserEditEventModel)step.EventData).AskForLeaveState)
                            .Output(data => data.UserEditEventKey, step => ((UserEditEventModel)step.EventData).UserEditEventKey)
                    )
                )
                .Then<EndAskForLeave>();
        }
    }
}