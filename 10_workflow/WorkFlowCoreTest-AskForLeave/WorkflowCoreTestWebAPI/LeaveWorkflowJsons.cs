using System.IO;

namespace WorkflowCoreTestWebAPI
{
    public static class WorkflowJsons
    {
        public static string GetWorkflowJsons()
        {
            return File.ReadAllText("WorkFlows/AskForLeaveWorkflow.json");
        }
    }
}
