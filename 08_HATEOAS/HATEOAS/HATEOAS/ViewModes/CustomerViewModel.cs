using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HATEOAS.DomainModel;

namespace HATEOAS.ViewModes
{
    public class CustomerViewModel : EntityBase
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public DateTimeOffset EstablishmentTime { get; set; }
    }
}
