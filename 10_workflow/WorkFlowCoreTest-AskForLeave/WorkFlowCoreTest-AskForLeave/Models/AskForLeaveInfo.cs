using System;

namespace WorkFlowCoreTest_AskForLeave.Models
{
    public class AskForLeaveInfo
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Reason { get; set; }
    }
}