namespace WorkFlowCoreTest_AskForLeave.Models
{
    public class AskForLeaveData
    {
        public AskForLeaveInfo AskForLeaveInfo { get; set; }
        public ApprovalInfo DepartmentApprovalInfo { get; set; }
        public ApprovalInfo CompanyApprovalInfo { get; set; }
        public AskForLeaveState AskForLeaveState { get; set; }
        public string DepartmentApprovalEventKey { get; set; }
        public string CompanyApprovalEventKey { get; set; }
        public string UserEditEventKey { get; set; }
    }
}