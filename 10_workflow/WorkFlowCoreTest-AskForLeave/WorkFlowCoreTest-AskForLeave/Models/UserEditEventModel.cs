namespace WorkFlowCoreTest_AskForLeave.Models
{
    public class UserEditEventModel
    {
        public AskForLeaveState AskForLeaveState { get; set; }
        public AskForLeaveInfo AskForLeaveInfo { get; set; }
        public string UserEditEventKey { get; set; }
    }
}