using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HATEOAS.DomainModel
{
    public class Vehicle : EntityBase
    {
        public string Model { get; set; }
        public string Owner { get; set; }
    }
}
