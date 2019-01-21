using System;
using System.Reflection;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var entityBase = typeof(EntityBase);
            var propertyInfos = entityBase.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(entityBase);
            Console.WriteLine(propertyInfos);
            Console.ReadKey();
        }
    }

    public class EntityBase
    {
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
