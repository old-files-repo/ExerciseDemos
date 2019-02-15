using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace LeaveWebsite.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IMapper _mapper;
        private static readonly List<Leave> Leaves = new List<Leave>();

        public SampleDataController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LeaveViewModel> GetAll()
        {
            var result = Leaves.Select(x => _mapper.Map<LeaveViewModel>(x));
            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Leave leave)
        {
            Leaves.Add(new Leave
            {
                ApplyUser = leave.ApplyUser,
                ApplyContent = leave.ApplyContent
            });

            return Ok();
        }

    }

    public class Leave
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ApplyUser { get; set; }
        public string ApplyContent { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public ExamState ExamState { get; set; } = ExamState.未审批;
    }

    public class LeaveViewModel
    {
        public string Id { get; set; }
        public string ApplyUser { get; set; }
        public string ApplyContent { get; set; }
        public string CreateDate { get; set; }
        public string ExamState { get; set; }
    }

    public enum ExamState
    {
        未审批 = 0,
        已审批 = 1,
        已驳回 = 2
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Leave, LeaveViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id.ToString()))
                .ForMember(d => d.CreateDate, s => s.MapFrom(x => x.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(d => d.ExamState, s => s.MapFrom(x => Enum.GetName(typeof(ExamState), x.ExamState)));
        }
    }
}
