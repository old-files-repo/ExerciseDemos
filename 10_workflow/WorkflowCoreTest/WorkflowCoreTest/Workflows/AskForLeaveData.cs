using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCoreTest.Workflows
{
    public class AskForLeaveData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Reason { get; set; }
        public string CurrentState { get; set; }
    }

    public class WorkflowData<T> : StepBody
    {
        public T Record { get; set; }
        public ApprovedState ApprovedState { get; set; }
        public string DeniedReason { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }

    public class ApplyEvent : StepBody
    {
        public string State { get; set; }
        public AskForLeaveData AskForLeaveData { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //Do logic in here
            //context.Item
            //throw new NotImplementedException();
            //This should return next step always
            ((AskForLeaveData)context.Workflow.Data).CurrentState = State;
            Console.WriteLine(State);
            return ExecutionResult.Next();
        }
    }

    public class WorkflowFinished : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }

    public enum ApprovedState
    {
        New = 0,
        Approved = 1,
        Denied = 2
    }
}