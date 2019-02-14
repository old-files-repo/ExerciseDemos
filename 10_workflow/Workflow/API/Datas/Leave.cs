namespace API.Datas
{
    public class Leave : Entity
    {
        public string Content { get; set; }

        public bool ApplyState { get; set; }

        public bool ApprovalState { get; set; }
    }
}
