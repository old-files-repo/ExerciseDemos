using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeaveWebsite.Models;
using LeaveWebsite.Workflows;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;

namespace LeaveWebsite.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWorkflowHost _workflowHost;
        private readonly IMapper _mapper;
        private static readonly List<Leave> Leaves = new List<Leave>();

        public SampleDataController(IMapper mapper,
            IWorkflowHost workflowHost)
        {
            _mapper = mapper;
            _workflowHost = workflowHost;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Leave leave)
        {
            var leaveModel = new Leave
            {
                ApplyUser = leave.ApplyUser,
                ApplyContent = leave.ApplyContent
            };
            Leaves.Add(leaveModel);

            //_workflowHost.StartWorkflow(nameof(LeaveWorkflow), leaveModel);

            return Ok();
        }

        //[HttpPut("exam/{id}")]
        [HttpPut("exam/{id}/{level}")]
        public IActionResult Exam(Guid id, ExamState level)
        {
            Leaves.ForEach(x =>
            {
                if (x.Id == id)
                {
                    x.ExamState = level;
                    _workflowHost.StartWorkflow(nameof(LeaveWorkflowIf), x);
                }
            });
            //Leaves.ForEach(x =>
            //{
            //    if (x.Id == id && (x.ExamState == ExamState.已驳回 || x.ExamState == ExamState.未审批))
            //    {
            //        _workflowHost.PublishEvent("ExamedLevelOne", id.ToString(), null);
            //    }
            //    else if (x.Id == id && x.ExamState == ExamState.一级审批通过)
            //    {
            //        _workflowHost.PublishEvent("ExamedLevelTwo", id.ToString(), null);
            //    }
            //    else if (x.Id == id && x.ExamState == ExamState.二级审批通过)
            //    {
            //        _workflowHost.PublishEvent("ExamedLevelThree", id.ToString(), null);
            //    }
            //});

            return Ok();
        }

        [HttpPut("reject/{id}")]
        public IActionResult Reject(Guid id)
        {
            Leaves.ForEach(x =>
            {
                if (x.Id == id && x.ExamState != ExamState.三级审批通过)
                {
                    x.ExamState = ExamState.已驳回;
                    _workflowHost.StartWorkflow(nameof(LeaveWorkflowIf), x);
                    //_workflowHost.PublishEvent("Rejected", id.ToString(), null);
                }
            });

            return Ok();
        }

        [HttpGet]
        public IEnumerable<LeaveViewModel> GetAll()
        {
            var result = Leaves.Select(x => _mapper.Map<LeaveViewModel>(x));
            return result;
        }
    }

    public enum ExamState
    {
        已驳回 = -1,
        未审批 = 0,
        一级审批通过 = 1,
        二级审批通过 = 2,
        三级审批通过 = 3
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Leave, LeaveViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id.ToString()))
                .ForMember(d => d.CreateDate, s => s.MapFrom(x => x.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.ExamState, s => s.MapFrom(x => Enum.GetName(typeof(ExamState), x.Completed)));
        }
    }
}
