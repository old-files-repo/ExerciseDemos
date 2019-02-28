using System;

namespace WorkFlowCoreTest_AskForLeave.Models
{
    public class ApprovalInfo
    {
        public string Name { get; set; }
        public DateTime ApprovalDate { get; set; }
        public ApprovalState ApprovalState { get; set; }
        public string Remark { get; set; }
    }
}