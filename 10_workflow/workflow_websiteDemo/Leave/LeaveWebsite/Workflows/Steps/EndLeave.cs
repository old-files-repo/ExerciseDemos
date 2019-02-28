using System;
using LeaveWebsite.Controllers;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace LeaveWebsite.Workflows.Steps
{
    public class EndLeave : StepBody
    {
        public Guid Id { get; set; }
        public ExamState ExamState { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var item = LeaveStore.Get(Id);
            item.ExamState = ExamState;
            LeaveStore.Edit(item);
            return ExecutionResult.Next();
        }
    }
}