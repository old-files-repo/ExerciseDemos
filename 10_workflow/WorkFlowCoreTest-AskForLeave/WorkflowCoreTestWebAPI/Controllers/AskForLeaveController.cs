using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WorkflowCore.Interface;
using WorkflowCoreTestWebAPI.Models;

namespace WorkflowCoreTestWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AskForLeaveController : Controller
    {
        private readonly IWorkflowHost _workflowHost;
        private readonly IPersistenceProvider _persistenceProvider;

        public AskForLeaveController(IWorkflowHost workflowHost,
            IPersistenceProvider persistenceProvider)
        {
            _workflowHost = workflowHost;
            _persistenceProvider = persistenceProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AskForLeaveInfo askForLeaveInfo)
        {
            var workflowDefinition = new WorkflowDefinition
            {
                StepCount = 2,
                WorkflowName = "AskForLeave"
            };
            var workflowData = new WorkflowData
            {
                State = "已提交",
                StepName = "用户提交"
            };
            var workflowId = await _workflowHost.StartWorkflow("AskForLeaveWorkflow", 1, workflowData);

            askForLeaveInfo.StepCount = workflowDefinition.StepCount;
            askForLeaveInfo.WorkflowId = workflowId;
            AskForLeaveStore.Add(askForLeaveInfo);
            return Ok(workflowId);
        }

        [HttpPost("{eventName}/{eventKey}")]
        public async Task<IActionResult> Post(string eventName, string eventKey, [FromBody]WorkflowDataUICommand eventData)
        {
            await _workflowHost.PublishEvent(eventName, eventKey, JsonConvert.SerializeObject(eventData));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _persistenceProvider.GetWorkflowInstance(id);
            return Json(result);
        }
    }
}
