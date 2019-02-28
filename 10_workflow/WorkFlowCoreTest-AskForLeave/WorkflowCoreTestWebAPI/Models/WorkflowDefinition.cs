using System;

namespace WorkflowCoreTestWebAPI.Models
{
    public class WorkflowDefinition
    {
        public Guid WorkflowDefinitionId { get; set; }
        public string WorkflowName { get; set; }
        public int StepCount { get; set; }
    }
}