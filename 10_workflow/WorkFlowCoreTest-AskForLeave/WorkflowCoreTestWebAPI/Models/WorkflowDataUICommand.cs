using System;

namespace WorkflowCoreTestWebAPI.Models
{
    public class WorkflowDataUICommand
    {
        public string Id { get; set; }
        public Guid AggregateRootId { get; set; }
        public int CurrentStepCount { get; set; }
        public string StepName { get; set; }
        public string State { get; set; }
        public string DeniedReason { get; set; }
    }
}