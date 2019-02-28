using System.Collections.Generic;
using System.Linq;
using graph.interfaces;
using graph.Models;

namespace graph.Impl
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            var micl = new Person
            {
                Id = 1,
                Name = "mic",
                Email = "mic@qq.com"
            };
            var cl2d = new Person
            {
                Id = 2,
                Name = "cl2d",
                Email = "cl2d@qq.com"
            };
            var dave = new Person
            {
                Id = 3,
                Name = "dave",
                Email = "dave@qq.com",
                Parents = new[]
                {
                    micl,cl2d
                }
            };
            return new List<Person>
            {
                micl,cl2d,dave
            };
        }

        public Person GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}