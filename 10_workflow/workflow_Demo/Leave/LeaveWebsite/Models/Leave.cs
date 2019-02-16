using System;
using LeaveWebsite.Controllers;

namespace LeaveWebsite.Models
{
    public class Leave
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ApplyUser { get; set; }
        public string ApplyContent { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public ExamState ExamState { get; set; } = ExamState.Î´ÉóÅú;

        //public bool Completed { get; set; } = false;
    }
}