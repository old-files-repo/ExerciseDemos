using System;
using Xunit;

namespace Hospital
{
    public class Patient
    {
        public Patient()
        {
            IsNew = true;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int HeartBeatRate { get; set; }
        public bool IsNew { get; set; }

        public void IncreaseHeartBeatRate()
        {
            HeartBeatRate = CalculateHeartBeatRate() + 2;
        }

        private int CalculateHeartBeatRate()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
    }
}
