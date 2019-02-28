namespace WorkflowCoreTestWebAPI.Models
{
    public class WorkflowData
    {
        public int CurrentStepCount { get; set; }
        public string StepName { get; set; }
        public string State { get; set; }
        public string DeniedReason { get; set; }
        public string WorkflowDataJson { get; set; }
    }
}