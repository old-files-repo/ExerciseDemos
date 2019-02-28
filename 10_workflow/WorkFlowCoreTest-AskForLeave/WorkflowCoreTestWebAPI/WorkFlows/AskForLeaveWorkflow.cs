using WorkflowCore.Interface;
using WorkflowCoreTestWebAPI.Models;
using WorkflowCoreTestWebAPI.Steps;

namespace WorkflowCoreTestWebAPI.WorkFlows
{
    public class AskForLeaveWorkflow : IWorkflow<WorkflowData>
    {
        public string Id => "AskForLeaveWorkflow";
        public int Version => 1;

        public void Build(IWorkflowBuilder<WorkflowData> builder)
        {
            builder
                .StartWith<InitWorkFlow>()
                .WaitFor("DepartmentAuditedEvent", (data, context) => context.Workflow.Id)
                    .Output(data => data.WorkflowDataJson, step => step.EventData)
                .Then<UpdateWorkflow>()
                    .Input(step => step.WorkflowDataJson, data => data.WorkflowDataJson)
                    .Output(data => data.State, step => step.State)
                    .Output(data => data.DeniedReason, step => step.DeniedReason)
                    .Output(data => data.StepName, step => step.StepName)
                    .Output(data => data.CurrentStepCount, step => step.CurrentStepCount)
                .If(data => data.State == "通过").Do(then => then
                    .StartWith<InitWorkFlow>()
                    .WaitFor("CompanyAuditedEvent", (data, context) => context.Workflow.Id)
                        .Output(data => data.WorkflowDataJson, step => step.EventData)
                    .Then<UpdateWorkflow>()
                        .Input(step => step.WorkflowDataJson, data => data.WorkflowDataJson)
                        .Output(data => data.State, step => step.State)
                        .Output(data => data.DeniedReason, step => step.DeniedReason)
                        .Output(data => data.StepName, step => step.StepName)
                        .Output(data => data.CurrentStepCount, step => step.CurrentStepCount));
        }
    }
}