using System;

namespace WorkflowCoreTestWebAPI.Models
{
    public class AskForLeaveInfo
    {
        public Guid Id { get; set; }
        public string WorkflowId { get; set; }
        public string Name { get; set; }
        public int ApplyDays { get; set; }
        public DateTime ApplyDate { get; set; }
        public string DeniedReason { get; set; }
        public int StepCount { get; set; }
        public int CurrentStepCount { get; set; }
        public string CurrentStep { get; set; }
        public string State { get; set; }
    }
}