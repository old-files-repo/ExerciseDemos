using LeaveWebsite.Controllers;
using LeaveWebsite.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace LeaveWebsite.Workflows
{
    public class LeaveWorkflowIf : IWorkflow<Leave>
    {
        public string Id => nameof(LeaveWorkflowIf);

        public int Version => 1;

        public void Build(IWorkflowBuilder<Leave> builder)
        {
            builder
                .Start()
                .If(data => data.ExamState == ExamState.一级审批通过)
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .Output(step => step.Completed, data => ExamState.一级审批通过)
                )
                .If(data => data.ExamState == ExamState.二级审批通过)
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .Output(step => step.Completed, data => ExamState.二级审批通过)
                )
                .If(data => data.ExamState == ExamState.三级审批通过)
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .Output(step => step.Completed, data => ExamState.三级审批通过)
                )
                .If(data => data.ExamState == ExamState.已驳回)
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .Output(step => step.Completed, data => ExamState.已驳回)
                );
        }
    }
}
