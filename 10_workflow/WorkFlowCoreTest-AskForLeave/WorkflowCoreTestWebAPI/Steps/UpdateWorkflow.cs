using Newtonsoft.Json;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCoreTestWebAPI.Models;

namespace WorkflowCoreTestWebAPI.Steps
{
    public class UpdateWorkflow : StepBody
    {
        public string WorkflowDataJson { get; set; }
        public string State { get; set; }
        public int CurrentStepCount { get; set; }
        public string StepName { get; set; }
        public string DeniedReason { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var workflowDataUiCommand = JsonConvert.DeserializeObject<WorkflowDataUICommand>(WorkflowDataJson);

            State = workflowDataUiCommand.State;
            CurrentStepCount = workflowDataUiCommand.CurrentStepCount;
            StepName = workflowDataUiCommand.StepName;
            DeniedReason = workflowDataUiCommand.DeniedReason;

            var askForLeaveData = AskForLeaveStore.Get(workflowDataUiCommand.AggregateRootId);

            askForLeaveData.CurrentStep = workflowDataUiCommand.StepName;
            askForLeaveData.CurrentStepCount = workflowDataUiCommand.CurrentStepCount;
            askForLeaveData.State = workflowDataUiCommand.State;
            askForLeaveData.DeniedReason = workflowDataUiCommand.DeniedReason;
            AskForLeaveStore.Update(askForLeaveData);

            return ExecutionResult.Next();
        }
    }
}