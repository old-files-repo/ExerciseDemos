using System;
using xxxxx.Human.Resource.Common.Enums;

namespace RedisSubscribe.Events
{
    public class SiteEmployeeAddedEvent
    {
        public Guid AggregateRootId { set; get; }
        public Guid? Post { get; }
        public AcademicDegree? AcademicDegree { get; }
        public Major? Major { get; }
        public decimal? Weight { get; }
        public Guid? FileId { get; }
        public DateTime CreatedTime { get; }
        public Guid SiteEmployeeId { get; }
        public Guid CreatedUserId { get; }
        public Guid EnterpriseId { get; }
        public EmployeeType? Type { get; }
        public string WorkNo { get; }
        public Guid UserId { set; get; }
    }
}