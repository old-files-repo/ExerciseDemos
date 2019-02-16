using System;
using LeaveWebsite.Controllers;
using LeaveWebsite.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace LeaveWebsite.Workflows
{
    public class LeaveWorkflow : IWorkflow<Leave>
    {
        public string Id => nameof(LeaveWorkflow);

        public int Version => 1;

        public void Build(IWorkflowBuilder<Leave> builder)
        {
            builder
                .Start()
                .Parallel()
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelOne", (data, step) => data.Id.ToString(), data => DateTime.Now)
                    .Output(step => step.ExamState, data => ExamState.一级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelTwo", (data, step) => data.Id.ToString(), data => DateTime.Now)
                    .Output(step => step.ExamState, data => ExamState.二级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("ExamedLevelThree", (data, step) => data.Id.ToString(), data => DateTime.Now)
                    .Output(step => step.ExamState, data => ExamState.三级审批通过)
                )
                .Do(then => then
                    .StartWith(context => ExecutionResult.Next())
                    .WaitFor("Rejected", (data, step) => data.Id.ToString(), data => DateTime.Now)
                    .Output(step => step.ExamState, data => ExamState.已驳回)
                )
                .Join();
        }
    }
}
