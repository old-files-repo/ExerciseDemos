using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace LeaveWebsite.Workflows
{
    public static class StartExtensionMethod
    {
        public static IStepBuilder<T, InlineStepBody> Start<T>(this IWorkflowBuilder<T> builder)
        {
            return builder.StartWith(context => ExecutionResult.Next());
        }
    }
}