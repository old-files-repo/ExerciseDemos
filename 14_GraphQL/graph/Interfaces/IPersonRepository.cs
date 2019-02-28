using System.Collections.Generic;
using graph.Models;

namespace graph.interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();

        Person GetById(int id);
    }
}