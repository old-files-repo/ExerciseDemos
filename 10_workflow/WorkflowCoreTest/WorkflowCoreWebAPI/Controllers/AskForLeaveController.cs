using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCoreWebAPI.Workflows;

namespace WorkflowCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AskForLeaveController : Controller
    {

        private readonly IWorkflowHost _workflowHost;
        private readonly IWorkflowRegistry _workflowRegistry;
        private readonly IPersistenceProvider _ipersistenceProvider;
        private readonly ILogger _logger;

        public AskForLeaveController(IWorkflowHost workflowHost, IWorkflowRegistry workflowRegistry,
            IPersistenceProvider ipersistenceProvider, ILoggerFactory loggerFactory)
        {
            _workflowHost = workflowHost;
            _workflowRegistry = workflowRegistry;
            _ipersistenceProvider = ipersistenceProvider;
            _logger = loggerFactory.CreateLogger<AskForLeaveController>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _ipersistenceProvider.GetWorkflowInstance(id);
            return Json(result);
        }

        [HttpPost("{id}")]
        [HttpPost("{id}/{version}")]
        public async Task<IActionResult> Post(string id, int? version, [FromBody]AskForLeaveData askForLeaveData)
        {
            string workflowId = null;
            var workflowData = new WorkflowData<AskForLeaveData>
            {
                ApprovedState = ApprovedState.New,
                Record = askForLeaveData
            };
            var def = _workflowRegistry.GetDefinition(id, version);
            if (def == null)
                return BadRequest(String.Format("Workflow defintion {0} for version {1} not found", id, version));

            workflowId = await _workflowHost.StartWorkflow(id, version, workflowData);

            return Ok(workflowId);
        }

        [HttpPost("{eventName}/{eventKey}")]
        public async Task<IActionResult> Post(string eventName, string eventKey, [FromBody]WorkflowData<AskForLeaveData> eventData)
        {
            var workflowInstance = await _ipersistenceProvider.GetWorkflowInstance(eventKey);
            eventData.Record = ((WorkflowData<AskForLeaveData>)workflowInstance.Data).Record;
            //_workflowHost.
            await _workflowHost.PublishEvent(eventName, eventKey, eventData);
            return Ok();
        }
    }
}
