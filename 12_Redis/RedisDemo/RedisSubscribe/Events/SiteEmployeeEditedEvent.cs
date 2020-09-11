using System;
using xxxxx.Human.Resource.Common.Enums;

namespace RedisSubscribe.Events
{
    public class SiteEmployeeEditedEvent
    {
        public Guid AggregateRootId { set; get; }
        public Guid? Post { get; }
        public AcademicDegree? AcademicDegree { get; }
        public Major? Major { get; }
        public decimal? Weight { get; }
        public Guid? FileId { get; }
        public DateTime? LastModifiedTime { get; }
        public Guid? LastModifiedUserId { get; }
        public Guid SiteEmployeeId { get; }
        public EmployeeType? Type { get; }
        public string WorkNo { get; }
        public Guid UserId { set; get; }
    }
}