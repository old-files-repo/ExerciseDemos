using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCoreTest.Workflows
{
    public class AskForLeaveWorkflow : IWorkflow<WorkflowData<AskForLeaveData>>
    {
        public void Build(IWorkflowBuilder<WorkflowData<AskForLeaveData>> builder)
        {
            builder
                .StartWith<WorkflowData<AskForLeaveData>>()
                .Then<WorkflowData<AskForLeaveData>>()
                .WaitFor("ManagerApplyEvent", (data, context) => context.Workflow.Id)
                .If(data => data.ApprovedState == ApprovedState.Approved)
                .Do(then =>
                {
                    then.StartWith<ApplyEvent>()
                        .Input(step => step.AskForLeaveData, data => data.Record)
                        .Input(step => step.State, data => "ManagerApproved");
                })
                .If(data => data.ApprovedState == ApprovedState.Denied)
                .Do(then =>
                {
                    then.StartWith<ApplyEvent>()
                        .Input(step => step.AskForLeaveData, data => data.Record)
                        .Input(step => step.State, data => "ManagerDenied");
                })
                .WaitFor("CompanyApplyEvent", (data, context) => context.Workflow.Id, data => DateTime.Now)
                .If(data => data.ApprovedState == ApprovedState.Approved)
                .Do(companyAppliedThe => ExecutionResult.Next())
                .If(data => data.ApprovedState == ApprovedState.Denied)
                .Do(companyAppliedThe => ExecutionResult.Next());

        }

        public string Id { get; } = "AskForLeaveWorkflow";
        public int Version { get; } = 5;
    }
}