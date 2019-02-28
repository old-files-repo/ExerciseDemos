using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StackExchange.Redis;

namespace RedisHash
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            //重复复用，已实现IDisposable

            IDatabase db = redis.GetDatabase();//访问redis数据库

            var person = new Person
            {
                Id = 1,
                FirstName = "yu",
                LastName = "zhao"
            };

            db.HashSet("user:1", person.ToHashEntyies());

            HashEntry[] entries = db.HashGetAll("user:1");
            var thePerson = entries.ConvertFromRedis<Person>();

            foreach (var item in thePerson.GetType().GetProperties())
            {
                Console.WriteLine($"{item.Name} + {item.GetValue(thePerson).ToString()}");
            }

            Console.ReadKey();
        }

        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            //public string FullName => FirstName + LastName;
        }
    }

    public static class Help
    {
        public static HashEntry[] ToHashEntyies(this object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            return propertyInfos.Select(x =>
                new HashEntry(x.Name, x.GetValue(obj).ToString())).ToArray();

        }

        public static T ConvertFromRedis<T>(this HashEntry[] hashEntries)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            var obj = Activator.CreateInstance(typeof(T));
            foreach (var property in propertyInfos)
            {
                HashEntry entry = hashEntries.FirstOrDefault(x => x.Name.ToString().Equals(property.Name));
                if (entry.Equals(new HashEntry())) continue;
                property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
            }
            return (T)obj;
        }
    }
}
