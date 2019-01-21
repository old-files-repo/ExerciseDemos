using System;

namespace CoreApi.Models.Common
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string LastAction { get; set; }
    }
}