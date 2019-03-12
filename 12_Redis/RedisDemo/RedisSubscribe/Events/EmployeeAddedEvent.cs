using System;
using ZEMIC.Human.Resource.Common.Enums;

namespace RedisSubscribe.Events
{
    public class Event
    {
        public virtual int? InsertionOrder { get; set; }
        public virtual string EventType { get; set; }
        public virtual string JsonPayload { get; set; }
        public virtual Guid EventId { get; set; }
        public virtual DateTime UtcTimeStamp { get; set; }
        public virtual Guid AggregateRootId { get; set; }
        public virtual int Version { get; set; }
    }

    public class EmployeeAddedEvent
    {
        public Guid AggregateRootId { set; get; }
        public Guid UserId { set; get; }
        public Guid CreatedUserId { set; get; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreateTime { get; }
        public string BeforeName { get; }
        public string Phone { get; }
        public string Email { get; }
        public Nationality? Nationality { get; }
        public StaffState? EmployeeState { get; }
        public string GroupCode { get; }
        public Nation? Nation { get; }
        public EmployeeSex? Sex { get; }
        public string EmployeeGroupCode { get; }
        public PoliticsStatus? EmployeePolitics { get; }
        public MaritalStatus? MaritalStatus { get; }
        public string CardId { get; }
        public DateTime? Birthday { get; }
        public string NativePlace { get; }
        public ResidenceType? ResidenceType { get; }
        public string RegisteredResidence { get; }
        public string Birthplace { get; }
        public string Address { get; }
        public string EmergencyPhone { get; }
        public string FamilyPhone { get; }
        public string OfficePhone { get; }
        public string Postcode { get; }
        public DateTime? InZemicDate { get; }
        public DateTime? InAVICDate { get; }
        public DateTime? InWorkDate { get; }
        public DateTime? LeaveZemicDate { get; }
        public Guid? Department { get; }
        public Guid? FileId { get; }
        public Guid EnterpriseId { get; }
    }
}
