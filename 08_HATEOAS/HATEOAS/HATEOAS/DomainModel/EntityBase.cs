using System;

namespace HATEOAS.DomainModel
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string LastAction { get; set; }
    }
}