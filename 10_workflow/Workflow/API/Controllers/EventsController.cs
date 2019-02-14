using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkflowCore.Interface;

namespace API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IWorkflowController _workflowService;
        private readonly IWorkflowRegistry _registry;

        public EventsController(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpPost("{eventName}/{eventKey}")]
        public async Task<IActionResult> Post(string id, int? version, string reference, [FromBody]JObject data)
        {
            string workflowId = null;
            var def = _registry.GetDefinition(id, version);
            if (def == null)
                return BadRequest(String.Format("Workflow defintion {0} for version {1} not found", id, version));

            if ((data != null) && (def.DataType != null))
            {
                var dataStr = JsonConvert.SerializeObject(data);
                var dataObj = JsonConvert.DeserializeObject(dataStr, def.DataType);
                workflowId = await _workflowService.StartWorkflow(id, version, dataObj, reference);
            }
            else
            {
                workflowId = await _workflowService.StartWorkflow(id, version, null, reference);
            }

            return Ok(workflowId);
        }

    }
}
