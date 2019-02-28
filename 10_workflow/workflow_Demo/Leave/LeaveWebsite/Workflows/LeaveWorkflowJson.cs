using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LeaveWebsite.Workflows
{
    public static class LeaveWorkflowJsons
    {
        public static string GetLeaveWorkflowJson()
        {
            var leaveWorkflowJson = new LeaveWorkflowJson();
            var json=JsonConvert.SerializeObject(leaveWorkflowJson);
            return json;
        }
    }

    public abstract class WorkflowJson
    {
        public abstract string Id { get; }
        public abstract int Version { get; }
        public abstract string DataType { get; }
        public abstract Step[] Steps { get; set; }
    }

    public class Step
    {
        public string Id { get; set; }
        public string StepType { get; set; }
        public string NextStepId { get; set; }
        public Event Inputs { get; set; }
        public Process Outputs { get; set; }
        public string CancelCondition { get; set; }
        public List<Step[]> Do { get; set; }

    }

    public class Event
    {
        public string EventName { get; set; }
        public string EventKey { get; set; }
        public DateTime EffectiveDate { get; set; }
    }

    public class Process
    {
        public string Data { get; set; }
        public string Step { get; set; }
        public string Context { get; set; }
    }
}